using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class OperatingContextLifecycleEvent : Entity<DatabaseId>
    {
        public DatabaseId OperatingContextId { get; set; }
        public DatabaseId LifecycleEventId { get; set; }

        public OperatingContextLifecycleEvent(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}