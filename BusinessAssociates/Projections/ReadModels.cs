namespace BusinessAssociates.Projections
{
    public static class ReadModels
    {
        public class InternalAssociateDetails
        {
            public int Id { get; set; }
            public string DUNSNumber { get; set; }
            public string LongName { get; set; }
            public string ShortName { get; set; }

            public int InternalAssociateType { get; set; }
            public bool IsParent { get; set; }
            public int Status { get; set; }
        }

        public class AssociateDetails
        {
            public int Id { get; set; }
            public string DUNSNumber { get; set; }
            public string LongName { get; set; }
            public string ShortName { get; set; }

            public int AssociateType { get; set; }
            public bool IsParent { get; set; }
            public int Status { get; set; }
        }
    }
}
