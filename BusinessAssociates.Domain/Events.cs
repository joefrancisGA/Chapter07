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

        public class InternalAssociateTextUpdated
        {
            public long Id { get; set; }
        }
    }
}