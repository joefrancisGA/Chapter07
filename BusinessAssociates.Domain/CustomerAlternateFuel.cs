using System;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class CustomerAlternateFuel : Entity<DatabaseId>
    {
        public Customer Customer { get; set; }
        public DatabaseId CustomerId { get; set; }

        public AlternateFuelTypeLookup AlternateFuel { get; set; }
        public int AlternateFuelTypeId { get; set; }


        // ReSharper disable once UnusedMember.Local
        CustomerAlternateFuel()
        {
        }

        public CustomerAlternateFuel(Action<object> applier) : base(applier)
        {
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