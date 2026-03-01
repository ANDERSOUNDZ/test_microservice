using item_service.webapi.host;

var app = WebApplication.CreateBuilder(args)
    .ConfigureServices()
    .Build();
app.UseHexagonal();
app.Run();