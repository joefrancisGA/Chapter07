using System;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class LifecycleEvent : Entity<DatabaseId>
    {
        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }

        public LifecycleEventType LifecycleEventType { get; set; }
        public LifecycleEventStatus LifecycleEventStatus { get; set; }
        public Comments Comments { get; set; }
        public bool IsInitiator { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public LifecycleEvent(Action<object> applier) : base(applier)
        {
        }
    }
}
