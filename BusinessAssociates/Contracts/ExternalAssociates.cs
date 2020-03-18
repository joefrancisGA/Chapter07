using BusinessAssociates.Domain.Enums;

namespace BusinessAssociates.Contracts
{
    public static class ExternalAssociates
    {
        public static class V1
        {
            public class Create
            {
                public int DUNSNumber { get; set; }
                public string LongName { get; set; }
                public string ShortName { get; set; }
                public bool IsParent { get; set; }
                public ExternalAssociateType ExternalAssociateType { get; set; }
                public Status Status { get; set; }
            }

            public class UpdateDUNSNumber
            {
                public long Id { get; set; }
                public int DUNSNumber { get; set; }
            }

            public class UpdateLongName
            {
                public long Id { get; set; }
                public string LongName { get; set; }
            }

            public class UpdateShortName
            {
                public long Id { get; set; }
                public string ShortName { get; set; }
            }

            public class UpdateIsParent
            {
                public long Id { get; set; }
                public bool IsParent { get; set; }
            }

            public class UpdateExternalAssociateType
            {
                public long Id { get; set; }
                public ExternalAssociateType ExternalAssociateType { get; set; }
            }

            public class UpdateStatus
            {
                public long Id { get; set; }
                public Status Status { get; set; }
            }
        }
    }
}