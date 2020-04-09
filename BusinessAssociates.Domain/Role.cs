using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Role : Entity<int>
    {
        public Role() { }
        public Role(Action<object> applier) : base(applier) { }

        public RoleName RoleName { get; set; }
        public RoleDescription RoleDescription { get; set; }


        // Collections
        public IEnumerable<EGMSPermission> Permissions { get; set; }
        public List<OperatingContext> OperatingContexts { get; set; }
        public List<RoleEGMSPermission> RoleEGMSPermissions { get; set; }
        public List<UserOperatingContext> UserOperatingContexts { get; set; }


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