
using System;
using BusinessAssociates.Domain.Enums;
using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class LifecycleEvent
    {
        public DatabaseId Id { get; set; }

        public LifecycleEventType LifecycleEventType { get; set; }
        public LifecycleEventStatus LifecycleEventStatus { get; set; }
        public Comments Comments { get; set; }
        public bool IsInitiator { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
