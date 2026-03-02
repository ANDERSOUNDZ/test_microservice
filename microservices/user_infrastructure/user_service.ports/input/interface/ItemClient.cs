namespace user_service
{
    public partial interface IItemClient
    {
        Task<bool> UsuarioTieneTareasPendientesAsync(string username);
    }
}