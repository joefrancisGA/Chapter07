using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;

namespace EGMS.BusinessAssociates.Domain
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