using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class ContactTypes
    {
        public ContactTypes()
        {
            ContactConfigurations = new HashSet<ContactConfigurations>();
        }

        public int Id { get; set; }
        public string ContactTypeName { get; set; }
        public string ContactTypeDescription { get; set; }

        public virtual ICollection<ContactConfigurations> ContactConfigurations { get; set; }
    }
}
