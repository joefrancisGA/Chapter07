using System.Collections.Generic;
using BusinessAssociates.Domain.Enums;
using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class AssociateOperatingContext
    {
        public int AssociateId { get; set; }
        public int OperatingContextId { get; set; }
    }
}