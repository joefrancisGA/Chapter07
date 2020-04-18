using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;


namespace EGMS.BusinessAssociates.Domain
{
    public class EGMSPermission : Entity<int>
    {
        private EGMSPermission() { }
        public EGMSPermission(Action<object> applier) : base(applier)  { }


        public PermissionName PermissionName { get; set; }
        public PermissionDescription PermissionDescription { get; set; }
        public bool IsActive { get; set; }


        public static EGMSPermission Create(int permissionId, PermissionName permissionName, PermissionDescription permissionDescription, 
            bool isActive)
        {
            return new EGMSPermission
            {
                Id = permissionId, PermissionName = permissionName, PermissionDescription = permissionDescription, IsActive = isActive
            };
        }

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