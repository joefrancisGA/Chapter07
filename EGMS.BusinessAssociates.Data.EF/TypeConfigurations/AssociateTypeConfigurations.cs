using EGMS.BusinessAssociates.Domain;
using Microsoft.EntityFrameworkCore;

namespace EGMS.BusinessAssociates.Data.EF.TypeConfigurations
{
    class AssociateTypeConfigurations
    {
        public static void ConfigureTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AssociateConfiguration());
            modelBuilder.ApplyConfiguration(new OperatingContextConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new PhoneConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new EMailConfiguration());
            modelBuilder.ApplyConfiguration(new AssociateOperatingContextConfiguration());
            modelBuilder.ApplyConfiguration(new AgentRelationshipConfiguration());
        }
    }
}
