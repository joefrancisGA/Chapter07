using System;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class LifecycleEvent : Entity<DatabaseId>
    {
        public LifecycleEvent() { }
        public LifecycleEvent(Action<object> applier) : base(applier) { }

        public LifecycleEventType LifecycleEventType { get; set; }
        public LifecycleEventStatus LifecycleEventStatus { get; set; }
        public string Comments { get; set; }
        public bool IsInitiator { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


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
