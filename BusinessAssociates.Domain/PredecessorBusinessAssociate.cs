using System;
using EGMS.BusinessAssociates.Framework;


namespace EGMS.BusinessAssociates.Domain
{
    public class PredecessorBusinessAssociate : Entity<int>
    {
        public PredecessorBusinessAssociate() { }
        public PredecessorBusinessAssociate(Action<object> applier) : base(applier) { }

        public Associate Associate { get; set; }
        public int AssociateId { get; set; }

        public Associate PredecessorAssociate { get; set; }
        public int PredecessorAssociateId { get; set; }



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