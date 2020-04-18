using System;
using System.Collections.Generic;
using System.Dynamic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class Role : Entity<int>
    {
        private Role()
        {
            Initialize();
        }

        public Role(Action<object> applier) : base(applier)
        {
            Initialize();
        }


        private void Initialize()
        {
            Permissions = new HashSet<EGMSPermission>();
            OperatingContexts = new HashSet<OperatingContext>();
            RoleEGMSPermissions = new HashSet<RoleEGMSPermission>();
            UserOperatingContexts = new HashSet<UserOperatingContext>();
        }

        public RoleName RoleName { get; set; }
        public RoleDescription RoleDescription { get; set; }
        public bool IsActive { get; set; }


        // Collections
        public HashSet<EGMSPermission> Permissions { get; set; }
        public HashSet<OperatingContext> OperatingContexts { get; set; }
        public HashSet<RoleEGMSPermission> RoleEGMSPermissions { get; set; }
        public HashSet<UserOperatingContext> UserOperatingContexts { get; set; }


        public static Role Create(int roleId, RoleName roleName, RoleDescription roleDescription, bool isActive)
        {
            return new Role {RoleName = roleName, RoleDescription = roleDescription, IsActive = isActive};
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