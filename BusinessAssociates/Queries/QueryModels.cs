namespace EGMS.BusinessAssociates.API.Queries
{
    public static class QueryModels
    {
        public class GetAssociates
        {
            public int Page { get; set; }
            public int PageSize { get; set; }
        }

        public class GetAssociate
        {
            public int AssociateId { get; set; }
        }
    }
}
