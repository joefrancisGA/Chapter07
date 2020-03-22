using EGMS.BusinessAssociates.Domain.Enums;

namespace EGMS.BusinessAssociates.Domain.Events
{
    public static class Events
    {
        public class AssociateCreated
        {
            public int Id { get; set; }

            public string LongName { get; set; }
            public string ShortName { get; set; }
            public bool IsParent { get; set; }
            public AssociateType AssociateType { get; set; }
            public Status Status { get; set; }
        }

        public class AssociateDUNSNumberUpdated
        {
            public int Id { get; set; }
            public int DUNSNumber { get; set; }
        }

        public class AssociateTypeUpdated
        {
            public int Id { get; set; }
            public int AssociateType { get; set; }
        }

        public class AssociateLongNameUpdated
        {
            public int Id { get; set; }
            public string LongName { get; set; }
        }

        public class AssociateIsParentUpdated
        {
            public int Id { get; set; }
            public bool IsParent { get; set; }
        }

        public class AssociateStatusUpdated
        {
            public int Id { get; set; }
            public int Status { get; set; }
        }

        public class AssociateShortNameUpdated
        {
            public int Id { get; set; }
            public string ShortName { get; set; }
        }

        public class AssociateAddNewOperatingContext
        {

        }
    }
}