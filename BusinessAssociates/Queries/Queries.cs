﻿using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Dapper;
using EGMS.BusinessAssociates.API.Projections;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Query;

namespace EGMS.BusinessAssociates.API.Queries
{
    public static class Queries
    {
        //public static Task<IEnumerable<ReadModels.AssociateListItem>> Query(this DbConnection connection, QueryModels.GetAssociates query)
        //    => connection.QueryAsync<ReadModels.AssociateListItem>(
        //        "SELECT ID, DUNSNumber, LongName, ShortName, IsParent, AssociateTypeId, StatusCodeId, IsDeactivating FROM Associate" +
        //        " WHERE StatusCodeId = @Status ORDER BY ID OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY", 
        //    new
        //    {
        //        Status = (int)StatusCodeLookup.StatusCodeEnum.Active,
        //        query.PageSize,
        //        Offset = Offset(query.Page, query.PageSize)
        //    });

        //public static Task<ReadModels.AssociateDetails> Query(this DbConnection connection, QueryModels.GetAssociate query)
        //    => connection.QuerySingleOrDefaultAsync<ReadModels.AssociateDetails>(
        //        "SELECT ID, DUNSNumber, LongName, ShortName, IsParent, AssociateTypeId, StatusCodeId, IsDeactivating FROM Associate" +
        //        " WHERE ID = @Id",
        //    new { Id = query.AssociateId });


        private static int Offset(int page, int pageSize) => page * pageSize;
    }
}
