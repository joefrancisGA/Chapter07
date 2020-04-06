using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class AlternateFuelTypes
    {
        public AlternateFuelTypes()
        {
            CustomerAlternateFuels = new HashSet<CustomerAlternateFuels>();
        }

        public int Id { get; set; }
        public string AlternateFuelTypeName { get; set; }
        public string AlternateFuelTypeDescription { get; set; }

        public virtual ICollection<CustomerAlternateFuels> CustomerAlternateFuels { get; set; }
    }
}
