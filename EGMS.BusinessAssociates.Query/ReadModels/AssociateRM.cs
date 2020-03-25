namespace EGMS.BusinessAssociates.Query.ReadModels
{
    public class AssociateRM
    {
        public int Id { get; set; }

        public int DUNSNumber { get; set; }

        public string ShortName { get; set; }
        public string LongName { get; set; }
        public int AssociateType { get; set; }
        public int Status { get; set; }
        public bool IsInternal { get; set; }
        public bool IsDeactivating { get; set; }
        public bool IsParent { get; set; }
        public bool IsActive { get; set; }
    }
}

