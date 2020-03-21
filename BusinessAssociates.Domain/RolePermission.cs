using EGMS.BusinessAssociates.Domain.ValueObjects;

namespace EGMS.BusinessAssociates.Domain
{
    public class RolePermission
    {
        public DatabaseId RoleId { get; set; }
        public DatabaseId PermissionId { get; set; }
    }
}