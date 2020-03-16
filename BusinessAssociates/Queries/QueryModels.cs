namespace BusinessAssociates.Queries
{
    public static class QueryModels
    {
        public class GetInternalAssociates
        {
            public long InternalAssociateId { get; set; }
            public int Page { get; set; }
            public int PageSize { get; set; }
        }
    }
}
