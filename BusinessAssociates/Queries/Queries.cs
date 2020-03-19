using System.Collections.Generic;
using System.Linq;
using BusinessAssociates.Projections;

namespace BusinessAssociates.Queries
{
    public static class Queries
    {
        public static ReadModels.InternalAssociateDetails Query(
            this IEnumerable<ReadModels.InternalAssociateDetails> items,
            QueryModels.GetInternalAssociates query)
            => items.FirstOrDefault(x => x.Id == query.InternalAssociateId);

        public static ReadModels.AssociateDetails Query(
            this IEnumerable<ReadModels.AssociateDetails> items,
            QueryModels.GetAssociates query)
            => items.FirstOrDefault(x => x.Id == query.AssociateId);
    }
}
