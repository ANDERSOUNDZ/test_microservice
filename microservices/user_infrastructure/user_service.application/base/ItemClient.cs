namespace user_service
{
    public partial class ItemClient
    {
        private readonly HttpClient _httpClient;
        public ItemClient(
            HttpClient httpClient
            )
        {
            _httpClient = httpClient;
        }
    }
}
