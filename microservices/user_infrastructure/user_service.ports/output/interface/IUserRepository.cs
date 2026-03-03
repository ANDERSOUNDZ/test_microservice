using user_service.domain.entities;

namespace user_service
{
    /// <summary>
    /// Puerto de salida que define el contrato para la persistencia de usuarios.
    /// Permite que la capa de dominio se comunique con la infraestructura (Base de Datos) 
    /// de forma desacoplada.
    /// </summary>
    public partial interface IUserRepository
    {
        /// <summary>
        /// Recupera todos los usuarios almacenados en la base de datos.
        /// </summary>
        /// <returns>Una lista de entidades de tipo <see cref="UsuarioEntity"/>.</returns>
        Task<List<UsuarioEntity>> ObtenerTodosAsync();

        /// <summary>
        /// Registra una nueva entidad de usuario en el repositorio.
        /// </summary>
        /// <param name="usuario">La entidad de usuario a persistir.</param>
        Task GuardarUsuarioAsync(UsuarioEntity usuario);

        /// <summary>
        /// Verifica si un nombre de usuario ya se encuentra registrado.
        /// </summary>
        /// <param name="username">Nombre de usuario a validar.</param>
        /// <returns>True si el username existe, de lo contrario False.</returns>
        Task<bool> ExisteUsernameAsync(string username);

        /// <summary>
        /// Busca un usuario específico por su identificador único (username).
        /// </summary>
        /// <param name="username">El nombre de usuario a buscar.</param>
        /// <returns>La entidad del usuario si existe, o null si no se encuentra.</returns>
        Task<UsuarioEntity?> ObtenerPorUsernameAsync(string username);

        /// <summary>
        /// Aplica los cambios realizados sobre una entidad de usuario existente.
        /// </summary>
        /// <param name="usuario">La entidad con los datos actualizados.</param>
        Task ActualizarUsuarioAsync(UsuarioEntity usuario);

        /// <summary>
        /// Elimina físicamente el registro de un usuario del repositorio.
        /// </summary>
        /// <param name="usuario">La entidad que se desea remover.</param>
        Task EliminarUsuarioAsync(UsuarioEntity usuario);
    }
}
