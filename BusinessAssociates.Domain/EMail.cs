using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class EMail : Entity<int>
    {
        // TO DO:  Do we need to initialize the aggregates here?
        private EMail()
        {
            OperatingContexts = new HashSet<OperatingContext>();
        }

        public EMail(Action<object> applier) : base(applier)
        {
            OperatingContexts = new HashSet<OperatingContext>();
        }

        public User User { get; set; }
        public int UserId { get; set; }

        public EMailAddress EMailAddress { get; set; }
        
        public bool IsPrimary { get; set; }

        public Contact Contact { get; set; }
        public int ContactId { get; set; }

        public HashSet<OperatingContext> OperatingContexts { get; set; }

        // TO DO:  Do we need both user id and contact id?
        public static EMail Create(int emailId, int userId, EMailAddress emailAddress, bool isPrimary,
            int contactId)
        {
            return new EMail
            {
                Id = emailId,
                UserId = userId,
                EMailAddress = emailAddress,
                IsPrimary = isPrimary,
                ContactId = contactId
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