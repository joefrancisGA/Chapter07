using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using EGMS.Facilities.Domain.Models;

namespace EGMS.Facilities.Data.EF.TypeConfigurations
{
    class FacilityDetailConfiguration : IEntityTypeConfiguration<Domain.Models.FacilityDetail>
    {
        public void Configure(EntityTypeBuilder<FacilityDetail> builder)
        {
            builder.Property("Id")
                .HasColumnName("FacilityDetailId")
                .UseIdentityColumn();

            builder.HasKey("Id");

            //builder.OwnsOne(x => x.Id, cb =>
            //{
            //    cb.Property(e => e.Value)
            //        .HasColumnName("FacilityDetailId")
            //        .UseIdentityColumn();
            //});

            builder.OwnsOne(x => x.StartDate,
                            cb =>
                            {
                                cb.Property(e => e.Value)
                                  .HasColumnName("EffectiveStartDate");
                            });

            builder.OwnsOne(x => x.EndDate,
                            cb =>
                            {
                                cb.Property(e => e.Value)
                                  .HasColumnName("EffectiveEndDate");
                            });

            builder.OwnsOne(x => x.HasAutoAssignShipperPools, 
                            cb => 
                            { 
                                cb.Property(e => e.Value)
                                  .HasColumnName("HasAutoAssignShipperPools"); 
                            });

            builder.OwnsOne(x => x.HasMultipleContractsPerShipper, 
                            cb => 
                            { 
                                cb.Property(e => e.Value).HasColumnName("HasMultipleContractsPerShipper"); 
                            });

            builder.OwnsOne(x => x.ShipperMustHaveTitle,
                            cb =>
                            {
                                cb.Property(e => e.Value).HasColumnName("ShipperMustHaveTitle");
                            });

            builder.Property(x => x.ConfirmationLevelID)
                .HasColumnName("ConfirmationLevelID");

            builder.Property(x => x.DisplayTimeZoneID)
                .HasColumnName("DisplayTimeZoneID");

            builder.Property(x => x.PoolTypeID)
                .HasColumnName("PoolTypeID");

            builder.ToTable("tblFacilityDetail");

        }
    }
}
