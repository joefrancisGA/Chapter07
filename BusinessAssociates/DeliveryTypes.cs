using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class DeliveryTypes
    {
        public DeliveryTypes()
        {
            Customers = new HashSet<Customers>();
        }

        public int Id { get; set; }
        public string DeliveryTypeName { get; set; }
        public string DeliveryTypeDescription { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
