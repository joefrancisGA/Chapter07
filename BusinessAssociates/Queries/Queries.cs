﻿using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using BusinessAssociates.Domain.Enums;
using BusinessAssociates.Projections;
using Dapper;

namespace BusinessAssociates.Queries
{
    public static class Queries
    {
        public static Task<IEnumerable<ReadModels.AssociateListItem>> Query(this DbConnection connection, QueryModels.GetAssociates query)
            => connection.QueryAsync<ReadModels.AssociateListItem>(
                "SELECT ID, DUNSNumber, LongName, ShortName, IsParent, BusinessAssociateType, [Status] FROM BusinessAssociate" +
                " WHERE Status = @Status LIMIT @PageSize OFFSET @Offset",
            new
            {
                Status = (int)Status.Active,
                query.PageSize,
                Offset = Offset(query.Page, query.PageSize)
            });

        public static Task<ReadModels.AssociateDetails> Query(this DbConnection connection, QueryModels.GetAssociate query)
            => connection.QuerySingleOrDefaultAsync<ReadModels.AssociateDetails>(
                "SELECT ID, DUNSNumber, LongName, ShortName, IsParent, BusinessAssociateType, [Status] FROM BusinessAssociate" +
                " WHERE ID = @Id",
            new { Id = query.AssociateId });


        private static int Offset(int page, int pageSize) => page * pageSize;
    }
}
