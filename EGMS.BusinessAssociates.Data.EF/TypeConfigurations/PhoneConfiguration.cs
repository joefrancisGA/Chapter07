using EGMS.BusinessAssociates.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGMS.BusinessAssociates.Data.EF.TypeConfigurations
{
    class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.Property(phone => phone.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.HasKey(address => address.Id);

            builder.OwnsOne(oc => oc.UserId,
                cb => { cb.Property(e => e.Value).HasColumnName("UserId"); });
        }
    }
}
