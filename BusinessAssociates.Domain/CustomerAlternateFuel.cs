using System;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class CustomerAlternateFuel : Entity<int>
    {
        // ReSharper disable once UnusedMember.Local
        CustomerAlternateFuel() { }
        public CustomerAlternateFuel(Action<object> applier) : base(applier) { }

        public CustomerAlternateFuel(int customerId, int alternateFuelTypeId)
        {
            CustomerId = customerId;
            AlternateFuelTypeId = alternateFuelTypeId;
        }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public AlternateFuelTypeLookup AlternateFuel { get; set; }
        public int AlternateFuelTypeId { get; set; }
        
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