using item_service.domain.entities;
using Microsoft.EntityFrameworkCore;

namespace item_service.data.context
{
    public class ItemDbContext : DbContext
    {
        public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options) { }

        public DbSet<ItemTrabajoEntity> ItemsTrabajo => Set<ItemTrabajoEntity>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ItemDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
