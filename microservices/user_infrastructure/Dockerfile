FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["user_service.domain/user_service.domain.csproj", "user_service.domain/"]
COPY ["user_service.application/user_service.application.csproj", "user_service.application/"]
COPY ["user_service.ports/user_service.ports.csproj", "user_service.ports/"]
COPY ["user_service.data/user_service.data.csproj", "user_service.data/"]
COPY ["user_service.webapi/user_service.webapi.csproj", "user_service.webapi/"]

RUN dotnet restore "user_service.webapi/user_service.webapi.csproj"

COPY . .
WORKDIR "/src/user_service.webapi"
RUN dotnet build "user_service.webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "user_service.webapi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "user_service.webapi.dll"]