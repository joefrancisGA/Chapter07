using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Role : Entity<int>
    {
        public RoleName RoleName { get; set; }
        public RoleDescription RoleDescription { get; set; }


        // Collections
        public IEnumerable<EGMSPermission> Permissions { get; set; }


        public Role() { }

        public Role(Action<object> applier) : base(applier) { }
        
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