using EGMS.BusinessAssociates.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGMS.BusinessAssociates.Data.EF.TypeConfigurations
{
    class OperatingContextConfiguration : IEntityTypeConfiguration<OperatingContext>
    {
        public void Configure(EntityTypeBuilder<OperatingContext> builder)
        {
            builder.OwnsOne(oc => oc.FacilityId,
                cb => { cb.Property(e => e.Value).HasColumnName("FacilityId"); });
        }
    }
}
