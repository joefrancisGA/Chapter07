using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class OperatingContextLifecycleEvent : Entity<DatabaseId>
    {
        public OperatingContextLifecycleEvent() { }
        public OperatingContextLifecycleEvent(Action<object> applier) : base(applier) { }

        public OperatingContext OperatingContext { get; set; }
        public int OperatingContextId { get; set; }

        public LifecycleEvent LifeCycleEvent { get; set; }
        public int LifecycleEventId { get; set; }
        

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