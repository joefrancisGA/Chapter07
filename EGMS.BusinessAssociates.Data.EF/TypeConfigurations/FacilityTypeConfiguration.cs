using EGMS.Facilities.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EGMS.Facilities.Data.EF.TypeConfigurations
{
    class FacilityTypeConfiguration : IEntityTypeConfiguration<FacilityType>
    {
        public void Configure(EntityTypeBuilder<FacilityType> builder)
        {
            builder.Property("FacilityTypeId").HasDefaultValue();
            builder.HasKey(x => x.FacilityTypeId);
            builder.OwnsOne(x => x.Id, cb =>
            {
                cb.Property(e => e.Value)
                    .HasColumnName("FacilityTypeId")
                    .HasDefaultValue();
            });
            builder.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("TypeName"); });
            builder.OwnsOne(x => x.Desc, cb => { cb.Property(e => e.Value).HasColumnName("TypeDesc"); });
            builder.ToTable("tblFacilityType");
        }
    }
}
