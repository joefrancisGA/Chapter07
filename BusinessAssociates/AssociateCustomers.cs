using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class AssociateCustomers
    {
        public int Id { get; set; }
        public int AssociateId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? ServiceStartDate { get; set; }
        public DateTime? ServiceEndDate { get; set; }

        public virtual Associates Associate { get; set; }
        public virtual Customers Customer { get; set; }
    }
}
