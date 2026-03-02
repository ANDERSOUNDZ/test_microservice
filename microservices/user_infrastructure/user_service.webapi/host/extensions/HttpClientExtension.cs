namespace user_service.webapi.host.extensions
{
    public static class HttpClientExtension
    {
        public static IServiceCollection AddExternalClients(this IServiceCollection services, IConfiguration config)
        {
            var itemUrl = config["ExternalServices:ItemServiceUrl"] ?? "http://item_api:8080/";

            services.AddHttpClient<IItemClient, ItemClient>(client =>
            {
                client.BaseAddress = new Uri(itemUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            return services;
        }
    }
}
