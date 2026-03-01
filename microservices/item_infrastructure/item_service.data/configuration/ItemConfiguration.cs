using item_service.domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace item_service.domain.configuration
{
    public class ItemConfiguration : IEntityTypeConfiguration<ItemTrabajoEntity>
    {
        public void Configure(EntityTypeBuilder<ItemTrabajoEntity> builder)
        {
            builder.ToTable("ItemsTrabajo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Estado).IsRequired().HasDefaultValue("Pendiente");
            builder.Property(x => x.UsuarioAsignado).IsRequired();
        }
    }
}