using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class ProviderTypes
    {
        public ProviderTypes()
        {
            OperatingContexts = new HashSet<OperatingContexts>();
        }

        public int Id { get; set; }
        public string ProviderTypeName { get; set; }
        public string ProviderTypeDescription { get; set; }

        public virtual ICollection<OperatingContexts> OperatingContexts { get; set; }
    }
}
