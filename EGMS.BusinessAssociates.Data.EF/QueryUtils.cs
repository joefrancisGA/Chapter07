﻿using System.Linq;
using EGMS.BusinessAssociates.Domain;
using static EGMS.BusinessAssociates.Query.QueryModels;


namespace EGMS.BusinessAssociates.Data.EF
{
    public static class QueryUtils
    {
        public static IQueryable<Associate> ApplyQuery(this IQueryable<Associate> query, AssociateQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IQueryable<Address> ApplyQuery(this IQueryable<Address> query, AddressQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IQueryable<AgentRelationship> ApplyQuery(this IQueryable<AgentRelationship> query, AgentRelationshipQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IQueryable<User> ApplyQuery(this IQueryable<User> query, UserQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IQueryable<Contact> ApplyQuery(this IQueryable<Contact> query, ContactQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }
        
        public static IQueryable<ContactConfiguration> ApplyQuery(this IQueryable<ContactConfiguration> query, ContactConfigurationQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IQueryable<Customer> ApplyQuery(this IQueryable<Customer> query, CustomerQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IQueryable<EMail> ApplyQuery(this IQueryable<EMail> query, EMailQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IQueryable<OperatingContext> ApplyQuery(this IQueryable<OperatingContext> query, OperatingContextQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IQueryable<Phone> ApplyQuery(this IQueryable<Phone> query, PhoneQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IQueryable<Role> ApplyQuery(this IQueryable<Role> query, RoleQueryParams queryParams, bool usePaging = true)
        {
            if (queryParams.Id.HasValue)
            {
                query = query.Where(x => x.Id == queryParams.Id.Value);
            }

            return query.ApplyBaseQuery(queryParams);
        }

        public static IQueryable<EGMSPermission> ApplyQuery(this IQueryable<EGMSPermission> query, EGMSPermissionQueryParams queryParams, bool usePaging = true)
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
