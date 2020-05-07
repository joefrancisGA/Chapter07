using System;
using EGMS.BusinessAssociates.Framework;


namespace EGMS.BusinessAssociates.Domain
{
    public class RoleEGMSPermission : Entity<int>
    {
        private RoleEGMSPermission() { }

        public RoleEGMSPermission(Action<object> applier) : base(applier)
        {
        }

        public Role Role { get; set; }
        public int RoleId { get; set; }

        public EGMSPermission EGMSPermission { get; set; }
        public int EGMSPermissionId { get; set; }


        public static RoleEGMSPermission Create(int roleEGMSPermissionId, int roleId, int egmsPermissionId)
        {
            return new RoleEGMSPermission
            {
                Id = roleEGMSPermissionId, RoleId = roleId, EGMSPermissionId = egmsPermissionId
            };
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            ParentHandler = parentHandler;
        }
    }
}