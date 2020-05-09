using System.Collections.Generic;
using System.Linq;
using EGMS.BusinessAssociates.Domain;
using static EGMS.BusinessAssociates.Query.QueryModels;


namespace EGMS.BusinessAssociates.Data.EF
{
    public static class QueryUtils
    {
        public static IEnumerable<Associate> ApplyQuery(this IEnumerable<Associate> query, AssociateQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IEnumerable<Address> ApplyQuery(this IEnumerable<Address> query, AddressQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IEnumerable<AgentRelationship> ApplyQuery(this IEnumerable<AgentRelationship> query, AgentRelationshipQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IEnumerable<User> ApplyQuery(this IEnumerable<User> query, UserQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IEnumerable<Certification> ApplyQuery(this IEnumerable<Certification> query, CertificationQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IEnumerable<Contact> ApplyQuery(this IEnumerable<Contact> query, ContactQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }
        
        public static IEnumerable<ContactConfiguration> ApplyQuery(this IEnumerable<ContactConfiguration> query, ContactConfigurationQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IEnumerable<Customer> ApplyQuery(this IEnumerable<Customer> query, CustomerQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IEnumerable<EMail> ApplyQuery(this IEnumerable<EMail> query, EMailQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IEnumerable<OperatingContext> ApplyQuery(this IEnumerable<OperatingContext> query, OperatingContextQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IEnumerable<Phone> ApplyQuery(this IEnumerable<Phone> query, PhoneQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IEnumerable<Role> ApplyQuery(this IEnumerable<Role> query, RoleQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IEnumerable<EGMSPermission> ApplyQuery(this IEnumerable<EGMSPermission> query, EGMSPermissionQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IEnumerable<RoleEGMSPermission> ApplyQuery(this IEnumerable<RoleEGMSPermission> query, RoleEGMSPermissionQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IEnumerable<T> ApplyBaseQuery<T>(this IEnumerable<T> query, BaseQueryParams queryParams)
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
