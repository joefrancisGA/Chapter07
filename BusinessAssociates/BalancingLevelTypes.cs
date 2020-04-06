using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class BalancingLevelTypes
    {
        public BalancingLevelTypes()
        {
            Customers = new HashSet<Customers>();
        }

        public int Id { get; set; }
        public string BalancingLevelTypeName { get; set; }
        public string BalancingLevelTypeDescription { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
