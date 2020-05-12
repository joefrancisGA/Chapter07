using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class EMail : Entity<int>
    {
        private EMail()
        {
            OperatingContexts = new HashSet<OperatingContext>();
        }

        public EMail(Action<object> applier) : base(applier)
        {
            OperatingContexts = new HashSet<OperatingContext>();
        }

        public EMailAddress EMailAddress { get; set; }
        
        public bool IsPrimary { get; set; }

        public Contact Contact { get; set; }
        public int ContactId { get; set; }

        public Associate Associate { get; set; }
        public int AssociateId { get; set; }

        public HashSet<OperatingContext> OperatingContexts { get; set; }

        // TO DO:  Do we need both user id and contact id?
        public static EMail CreateForContact(int emailId, EMailAddress emailAddress, bool isPrimary,
            int contactId)
        {
            return new EMail
            {
                Id = emailId,
                EMailAddress = emailAddress,
                IsPrimary = isPrimary,
                ContactId = contactId
            };
        }

        public static EMail CreateForAssociate(int emailId, EMailAddress emailAddress, bool isPrimary,
            int associateId)
        {
            return new EMail
            {
                Id = emailId,
                EMailAddress = emailAddress,
                IsPrimary = isPrimary,
                AssociateId = associateId
            };
        }


        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }

        public override void OnLoadInit(Action<object> parentHandler)
        {
            ParentHandler = parentHandler;
        }
    }
}