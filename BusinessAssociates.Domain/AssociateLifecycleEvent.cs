using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AssociateLifecycleEvent : Entity<DatabaseId>
    {
        public AssociateLifecycleEvent() { }
        public AssociateLifecycleEvent(Action<object> applier) : base(applier) { }

        public Associate Associate { get; set; }
        public int AssociateId { get; set; }

        public LifecycleEvent LifecycleEvent { get; set; }
        public int LifecycleEventId { get; set; }
        

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