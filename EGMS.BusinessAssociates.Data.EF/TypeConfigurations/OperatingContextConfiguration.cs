using EGMS.BusinessAssociates.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGMS.BusinessAssociates.Data.EF.TypeConfigurations
{
    class OperatingContextConfiguration : IEntityTypeConfiguration<OperatingContext>
    {
        public void Configure(EntityTypeBuilder<OperatingContext> builder)
        {
            builder.Property(oc => oc.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.HasKey(oc => oc.Id);

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

            builder.OwnsOne(oc => oc.CertificationId,
                cb => { cb.Property(e => e.Value).HasColumnName("CertificationId"); });

            builder.Property(oc => oc.ActingBAType).HasColumnName("ActingBATypeId");
            builder.Property(oc => oc.OperatingContextType).HasColumnName("OperatingContextTypeId");
            builder.Property(oc => oc.ProviderType).HasColumnName("ProviderTypeId");
            builder.Property(oc => oc.Status).HasColumnName("StatusId");
        }
    }
}
