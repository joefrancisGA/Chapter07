namespace EGMS.BusinessAssociates.Query
{
    public static class QueryModels
    {
        // contains standard grid list query options.
        public class BaseQueryParams
        {
            public int? Page { get; set; }
            public int? PageSize { get; set; }
        }

        public class AssociateQueryParams : BaseQueryParams
        {
            public int? Id { get; set; }
        }

    }
}
