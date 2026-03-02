
using item_service.domain.entities;
using item_service.ports.dto.item;
using Microsoft.EntityFrameworkCore;

namespace item_service
{
    public partial class ItemRepository : IItemRepository
    {
        public async Task<ItemTrabajoEntity?> ObtenerPorIdAsync(Guid id)
        {
            return await _context.ItemsTrabajo
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ItemTrabajoEntity>> ObtenerPendientesPorUsuarioAsync(string username)
        {
            return await _context.ItemsTrabajo
                .Where(x => x.UsuarioAsignado == username && x.Estado == "Pendiente")
                .ToListAsync();
        }

        public async Task ActualizarItemAsync(ItemTrabajoEntity item)
        {
            _context.ItemsTrabajo.Update(item);
            await _context.SaveChangesAsync();
        }
        public async Task<List<ResumenUsuario>> ObtenerCargaTrabajoUsuariosAsync()
        {
            return await _context.ItemsTrabajo
                .GroupBy(i => i.UsuarioAsignado)
                .Select(g => new ResumenUsuario
                {
                    Username = g.Key,
                    TotalPendientes = g.Count(i => i.Estado == "Pendiente"),
                    TotalAltaRelevancia = g.Count(i => i.Estado == "Pendiente" && i.EsAltaRelevancia)
                })
                .ToListAsync();
        }
        public async Task<List<ItemTrabajoEntity>> ObtenerTodosAsync()
        {
            return await _context.ItemsTrabajo
                .OrderBy(x => x.UsuarioAsignado) 
                .ThenBy(x => x.FechaEntrega)
                .ToListAsync();
        }

        public async Task GuardarItemAsync(ItemTrabajoEntity item)
        {
            await _context.ItemsTrabajo.AddAsync(item);
            await _context.SaveChangesAsync();
        }
    }
}
