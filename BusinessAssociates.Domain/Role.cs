using System.Collections.Generic;
using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class Role
    {
        public DatabaseId Id { get; set; }

        public RoleName RoleName { get; set; }
        public RoleDescription RoleDescription { get; set; }

        // Collections
        public IEnumerable<Permission> Permissions { get; set; }
    }
}