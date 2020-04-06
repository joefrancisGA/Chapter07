using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class AccountStatuses
    {
        public AccountStatuses()
        {
            UserContactDisplayRulesEgmsaccountStatus = new HashSet<UserContactDisplayRules>();
            UserContactDisplayRulesIdmsaccountStatus = new HashSet<UserContactDisplayRules>();
        }

        public int Id { get; set; }
        public string AccountStatusName { get; set; }
        public string AccountStatusDescription { get; set; }

        public virtual ICollection<UserContactDisplayRules> UserContactDisplayRulesEgmsaccountStatus { get; set; }
        public virtual ICollection<UserContactDisplayRules> UserContactDisplayRulesIdmsaccountStatus { get; set; }
    }
}
