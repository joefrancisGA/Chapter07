using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class UserOperatingContext : Entity<int>
    {
        public UserOperatingContext() {}
        public UserOperatingContext(Action<object> applier) : base(applier) { }

        public Role Role { get; set; }
        public int RoleId { get; set; }

        public DatabaseId FacilityId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Associate Principal { get; set; }
        public int PrincipalId { get; set; }

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