using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class AddressTypes
    {
        public AddressTypes()
        {
            Addresses = new HashSet<Addresses>();
        }

        public int Id { get; set; }
        public string AddressTypeName { get; set; }
        public string AddressTypeDescription { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Addresses> Addresses { get; set; }
    }
}
