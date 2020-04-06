using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class StatusCodes
    {
        public StatusCodes()
        {
            Associates = new HashSet<Associates>();
            ContactConfigurations = new HashSet<ContactConfigurations>();
            Customers = new HashSet<Customers>();
            OperatingContexts = new HashSet<OperatingContexts>();
        }

        public int Id { get; set; }
        public string StatusCodeName { get; set; }
        public string StatusCodeCodeDescription { get; set; }

        public virtual ICollection<Associates> Associates { get; set; }
        public virtual ICollection<ContactConfigurations> ContactConfigurations { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<OperatingContexts> OperatingContexts { get; set; }
    }
}
