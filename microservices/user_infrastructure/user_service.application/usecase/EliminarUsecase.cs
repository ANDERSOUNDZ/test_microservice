namespace user_service
{
    public partial class UserUseCase : IUserUseCase
    {
        /// <summary>
        /// Elimina un usuario previa verificación de integridad referencial 
        /// consultando al microservicio de Ítems vía HttpClient.
        /// </summary>
        /// <param name="username">Nombre de usuario a eliminar.</param>
        public async Task ExecuteAsync(string username)
        {
            var usuario = await _userRepository.ObtenerPorUsernameAsync(username);
            if (usuario == null) throw new Exception("Usuario no encontrado");

            bool tieneTareas = await _itemClient.UsuarioTieneTareasPendientesAsync(username);

            if (tieneTareas)
            {
                throw new Exception("No se puede eliminar: El usuario tiene tareas pendientes asignadas.");
            }

            await _userRepository.EliminarUsuarioAsync(usuario);
        }
    }
}
