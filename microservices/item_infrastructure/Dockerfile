FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["item_service.domain/item_service.domain.csproj", "item_service.domain/"]
COPY ["item_service.application/item_service.application.csproj", "item_service.application/"]
COPY ["item_service.ports/item_service.ports.csproj", "item_service.ports/"]
COPY ["item_service.data/item_service.data.csproj", "item_service.data/"]
COPY ["item_service.webapi/item_service.webapi.csproj", "item_service.webapi/"]

RUN dotnet restore "item_service.webapi/item_service.webapi.csproj"

COPY . .
WORKDIR "/src/item_service.webapi"
RUN dotnet build "item_service.webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "item_service.webapi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "item_service.webapi.dll"]