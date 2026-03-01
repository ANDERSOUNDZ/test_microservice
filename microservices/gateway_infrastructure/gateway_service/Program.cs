using gateway_service.host;

var builder = WebApplication.CreateBuilder(args);

var app = builder
    .ConfigureServices()
    .Build();

app.UseHexagonal();
app.Run();