using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class AgentUsers
    {
        public int Id { get; set; }
        public int AgentId { get; set; }
        public int UserId { get; set; }

        public virtual Associates Agent { get; set; }
        public virtual Users User { get; set; }
    }
}
