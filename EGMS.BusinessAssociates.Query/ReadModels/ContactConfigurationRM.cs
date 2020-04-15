using System;

namespace EGMS.BusinessAssociates.Query.ReadModels
{
    public class ContactConfigurationRM
    {
        public int Id { get; set; }

        public int ContactId { get; set; }
        public int FacilityId { get; set; }
        public int ContactTypeId { get; set; }
        public int Priority { get; set; }
        public int StatusCodeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}