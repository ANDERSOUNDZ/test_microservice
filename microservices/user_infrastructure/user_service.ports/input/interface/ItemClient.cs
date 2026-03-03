namespace user_service
{
    /// <summary>
    /// Puerto de salida encargado de la comunicación con el microservicio de Ítems.
    /// Define las operaciones necesarias para consumir datos externos de forma desacoplada.
    /// </summary>
    public partial interface IItemClient
    {
        /// <summary>
        /// Consulta al microservicio de ítems si un usuario específico tiene tareas con estado pendiente.
        /// </summary>
        /// <param name="username">Nombre del usuario a consultar.</param>
        /// <returns>True si tiene al menos una tarea pendiente; de lo contrario, False.</returns>
        Task<bool> UsuarioTieneTareasPendientesAsync(string username);
    }
}