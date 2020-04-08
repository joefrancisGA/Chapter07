using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class User : Entity<int>
    {
        public User() { }
        public User(Action<object> applier) : base(applier) { }

        public Contact Contact { get; set; }
        public IDMSSID IDMSSID { get; set; }
        public DepartmentCode DepartmentCode { get; set; }

        public bool IsInternal { get; set; }
        public bool IsActive { get; set; }
        public bool HasEGMSAccess { get; set; }
        public DateTime DeactivationDate { get; set; }

        public List<AgentUser> AgentUsers { get; set; }
        public List<AssociateUser> AssociateUsers { get; set; }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}