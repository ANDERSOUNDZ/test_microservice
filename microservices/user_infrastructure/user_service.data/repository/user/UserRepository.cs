using Microsoft.EntityFrameworkCore;
using user_service.domain.entities;

namespace user_service
{
    public partial class UserRepository : IUserRepository
    {
        public async Task<List<UsuarioEntity>> ObtenerTodosAsync()
        => await _context.Usuarios.ToListAsync();

        public async Task GuardarUsuarioAsync(UsuarioEntity usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExisteUsernameAsync(string username)
            => await _context.Usuarios.AnyAsync(u => u.Username == username);

        public async Task<UsuarioEntity?> ObtenerPorUsernameAsync(string username)
        => await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == username);

        public async Task ActualizarUsuarioAsync(UsuarioEntity usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarUsuarioAsync(UsuarioEntity usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
