

using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class Permission
    {
        public DatabaseId Id { get; set; }

        public PermissionName PermissionName { get; set; }
        public PermissionDescription PermissionDescription { get; set; }
        public bool IsActive { get; set; }
    }
}