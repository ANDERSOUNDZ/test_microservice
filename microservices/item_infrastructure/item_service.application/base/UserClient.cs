namespace item_service
{
    public partial class UserClient : IUserClient
    {
        private readonly HttpClient _httpClient;
        public UserClient(
            HttpClient httpClient
            )
        {
            _httpClient = httpClient;
        }
    }
}