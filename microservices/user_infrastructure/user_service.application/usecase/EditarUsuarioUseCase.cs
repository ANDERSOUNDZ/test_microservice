using user_service.ports.dto.user;

namespace user_service
{
    public partial class UserUseCase : IUserUseCase
    {
        /// <summary>
        /// Actualiza la información del perfil de un usuario existente.
        /// </summary>
        /// <param name="request">DTO con el username y el nuevo nombre.</param>
        public async Task ExecuteAsync(EditarUsuarioRequest request)
        {
            var usuario = await _userRepository.ObtenerPorUsernameAsync(request.Username);
            if (usuario == null) throw new Exception("Usuario no encontrado");

            usuario.NombreCompleto = request.NuevoNombre;
            await _userRepository.ActualizarUsuarioAsync(usuario);
        }
    }
}
