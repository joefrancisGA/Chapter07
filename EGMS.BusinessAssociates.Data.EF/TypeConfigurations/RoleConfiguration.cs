using EGMS.BusinessAssociates.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGMS.BusinessAssociates.Data.EF.TypeConfigurations
{
    class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(role => role.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.HasKey(role => role.Id);

            builder.OwnsOne(role => role.RoleDescription,
                cb => { cb.Property(e => e.Value).HasColumnName("RoleDescription"); });

            builder.OwnsOne(role => role.RoleName,
                cb => { cb.Property(e => e.Value).HasColumnName("RoleName"); });
        }
    }
}
