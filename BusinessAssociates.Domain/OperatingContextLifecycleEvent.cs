using System;

namespace BusinessAssociates.Domain
{
    public class OperatingContextLifecycleEvent
    {
        public int OperatingContextId { get; set; }
        public int LifecycleEventId { get; set; }
    }
}