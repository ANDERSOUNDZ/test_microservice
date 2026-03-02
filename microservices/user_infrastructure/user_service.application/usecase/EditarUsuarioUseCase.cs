using user_service.ports.dto.user;

namespace user_service
{
    public partial class UserUseCase : IUserUseCase
    {
        public async Task ExecuteAsync(EditarUsuarioRequest request)
        {
            var usuario = await _userRepository.ObtenerPorUsernameAsync(request.Username);
            if (usuario == null) throw new Exception("Usuario no encontrado");

            usuario.NombreCompleto = request.NuevoNombre;
            await _userRepository.ActualizarUsuarioAsync(usuario);
        }
    }
}
