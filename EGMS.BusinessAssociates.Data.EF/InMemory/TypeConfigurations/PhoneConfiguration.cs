using EGMS.BusinessAssociates.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGMS.BusinessAssociates.Data.EF.InMemory.TypeConfigurations
{
    class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.Property(phone => phone.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.HasKey(phone => phone.Id);

            builder.OwnsOne(phone => phone.UserId,
                cb => { cb.Property(e => e.Value).HasColumnName("UserId"); });

            builder.OwnsOne(phone => phone.Extension,
                cb => { cb.Property(e => e.Value).HasColumnName("Extension"); });
        }
    }
}
