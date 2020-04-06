using System;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.API
{
    public partial class ContactConfigurations
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public int? FacilityId { get; set; }
        public int ContactTypeId { get; set; }
        public int ContactPriority { get; set; }
        public int StatusCodeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Contacts Contact { get; set; }
        public virtual ContactTypes ContactType { get; set; }
        public virtual StatusCodes StatusCode { get; set; }
    }
}
