using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Framework;


namespace EGMS.BusinessAssociates.Domain
{
    public class RoleEGMSPermission : Entity<int>
    {
        public RoleEGMSPermission()
        {
            EGMSPermissions = new HashSet<EGMSPermission>();
        }

        public RoleEGMSPermission(Action<object> applier) : base(applier)
        {
            EGMSPermissions = new HashSet<EGMSPermission>();
        }

        public Role Role { get; set; }
        public int RoleId { get; set; }

        public HashSet<EGMSPermission> EGMSPermissions { get; set; }

        
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