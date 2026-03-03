using item_service.webapi.host;

/// <summary>
/// Configuración de compatibilidad para tipos de fecha en PostgreSQL.
/// </summary>
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

/// <summary>
/// Punto de entrada del microservicio de Ítems.
/// Orquesta la configuración de servicios y el pipeline de ejecución HTTP.
/// </summary>
var app = WebApplication.CreateBuilder(args)
    .ConfigureServices()
    .Build();
app.UseHexagonal();
app.Run();