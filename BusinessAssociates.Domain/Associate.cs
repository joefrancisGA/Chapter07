using BusinessAssociates.Domain.Enums;

namespace BusinessAssociates.Domain
{
    public class Associate
    {
        public long Id { get; set; }
        public bool IsInternal { get; set; }
        public int DUNSNumber { get; set; }
        public string LongName { get; set; }
        public string ShortName { get; set; }
        public AssociateType AssociateType { get; set; }
        public Status Status { get; set; }
        public bool IsDeactivating { get; set; }
        public string DisplayedIdentifier { get; set; }
        public bool IsParent { get; set; }
        public bool IsActive { get; set; }
    }
}