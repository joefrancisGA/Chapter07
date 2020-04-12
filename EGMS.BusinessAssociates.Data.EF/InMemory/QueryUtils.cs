using System.Linq;
using EGMS.BusinessAssociates.Domain;
using static EGMS.BusinessAssociates.Query.QueryModels;


namespace EGMS.BusinessAssociates.Data.EF.InMemory
{
    public static class QueryUtils
    {
        public static IQueryable<Associate> ApplyQuery(this IQueryable<Associate> query, FacilityQueryParams queryParams)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IQueryable<T> ApplyBaseQuery<T>(this IQueryable<T> query, BaseQueryParams queryParams)
        {
            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                int page = queryParams.Page.Value - 1;
                int pageSize = queryParams.PageSize.Value;

                if (page < 0)
                {
                    page = 0;
                }

                if (pageSize<0)
                {
                    pageSize = 10;
                }

                int skip = page * pageSize;

                query = query.Skip(skip).Take(pageSize);
            }

            return query;
        }
    }
}
