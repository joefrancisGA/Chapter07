using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;


namespace EGMS.BusinessAssociates.Domain
{
    public class RoleEGMSPermission : Entity<DatabaseId>
    {
        public Role Role { get; set; }
        public DatabaseId RoleId { get; set; }

        public EGMSPermission EGMSPermission { get; set; }
        public DatabaseId PermissionId { get; set; }


        public RoleEGMSPermission() { }

        public RoleEGMSPermission(Action<object> applier) : base(applier) { }

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