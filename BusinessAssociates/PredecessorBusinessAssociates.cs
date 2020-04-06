using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class PredecessorBusinessAssociates
    {
        public int Id { get; set; }
        public int AssociateId { get; set; }
        public int PredecessorAssociateId { get; set; }

        public virtual Associates Associate { get; set; }
        public virtual Associates PredecessorAssociate { get; set; }
    }
}
