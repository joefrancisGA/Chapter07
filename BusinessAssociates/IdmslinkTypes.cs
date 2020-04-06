using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class IdmslinkTypes
    {
        public IdmslinkTypes()
        {
            UserContactDisplayRules = new HashSet<UserContactDisplayRules>();
        }

        public int Id { get; set; }
        public string IdmslinkTypeName { get; set; }
        public string IdmlinkTypeDescription { get; set; }

        public virtual ICollection<UserContactDisplayRules> UserContactDisplayRules { get; set; }
    }
}
