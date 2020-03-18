using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class RolePermission
    {
        public DatabaseId RoleId { get; set; }
        public DatabaseId PermissionId { get; set; }
    }
}