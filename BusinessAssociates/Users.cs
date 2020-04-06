using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class Users
    {
        public Users()
        {
            AgentUsers = new HashSet<AgentUsers>();
            AssociateUsers = new HashSet<AssociateUsers>();
            UserOperatingContexts = new HashSet<UserOperatingContexts>();
        }

        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Imdmsid { get; set; }
        public string DepartmentCode { get; set; }
        public bool IsInternal { get; set; }
        public bool HasEgmsaccess { get; set; }
        public DateTime? DeactivationDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Contacts Contact { get; set; }
        public virtual ICollection<AgentUsers> AgentUsers { get; set; }
        public virtual ICollection<AssociateUsers> AssociateUsers { get; set; }
        public virtual ICollection<UserOperatingContexts> UserOperatingContexts { get; set; }
    }
}
