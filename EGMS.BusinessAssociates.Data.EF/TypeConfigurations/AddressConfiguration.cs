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

            builder.HasKey(address => address.Id);

            builder.OwnsOne(address => address.Address1,
                cb => { cb.Property(e => e.Value).HasColumnName("Address1"); });

            builder.OwnsOne(address => address.Address2,
                cb => { cb.Property(e => e.Value).HasColumnName("Address2"); });

            builder.OwnsOne(address => address.Address3,
                cb => { cb.Property(e => e.Value).HasColumnName("Address3"); });

            builder.OwnsOne(address => address.Address4,
                cb => { cb.Property(e => e.Value).HasColumnName("Address4"); });

            builder.OwnsOne(address => address.Attention,
                cb => { cb.Property(e => e.Value).HasColumnName("Attention"); });

            builder.OwnsOne(address => address.City,
                cb => { cb.Property(e => e.Value).HasColumnName("City"); });
            
            builder.Property(address => address.Comments).HasColumnName("Comments"); 

            builder.OwnsOne(address => address.PostalCode,
                cb => { cb.Property(e => e.Value).HasColumnName("PostalCode"); });
        }
    }
}
