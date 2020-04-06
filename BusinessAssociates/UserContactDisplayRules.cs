using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class UserContactDisplayRules
    {
        public int Id { get; set; }
        public bool IsInternal { get; set; }
        public bool IdmsaccountExists { get; set; }
        public int IdmsaccountStatusId { get; set; }
        public bool Egmsconfigured { get; set; }
        public int EgmsaccountStatusId { get; set; }
        public int IdmslinkTypeId { get; set; }
        public int EgmslinkTypeId { get; set; }

        public virtual AccountStatuses EgmsaccountStatus { get; set; }
        public virtual EgmslinkTypes EgmslinkType { get; set; }
        public virtual AccountStatuses IdmsaccountStatus { get; set; }
        public virtual IdmslinkTypes IdmslinkType { get; set; }
    }
}
