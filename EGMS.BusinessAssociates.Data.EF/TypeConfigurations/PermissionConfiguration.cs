using EGMS.BusinessAssociates.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGMS.BusinessAssociates.Data.EF.TypeConfigurations
{
    class PermissionConfiguration : IEntityTypeConfiguration<EGMSPermission>
    {
        public void Configure(EntityTypeBuilder<EGMSPermission> builder)
        {
            builder.Property(oc => oc.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.HasKey(oc => oc.Id);
            
            builder.OwnsOne(phone => phone.PermissionDescription,
                cb => { cb.Property(e => e.Value).HasColumnName("PermissionConfiguration"); });

            builder.OwnsOne(phone => phone.PermissionName,
                cb => { cb.Property(e => e.Value).HasColumnName("PermissionName"); });
        }
    }
}
