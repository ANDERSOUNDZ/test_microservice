using user_service.ports.dto.user;

namespace user_service
{
    /// <summary>
    /// Puerto de entrada que define los casos de uso para la gestión de usuarios.
    /// Define la frontera entre el mundo exterior y la lógica de negocio.
    /// </summary>
    public partial interface IUserUseCase
    {
        /// <summary>Ejecuta la lógica para crear un usuario.</summary>
        Task ExecuteAsync(CrearUsuarioRequest request);

        /// <summary>Ejecuta la lógica para obtener todos los usuarios.</summary>
        Task<List<UsuarioResponse>> ExecuteAsync();

        /// <summary>Ejecuta la lógica para modificar un usuario existente.</summary>
        Task ExecuteAsync(EditarUsuarioRequest request);

        /// <summary>Ejecuta la lógiaac para dar de baja a un usuario.</summary>
        Task ExecuteAsync(string username);
    }
}
