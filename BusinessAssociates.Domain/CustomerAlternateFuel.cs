using System;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class CustomerAlternateFuel : Entity<DatabaseId>
    {
        public DatabaseId CustomerId { get; set; }
        public AlternateFuelType AlternateFuel { get; set; }

        public CustomerAlternateFuel(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}