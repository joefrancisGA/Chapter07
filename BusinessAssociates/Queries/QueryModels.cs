namespace BusinessAssociates.Queries
{
    public static class QueryModels
    {
        public class GetAssociates
        {
            public int AssociateId { get; set; }
            public int Page { get; set; }
            public int PageSize { get; set; }
        }

        public class GetAssociate
        {
            public int AssociateId { get; set; }
        }
    }
}
