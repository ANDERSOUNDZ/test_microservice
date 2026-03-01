FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["gateway_service/gateway_service.csproj", "gateway_service/"]

RUN dotnet restore "gateway_service/gateway_service.csproj"

COPY . .

WORKDIR "/src/gateway_service"
RUN dotnet build "gateway_service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gateway_service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "gateway_service.dll"]