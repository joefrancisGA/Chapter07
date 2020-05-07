using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class OperatingContextRole : Entity<int>
    {
        public OperatingContextRole() { }
        public OperatingContextRole(Action<object> applier) : base(applier) { }

        public OperatingContextRole(int operatingContextId, int roleId)
        {
            RoleId = roleId;
            OperatingContextId = operatingContextId;
        }


        public OperatingContext OperatingContext { get; set; }
        public int OperatingContextId { get; set; }

        public Role Role { get; set; }
        public int RoleId { get; set; }


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