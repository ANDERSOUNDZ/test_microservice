using item_service.webapi.host;
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var app = WebApplication.CreateBuilder(args)
    .ConfigureServices()
    .Build();
app.UseHexagonal();
app.Run();