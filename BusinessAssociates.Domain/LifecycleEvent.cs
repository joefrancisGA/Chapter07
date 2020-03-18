
using System;
using BusinessAssociates.Domain.Enums;

namespace BusinessAssociates.Domain
{
    public class LifecycleEvent
    {
        public int Id { get; set; }

        public LifecycleEventType LifecycleEventType { get; set; }
        public LifecycleEventStatus LifecycleEventStatus { get; set; }
        public string Comments { get; set; }
        public bool IsInitiator { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
