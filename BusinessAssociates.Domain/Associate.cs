using BusinessAssociates.Domain.Enums;
using BusinessAssociates.Domain.ValueObjects;

namespace BusinessAssociates.Domain
{
    public class Associate
    {
        public AssociateId Id { get; set; }
        
        public DUNSNumber DUNSNumber { get; set; }
        public LongName LongName { get; set; }
        public ShortName ShortName { get; set; }
        public AssociateType AssociateType { get; set; }
        public Status Status { get; set; }

        public bool IsInternal { get; set; }
        public bool IsDeactivating { get; set; }
        public bool IsParent { get; set; }
        public bool IsActive { get; set; }
    }
}