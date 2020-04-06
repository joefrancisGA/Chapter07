using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class LossTierTypes
    {
        public LossTierTypes()
        {
            Customers = new HashSet<Customers>();
        }

        public int Id { get; set; }
        public string LossTierName { get; set; }
        public string LossTierDescription { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
