using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class PredecessorBusinessAssociate : Entity<DatabaseId>
    {
        public PredecessorBusinessAssociate() { }
        public PredecessorBusinessAssociate(Action<object> applier) : base(applier) { }

        public Associate Associate { get; set; }
        public DatabaseId AssociateId { get; set; }

        public List<Associate> PredecessorAssociate { get; set; }
        public DatabaseId PredecessorAssociateId { get; set; }

        
        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}