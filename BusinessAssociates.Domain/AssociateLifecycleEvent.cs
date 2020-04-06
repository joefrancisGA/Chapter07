using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AssociateLifecycleEvent : Entity<DatabaseId>
    {
        public AssociateId AssociateId { get; set; }
        public DatabaseId LifecycleEventId { get; set; }

        public AssociateLifecycleEvent(Action<object> applier) : base(applier)
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