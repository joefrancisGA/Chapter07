using System.Collections.Generic;

namespace BusinessAssociates.Domain
{
    public class Role
    {
        public int Id { get; set; }
        public IEnumerable<Permission> Permissions { get; set; }
    }
}