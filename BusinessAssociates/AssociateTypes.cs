using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class AssociateTypes
    {
        public AssociateTypes()
        {
            Associates = new HashSet<Associates>();
            OperatingContexts = new HashSet<OperatingContexts>();
        }

        public int Id { get; set; }
        public string AssociateTypeName { get; set; }
        public string AssociateTypeDescription { get; set; }

        public virtual ICollection<Associates> Associates { get; set; }
        public virtual ICollection<OperatingContexts> OperatingContexts { get; set; }
    }
}
