﻿using System;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.Messages;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;

namespace EGMS.BusinessAssociates.Domain
{
    public class OperatingContext : Entity<int>
    {
        public OperatingContextType OperatingContextType { get; set; }
        public DatabaseId FacilityId { get; set; }
        public DatabaseId ThirdPartySupplierId { get; set; }

        // TO DO:  Not sure what to do with the type for LegacyId
        public int LegacyId { get; set; }
        public ProviderType ProviderType { get; set; }
        public AssociateType ActingBAType { get; set; }
        public NullableDatabaseId CertificationId { get; set; }

        // TO DO:  Do we really have a "set" of roles for the operating context?
        public Role Role { get; set; }
        public Status Status { get; set; }

        public bool IsDeactivating { get; set; }
        public DateTime StartDate { get; set; }
        public EMail PrimaryEmail { get; set; }
        public Phone PrimaryPhone { get; set; }
        public Address PrimaryAddress { get; set; }

        public DatabaseId PrimaryEmailId { get; set; }
        public DatabaseId PrimaryPhoneId { get; set; }
        public DatabaseId PrimaryAddressId { get; set; }

        public OperatingContext(Action<object> applier) : base(applier)
        {
        }

        protected OperatingContext() { }

        protected override void When(object @event)
        {
            switch (@event)
            { 
                case Events.AssociateAddNewOperatingContext e:
                    Id = new DatabaseId(e.Id);
                    break;

                default:
                    break;
            }

        }
    }
}

