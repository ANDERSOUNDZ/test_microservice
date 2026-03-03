using Microsoft.EntityFrameworkCore;
using user_service.domain.entities;

namespace user_service
{
    /// <summary>
    /// Adaptador de salida para la persistencia de datos de usuarios.
    /// Implementa el acceso a datos utilizando Entity Framework Core.
    /// </summary>
    public partial class UserRepository : IUserRepository
    {
        /// <summary>Consulta todos los registros de usuarios en la base de datos.</summary>
        public async Task<List<UsuarioEntity>> ObtenerTodosAsync()
        => await _context.Usuarios.ToListAsync();

        /// <summary>Persiste un nuevo usuario en el almacén de datos.</summary>
        public async Task GuardarUsuarioAsync(UsuarioEntity usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        /// <summary>Verifica la existencia de un usuario por su identificador único (username).</summary>
        public async Task<bool> ExisteUsernameAsync(string username)
            => await _context.Usuarios.AnyAsync(u => u.Username == username);

        /// <summary>Recupera la entidad completa de un usuario por su username.</summary>
        public async Task<UsuarioEntity?> ObtenerPorUsernameAsync(string username)
        => await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == username);

        /// <summary>Actualiza los cambios de una entidad de usuario existente.</summary>
        public async Task ActualizarUsuarioAsync(UsuarioEntity usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        /// <summary>Remueve físicamente el registro de un usuario de la base de datos.</summary>
        public async Task EliminarUsuarioAsync(UsuarioEntity usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
