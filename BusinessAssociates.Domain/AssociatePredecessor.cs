using System;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class AssociatePredecessor : Entity<int>
    {
        public AssociatePredecessor() { }
        public AssociatePredecessor(Action<object> applier) : base(applier) { }

        public Associate Associate { get; set; }
        public int AssociateId { get; set; }

        public Associate Predecessor { get; set; }
        public int PredecessorId { get; set; }

        
        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            ParentHandler = parentHandler;
        }
    }
}