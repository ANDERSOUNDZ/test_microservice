using gateway_service.host;

/// <summary>
/// Punto de entrada principal para el API Gateway.
/// Configura el proxy inverso para la orquestación de microservicios.
/// </summary>
var builder = WebApplication.CreateBuilder(args);

var app = builder
    .ConfigureServices()
    .Build();

app.UseHexagonal();
app.Run();