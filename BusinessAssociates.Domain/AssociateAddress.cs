using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AssociateAddress : Entity<DatabaseId>
    {
        public AssociateAddress() { }
        public AssociateAddress(Action<object> applier) : base(applier) { }

        public Associate Associate { get; set; }
        public DatabaseId AssociateId { get; set; }

        public Address Address { get; set; }
        public DatabaseId AddressId { get; set; }


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