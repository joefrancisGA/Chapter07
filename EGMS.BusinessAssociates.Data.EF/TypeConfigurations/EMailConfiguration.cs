using EGMS.BusinessAssociates.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGMS.BusinessAssociates.Data.EF.TypeConfigurations
{
    class EMailConfiguration : IEntityTypeConfiguration<EMail>
    {
        public void Configure(EntityTypeBuilder<EMail> builder)
        {
            builder.Property(email => email.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.HasKey(email => email.Id);

            builder.OwnsOne(email => email.EMailAddress,
                cb => { cb.Property(e => e.Value).HasColumnName("EMailAddress"); });
        }
    }
}
