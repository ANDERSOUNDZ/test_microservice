using Microsoft.EntityFrameworkCore;

namespace user_service.data.context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        //public DbSet<UserEntity> Transactions => Set<UserEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
