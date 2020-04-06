using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class RoleEgmspermissions
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int EgmspermissionId { get; set; }

        public virtual Egmspermissions Egmspermission { get; set; }
        public virtual Roles Role { get; set; }
    }
}
