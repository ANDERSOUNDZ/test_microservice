namespace item_service
{
    /// <summary>
    /// Puerto de salida para la comunicación con el microservicio de Usuarios.
    /// Define el contrato para obtener información de usuarios necesarios para la asignación.
    /// </summary>
    public partial interface IUserClient
    {
        /// <summary>
        /// Recupera la lista de nombres de usuario habilitados para recibir nuevas tareas.
        /// </summary>
        Task<List<string>> ObtenerUsernamesDisponibles();
    }
}
