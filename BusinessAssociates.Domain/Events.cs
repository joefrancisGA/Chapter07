using BusinessAssociates.Domain.Enums;

namespace BusinessAssociates.Domain
{
    public static class Events
    {
        public class InternalAssociateCreated
        {
            public long Id { get; set; }
            public string LongName { get; set; }
            public string ShortName { get; set; }
            public bool IsParent { get; set; }
            public InternalAssociateType InternalAssociateType { get; set; }
            public Status Status { get; set; }
        }

        public class InternalAssociateDUNSNumberUpdated
        {
            public long Id { get; set; }
            public int DUNSNumber { get; set; }
        }

        public class InternalAssociateTypeUpdated
        {
            public long Id { get; set; }
            public int InternalAssociateType { get; set; }
        }

        public class InternalAssociateLongNameUpdated
        {
            public long Id { get; set; }
            public string LongName { get; set; }
        }

        public class InternalAssociateIsParentUpdated
        {
            public long Id { get; set; }
            public bool IsParent { get; set; }
        }

        public class InternalAssociateStatusUpdated
        {
            public long Id { get; set; }
            public int Status { get; set; }
        }

        public class InternalAssociateShortNameUpdated
        {
            public long Id { get; set; }
            public string ShortName { get; set; }
        }

        public class ExternalAssociateCreated
        {
            public long Id { get; set; }
            public string LongName { get; set; }
            public string ShortName { get; set; }
            public bool IsParent { get; set; }
            public ExternalAssociateType ExternalAssociateType { get; set; }
            public Status Status { get; set; }
        }

        public class ExternalAssociateDUNSNumberUpdated
        {
            public long Id { get; set; }
            public int DUNSNumber { get; set; }
        }

        public class ExternalAssociateTypeUpdated
        {
            public long Id { get; set; }
            public int ExternalAssociateType { get; set; }
        }

        public class ExternalAssociateLongNameUpdated
        {
            public long Id { get; set; }
            public string LongName { get; set; }
        }

        public class ExternalAssociateIsParentUpdated
        {
            public long Id { get; set; }
            public bool IsParent { get; set; }
        }
        public class ExternalAssociateStatusUpdated
        {
            public long Id { get; set; }
            public int Status { get; set; }
        }

        public class ExternalAssociateShortNameUpdated
        {
            public long Id { get; set; }
            public string ShortName { get; set; }
        }
    }
}