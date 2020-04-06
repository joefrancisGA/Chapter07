using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class Roles
    {
        public Roles()
        {
            OperatingContexts = new HashSet<OperatingContexts>();
            RoleEgmspermissions = new HashSet<RoleEgmspermissions>();
            UserOperatingContexts = new HashSet<UserOperatingContexts>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<OperatingContexts> OperatingContexts { get; set; }
        public virtual ICollection<RoleEgmspermissions> RoleEgmspermissions { get; set; }
        public virtual ICollection<UserOperatingContexts> UserOperatingContexts { get; set; }
    }
}
