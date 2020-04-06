using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class CountryCodes
    {
        public CountryCodes()
        {
            StateCodes = new HashSet<StateCodes>();
        }

        public int Id { get; set; }
        public string CountryCodeName { get; set; }
        public string CountryCodeDescription { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<StateCodes> StateCodes { get; set; }
    }
}
