using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class AssociateOperatingContexts
    {
        public int Id { get; set; }
        public int AssociateId { get; set; }
        public int OperatingContextId { get; set; }
        public bool IsActive { get; set; }

        public virtual Associates Associate { get; set; }
        public virtual OperatingContexts OperatingContext { get; set; }
    }
}
