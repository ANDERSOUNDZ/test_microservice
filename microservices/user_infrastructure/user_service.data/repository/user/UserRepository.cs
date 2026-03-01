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
    }
}
