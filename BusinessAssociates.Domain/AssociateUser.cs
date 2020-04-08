using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AssociateUser : Entity<DatabaseId>
    {
        public AssociateUser() { }
        public AssociateUser(Action<object> applier) : base(applier) { }

        public Associate Associate { get; set; }
        public AssociateId AssociateId { get; set; }

        public User User { get; set; }
        public DatabaseId UserId { get; set; }


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