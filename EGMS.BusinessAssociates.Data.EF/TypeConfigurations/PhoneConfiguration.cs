using EGMS.BusinessAssociates.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGMS.BusinessAssociates.Data.EF.TypeConfigurations
{
    class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.OwnsOne(oc => oc.Id,
                cb => { cb.Property(e => e.Value).HasColumnName("Id"); });

            builder.OwnsOne(oc => oc.UserId,
                cb => { cb.Property(e => e.Value).HasColumnName("UserId"); });
        }
    }
}
