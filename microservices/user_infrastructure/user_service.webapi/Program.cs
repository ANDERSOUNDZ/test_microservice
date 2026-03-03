using user_service.webapi.host;

/// <summary>
/// Punto de entrada principal de la aplicación.
/// Configura el host web, los servicios de la arquitectura hexagonal y arranca el microservicio.
/// </summary>
var app = WebApplication.CreateBuilder(args)
    .ConfigureServices()
    .Build(); // Orquestación de inyección de dependencias
app.UseHexagonal(); // Configuración del pipeline de ASP.NET Core
app.Run();