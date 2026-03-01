using item_service.data.context;
using Microsoft.EntityFrameworkCore;

namespace item_service
{
    public partial class ItemRepository : IItemRepository
    {
        private readonly ItemDbContext _context;

        public ItemRepository(ItemDbContext context)
        {
            _context = context;
        }
    }
}