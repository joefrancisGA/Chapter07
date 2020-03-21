using System;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class PredecessorBusinessAssociate : Entity<DatabaseId>
    {
        public DatabaseId AssociateId { get; set; }
        public DatabaseId PredecessorBusinessAssociateId { get; set; }

        public PredecessorBusinessAssociate(Action<object> applier) : base(applier)
        {
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}