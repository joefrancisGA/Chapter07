using BusinessAssociates.Domain.Enums;

namespace BusinessAssociates.Contracts
{
    public static class InternalAssociates
    {
        public static class V1
        {
            public class Create
            {
                public int DUNSNumber { get; set; }
                public string LongName { get; set; }
                public string ShortName { get; set; }
                public bool IsParent { get; set; }
                public AssociateType InternalAssociateType { get; set; }
                public Status Status { get; set; }
            }

            public class UpdateDUNSNumber
            {
                public int Id { get; set; }
                public int DUNSNumber { get; set; }
            }

            public class UpdateLongName
            {
                public int Id { get; set; }
                public string LongName { get; set; }
            }

            public class UpdateShortName
            {
                public int Id { get; set; }
                public string ShortName { get; set; }
            }

            public class UpdateIsParent
            {
                public int Id { get; set; }
                public bool IsParent { get; set; }
            }

            public class UpdateInternalAssociateType
            {
                public int Id { get; set; }
                public AssociateType InternalAssociateType { get; set; }
            }

            public class UpdateStatus
            {
                public int Id { get; set; }
                public Status Status { get; set; }
            }
        }
    }
}