using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class OperatingContextCustomers
    {
        public int Id { get; set; }
        public int OperatingContextId { get; set; }
        public int CustomerId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual OperatingContexts OperatingContext { get; set; }
    }
}
