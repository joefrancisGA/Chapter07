using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class CustomerTypes
    {
        public CustomerTypes()
        {
            Customers = new HashSet<Customers>();
        }

        public int Id { get; set; }
        public string CustomerTypeName { get; set; }
        public string CustomerTypeDescription { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
    }
}
