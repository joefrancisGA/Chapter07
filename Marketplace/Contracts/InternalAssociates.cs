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
                public InternalAssociateType InternalAssociateType { get; set; }
                public Status Status { get; set; }
            }

            public class UpdateText
            {
                public long Id { get; set; }
                public string Text { get; set; }
            }
        }
    }
}