using EGMS.BusinessAssociates.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EGMS.BusinessAssociates.Data.EF.TypeConfigurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.HasKey(user => user.Id);

            builder.OwnsOne(user => user.DepartmentCode,
                cb => { cb.Property(e => e.Value).HasColumnName("DepartmentCode"); });
        }
    }
}
