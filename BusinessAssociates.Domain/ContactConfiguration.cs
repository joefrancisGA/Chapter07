using System;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class ContactConfiguration : Entity<int>
    {
        public ContactConfiguration() { }
        public ContactConfiguration(Action<object> applier) : base(applier) { }


        public Contact Contact { get; set; }
        public int ContactId { get; set; }

        public DatabaseId FacilityId { get; set; }

        public ContactTypeLookup ContactType { get; set; }
        public int ContactTypeId { get; set; }

        public Priority Priority { get; set; }

        public StatusCodeLookup Status { get; set; }
        public int StatusCodeId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public static ContactConfiguration Create(int contactConfigurationId, DateTime startDate, int statusCodeId, 
            DateTime endDate, int contactId, int facilityId, int contactTypeId, int priority)
        {
            return new ContactConfiguration
            {
                Id = contactConfigurationId,
                StartDate = startDate,
                StatusCodeId = statusCodeId,
                EndDate = endDate,
                ContactId = contactId,
                FacilityId = facilityId,
                ContactTypeId = contactTypeId,
                Priority = priority
            };
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            _parentHandler = parentHandler;
        }
    }
}