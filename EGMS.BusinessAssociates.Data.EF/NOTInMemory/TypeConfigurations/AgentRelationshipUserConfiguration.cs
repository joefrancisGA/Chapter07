using EGMS.BusinessAssociates.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGMS.BusinessAssociates.Data.EF.InMemory.TypeConfigurations
{
    class AgentRelationshipUserConfiguration : IEntityTypeConfiguration<AgentRelationshipUser>
    {
        public void Configure(EntityTypeBuilder<AgentRelationshipUser> builder)
        {
            builder.Property(aru => aru.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.HasKey(ar => ar.Id);

            builder.HasOne(oc => oc.AgentRelationship)
                .WithMany()
                .HasForeignKey(oc => oc.AgentRelationshipId);
        }
    }
}
