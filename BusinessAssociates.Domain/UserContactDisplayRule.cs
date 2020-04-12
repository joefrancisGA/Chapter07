using System;
using System.Collections.Generic;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class UserContactDisplayRule : Entity<int>
    {
        public UserContactDisplayRule() { }
        public UserContactDisplayRule(Action<object> applier) : base(applier) { }

        public bool IsInternal { get; set; }
        public bool IDMSAccountExists { get; set; }
        public bool IDMSAccountActive { get; set; }
        public bool EGMSConfigured { get; set; }
        public bool IsActive { get; set; }

        public EGMSAccountStatusLookup EGMSAccountStatus {get; set; }
        public int EGMSAccountStatusId { get; set; }

        public IDMSAccountStatusLookup IDMSAccountStatus { get; set; }
        public int IDMSAccountStatusId { get; set; }

        public EGMSLinkTypeLookup EGMSLinkType {get; set; }
        public int EGMSLinkTypeId { get; set; }

        public IDMSLinkTypeLookup IDMSLinkType { get; set; }
        public int IDMSLinkTypeId { get; set; }


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