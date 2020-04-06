using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class ContactAddresses
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public int AddressId { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual Contacts Contact { get; set; }
    }
}
