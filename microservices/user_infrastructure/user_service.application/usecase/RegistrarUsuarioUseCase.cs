using user_service.domain.entities;
using user_service.ports.dto.user;

namespace user_service
{
    public partial class UserUseCase : IUserUseCase
    {
        /// <summary>
        /// Orquesta la creación de un nuevo usuario en el sistema.
        /// Valida la unicidad del Username antes de persistir.
        /// </summary>
        /// <param name="request">DTO con los datos del nuevo usuario.</param>
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