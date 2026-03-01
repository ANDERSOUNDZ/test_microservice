using user_service.domain.entities;
using user_service.ports.dto.user;

namespace user_service
{
    public partial interface IUserUseCase
    {
        Task ExecuteAsync(CrearUsuarioRequest request);
        Task<List<UsuarioResponse>> ExecuteAsync();
    }
}
