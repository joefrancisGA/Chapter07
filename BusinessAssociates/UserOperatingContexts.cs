using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class UserOperatingContexts
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int FacilityId { get; set; }
        public int PrincipalId { get; set; }
        public int UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Associates Principal { get; set; }
        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}
