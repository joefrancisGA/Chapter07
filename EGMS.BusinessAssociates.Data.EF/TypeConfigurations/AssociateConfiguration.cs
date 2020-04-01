using EGMS.BusinessAssociates.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGMS.BusinessAssociates.Data.EF.TypeConfigurations
{
    class AssociateConfiguration : IEntityTypeConfiguration<Associate>
    {
        public void Configure(EntityTypeBuilder<Associate> builder)
        {
            builder.Property(associate => associate.Id).HasColumnName("ID").ValueGeneratedOnAdd();
            builder.HasKey(associate => associate.Id);

            builder.OwnsOne(associate => associate.DUNSNumber,
                cb => { cb.Property(e => e.Value).HasColumnName("DUNSNumber"); });

            builder.OwnsOne(associate => associate.ShortName, 
                cb => { cb.Property(e => e.Value).HasColumnName("ShortName"); });

            builder.OwnsOne(associate => associate.LongName, 
                cb => { cb.Property(e => e.Value).HasColumnName("LongName"); });

            builder.Property(associate => associate.AssociateType).HasColumnName("BusinessAssociateType");
            builder.Property(associate => associate.IsActive).HasColumnName("IsActive");
            builder.Property(associate => associate.IsDeactivating).HasColumnName("IsDeactivating");
            builder.Property(associate => associate.IsParent).HasColumnName("IsParent");
            builder.Property(associate => associate.Status).HasColumnName("Status");
        }
    }
}
