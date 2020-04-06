using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class PhoneTypes
    {
        public PhoneTypes()
        {
            Phones = new HashSet<Phones>();
        }

        public int Id { get; set; }
        public string PhoneTypeName { get; set; }
        public string PhoneTypeDescription { get; set; }

        public virtual ICollection<Phones> Phones { get; set; }
    }
}
