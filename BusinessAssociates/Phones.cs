using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class Phones
    {
        public Phones()
        {
            OperatingContexts = new HashSet<OperatingContexts>();
        }

        public int Id { get; set; }
        public int ContactId { get; set; }
        public int PhoneTypeId { get; set; }
        public string Extension { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }

        public virtual Contacts Contact { get; set; }
        public virtual PhoneTypes PhoneType { get; set; }
        public virtual ICollection<OperatingContexts> OperatingContexts { get; set; }
    }
}
