using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class AgentRelationships
    {
        public int Id { get; set; }
        public int PrincipalId { get; set; }
        public int AgentId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Associates Agent { get; set; }
        public virtual Associates Principal { get; set; }
    }
}
