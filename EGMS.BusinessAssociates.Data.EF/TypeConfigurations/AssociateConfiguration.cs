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
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.DUNSNumber,
                cb => { cb.Property(e => e.Value).HasColumnName("DUNSNumber"); });

            builder.OwnsOne(x => x.ShortName, 
                cb => { cb.Property(e => e.Value).HasColumnName("ShortName"); });

            builder.OwnsOne(x => x.LongName, 
                cb => { cb.Property(e => e.Value).HasColumnName("LongName"); });

            builder.Property(x => x.AssociateType).HasColumnName("BusinessAssociateType");
            builder.Property(x => x.IsActive).HasColumnName("IsActive");
            builder.Property(x => x.IsDeactivating).HasColumnName("IsDeactivating");
            builder.Property(x => x.IsParent).HasColumnName("IsParent");
            builder.Property(x => x.Status).HasColumnName("Status");
        }
    }
}
