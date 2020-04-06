using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class NominationLevelTypes
    {
        public NominationLevelTypes()
        {
            Customers = new HashSet<Customers>();
        }

        public int Id { get; set; }
        public string NominationLevelName { get; set; }
        public string NominationLevelDescription { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
