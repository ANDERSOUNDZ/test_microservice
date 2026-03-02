using user_service.ports.dto.user;

namespace user_service
{
    public partial interface IUserUseCase
    {
        Task ExecuteAsync(CrearUsuarioRequest request);
        Task<List<UsuarioResponse>> ExecuteAsync();
        Task ExecuteAsync(EditarUsuarioRequest request);
        Task ExecuteAsync(string username);
    }
}
