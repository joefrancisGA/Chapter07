﻿using EGMS.BusinessAssociates.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGMS.BusinessAssociates.Data.EF.TypeConfigurations
{
    class OperatingContextConfiguration : IEntityTypeConfiguration<OperatingContext>
    {
        public void Configure(EntityTypeBuilder<OperatingContext> builder)
        {
            builder.Property(oc => oc.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.HasKey(oc => oc.Id);

            builder.OwnsOne(oc => oc.FacilityId,
                cb => { cb.Property(e => e.Value).HasColumnName("FacilityId"); });

            builder.Property(oc => oc.ThirdPartySupplierId).HasColumnName("ThirdPartySupplierId");

            builder.OwnsOne(oc => oc.CertificationId,
                cb => { cb.Property(e => e.Value).HasColumnName("CertificationId"); });

            builder.Property(oc => oc.ActingBAType).HasColumnName("ActingBATypeId");
            builder.Property(oc => oc.OperatingContextType).HasColumnName("OperatingContextTypeId");
            builder.Property(oc => oc.ProviderType).HasColumnName("ProviderTypeId");
            builder.Property(oc => oc.Status).HasColumnName("StatusId");
            builder.HasOne(oc => oc.PrimaryAddress)
                .WithMany()
                .HasForeignKey(oc => oc.PrimaryAddressId);
            builder.HasOne(oc => oc.PrimaryEmail)
                .WithMany()
                .HasForeignKey(oc => oc.PrimaryEmailId);
            builder.HasOne(oc => oc.PrimaryPhone)
                .WithMany()
                .HasForeignKey(oc => oc.PrimaryPhoneId);
        }
    }
}
