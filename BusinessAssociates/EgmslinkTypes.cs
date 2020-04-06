using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class EgmslinkTypes
    {
        public EgmslinkTypes()
        {
            UserContactDisplayRules = new HashSet<UserContactDisplayRules>();
        }

        public int Id { get; set; }
        public string EgmslinkTypeName { get; set; }
        public string EgmslinkTypeDescription { get; set; }

        public virtual ICollection<UserContactDisplayRules> UserContactDisplayRules { get; set; }
    }
}
