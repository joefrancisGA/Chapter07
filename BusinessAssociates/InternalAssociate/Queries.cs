using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAssociates.Projections;

namespace BusinessAssociates.InternalAssociate
{
    public static class Queries
    {
        public static ReadModels.InternalAssociateDetails Query(
            this IEnumerable<ReadModels.InternalAssociateDetails> items,
            QueryModels.GetInternalAssociates query)
            => items.FirstOrDefault(x => x.Id == query.InternalAssociateId);
    }
}
