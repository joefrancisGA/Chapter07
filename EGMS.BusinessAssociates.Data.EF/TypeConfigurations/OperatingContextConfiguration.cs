using EGMS.BusinessAssociates.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGMS.BusinessAssociates.Data.EF.TypeConfigurations
{
    class OperatingContextConfiguration : IEntityTypeConfiguration<OperatingContext>
    {
        public void Configure(EntityTypeBuilder<OperatingContext> builder)
        {
            builder.OwnsOne(oc => oc.Id,
                cb => { cb.Property(e => e.Value).HasColumnName("Id"); });

            builder.OwnsOne(oc => oc.FacilityId,
                cb => { cb.Property(e => e.Value).HasColumnName("FacilityId"); });

            builder.OwnsOne(oc => oc.ThirdPartySupplierId,
                cb => { cb.Property(e => e.Value).HasColumnName("ThirdPartySupplierId"); });

            builder.OwnsOne(oc => oc.PrimaryEmailId,
                cb => { cb.Property(e => e.Value).HasColumnName("PrimaryEMailId"); });
            
            builder.OwnsOne(oc => oc.PrimaryPhoneId,
                cb => { cb.Property(e => e.Value).HasColumnName("PrimaryPhoneId"); });

            builder.OwnsOne(oc => oc.PrimaryAddressId,
                cb => { cb.Property(e => e.Value).HasColumnName("PrimaryAddressId"); });
        }
    }
}
