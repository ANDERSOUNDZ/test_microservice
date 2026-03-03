using user_service.ports.dto.user;

namespace user_service
{
    public partial class UserUseCase : IUserUseCase
    {
        /// <summary>
        /// Recupera todos los usuarios registrados y los proyecta a un DTO de respuesta.
        /// </summary>
        /// <returns>Lista de UsuarioResponse.</returns>
        public async Task<List<UsuarioResponse>> ExecuteAsync()
        {
            var entidades = await _userRepository.ObtenerTodosAsync();

            return entidades.Select(e => new UsuarioResponse(
                e.Username,
                e.NombreCompleto
            )).ToList();
        }
    }
}
