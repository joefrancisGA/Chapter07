using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class StateCodes
    {
        public StateCodes()
        {
            Addresses = new HashSet<Addresses>();
        }

        public int Id { get; set; }
        public int CountryCodeId { get; set; }
        public string StateCodeName { get; set; }
        public string StateCodeDescription { get; set; }
        public bool IsActive { get; set; }

        public virtual CountryCodes CountryCode { get; set; }
        public virtual ICollection<Addresses> Addresses { get; set; }
    }
}
