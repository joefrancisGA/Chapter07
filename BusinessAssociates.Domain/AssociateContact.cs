using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AssociateContact : Entity<int>
    {
        public AssociateContact() { }
        public AssociateContact(Action<object> applier) : base(applier) { }

        public Associate Associate { get; set; }
        public int AssociateId { get; set; }

        public User Contact { get; set; }
        public int ContactId { get; set; }


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