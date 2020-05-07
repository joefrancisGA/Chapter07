using EGMS.BusinessAssociates.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGMS.BusinessAssociates.Data.EF.NOTInMemory.TypeConfigurations
{
    class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(contact => contact.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.HasKey(contact => contact.Id);

            builder.OwnsOne(contact => contact.FirstName,
                cb => { cb.Property(e => e.Value).HasColumnName("FirstName"); });

            builder.HasOne(oc => oc.PrimaryPhone)
                .WithMany()
                .HasForeignKey(oc => oc.PrimaryPhoneId);

            builder.HasOne(oc => oc.PrimaryEMail)
                .WithMany()
                .HasForeignKey(oc => oc.PrimaryEmailId);

            builder.HasOne(oc => oc.PrimaryAddress)
                .WithMany()
                .HasForeignKey(oc => oc.PrimaryAddressId);
        }
    }
}
