using EGMS.BusinessAssociates.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGMS.BusinessAssociates.Data.EF.TypeConfigurations
{
    class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.Property(address => address.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            //builder.OwnsOne(address => address.Id,
            //    cb => { cb.Property(e => e.Value).HasColumnName("Id"); });

            builder.HasKey(address => address.Id);
        }
    }
}
