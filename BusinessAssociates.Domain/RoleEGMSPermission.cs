using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;


namespace EGMS.BusinessAssociates.Domain
{
    public class RoleEGMSPermission : Entity<DatabaseId>
    {
        public RoleEGMSPermission() { }
        public RoleEGMSPermission(Action<object> applier) : base(applier) { }

        public Role Role { get; set; }
        public int RoleId { get; set; }

        public List<EGMSPermission> EGMSPermissions { get; set; }

        
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