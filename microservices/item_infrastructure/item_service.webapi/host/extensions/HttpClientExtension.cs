namespace item_service.webapi.host.extensions
{
    public static class HttpClientExtension
    {
        public static IServiceCollection AddExternalClients(this IServiceCollection services, IConfiguration config)
        {
            var productUrl = config["ExternalServices:ProductServiceUrl"] ?? "http://user_api:8080/";
            services.AddHttpClient<IUserClient, UserClient>(client =>
            {
                client.BaseAddress = new Uri(productUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            return services;
        }
    }
}
