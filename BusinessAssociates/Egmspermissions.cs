using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class Egmspermissions
    {
        public Egmspermissions()
        {
            RoleEgmspermissions = new HashSet<RoleEgmspermissions>();
        }

        public int Id { get; set; }
        public string PermissionName { get; set; }
        public string PermissionDescription { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<RoleEgmspermissions> RoleEgmspermissions { get; set; }
    }
}
