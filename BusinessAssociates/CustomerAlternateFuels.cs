using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class CustomerAlternateFuels
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AlternateFuelTypeId { get; set; }

        public virtual AlternateFuelTypes AlternateFuelType { get; set; }
        public virtual Customers Customer { get; set; }
    }
}
