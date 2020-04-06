using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class OperatingContextTypes
    {
        public OperatingContextTypes()
        {
            OperatingContexts = new HashSet<OperatingContexts>();
        }

        public int Id { get; set; }
        public string OperatingContextTypeName { get; set; }
        public string OperatingContextTypeDescription { get; set; }

        public virtual ICollection<OperatingContexts> OperatingContexts { get; set; }
    }
}
