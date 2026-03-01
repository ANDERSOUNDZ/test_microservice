using user_service.domain.entities;
using user_service.ports.dto.user;

namespace user_service
{
    public partial class UserUseCase : IUserUseCase
    {
        public async Task ExecuteAsync(CrearUsuarioRequest request)
        {
            if (await _userRepository.ExisteUsernameAsync(request.Username))
                throw new Exception("El nombre de usuario ya está registrado.");

            var nuevoUsuario = new UsuarioEntity
            {
                Id = Guid.NewGuid(),
                Username = request.Username,
                NombreCompleto = request.NombreCompleto
            };

            await _userRepository.GuardarUsuarioAsync(nuevoUsuario);
        }
    }
}