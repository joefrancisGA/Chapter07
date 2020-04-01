using EGMS.BusinessAssociates.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGMS.BusinessAssociates.Data.EF.TypeConfigurations
{
    class AgentRelationshipConfiguration : IEntityTypeConfiguration<AgentRelationship>
    {
        public void Configure(EntityTypeBuilder<AgentRelationship> builder)
        {
            builder.Property(ar => ar.Id)
                .HasColumnName("ID")
                .ValueGeneratedOnAdd();

            builder.HasKey(ar => ar.Id);

            builder.Ignore(ar => ar.Principal);
            builder.Ignore(ar => ar.Agent);
        }
    }
}
