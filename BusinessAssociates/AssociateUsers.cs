using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class AssociateUsers
    {
        public int Id { get; set; }
        public int AssociateId { get; set; }
        public int UserId { get; set; }

        public virtual Associates Associate { get; set; }
        public virtual Users User { get; set; }
    }
}
