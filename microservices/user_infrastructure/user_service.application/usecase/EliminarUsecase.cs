namespace user_service
{
    public partial class UserUseCase : IUserUseCase
    {
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
