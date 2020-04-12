using EGMS.BusinessAssociates.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGMS.BusinessAssociates.Data.EF.InMemory.TypeConfigurations
{
    class AssociateOperatingContextConfiguration : IEntityTypeConfiguration<AssociateOperatingContext>
    {
        public void Configure(EntityTypeBuilder<AssociateOperatingContext> builder)
        {
            builder.Property(aoc => aoc.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.HasKey(role => role.Id);
        }
    }
}
