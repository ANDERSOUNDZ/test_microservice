namespace item_service
{
    public partial interface IUserClient
    {
        Task<List<string>> ObtenerUsernamesDisponibles();
    }
}
