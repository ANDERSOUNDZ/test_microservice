using user_service.domain.entities;

namespace user_service
{
    public partial interface IUserRepository
    {
        Task<List<UsuarioEntity>> ObtenerTodosAsync();
        Task GuardarUsuarioAsync(UsuarioEntity usuario);
        Task<bool> ExisteUsernameAsync(string username);
        Task<UsuarioEntity?> ObtenerPorUsernameAsync(string username);
        Task ActualizarUsuarioAsync(UsuarioEntity usuario);
        Task EliminarUsuarioAsync(UsuarioEntity usuario);
    }
}
