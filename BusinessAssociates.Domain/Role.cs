using System.Collections.Generic;

namespace BusinessAssociates.Domain
{
    public class Role
    {
        public int Id { get; set; }

        public string RoleName { get; set; }
        public string RoleDescription { get; set; }

        // Collections
        public IEnumerable<Permission> Permissions { get; set; }
    }
}