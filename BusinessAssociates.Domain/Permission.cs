using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;


namespace EGMS.BusinessAssociates.Domain
{
    public class Permission : Entity<int>
    {
        public PermissionName PermissionName { get; set; }
        public PermissionDescription PermissionDescription { get; set; }
        public bool IsActive { get; set; }

        
        public Permission() { }

        public Permission(Action<object> applier) : base(applier)
        {
        }
        
        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}