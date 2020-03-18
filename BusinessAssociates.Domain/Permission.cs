

namespace BusinessAssociates.Domain
{
    public class Permission
    {
        public int Id { get; set; }

        public string PermissionName { get; set; }
        public string PermissionDescription { get; set; }
        public bool IsActive { get; set; }

    }
}