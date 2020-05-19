using EGMS.BusinessAssociates.Domain;


namespace EGMS.BusinessAssociates.Query.ReadModels
{
    public static class Conversions
    {
        public static ContactRM GetContactRM(Contact contact)
        {
            return new ContactRM
            {
                Id = contact.Id,
                PrimaryAddressId = contact.PrimaryAddressId,
                FirstName = contact.FirstName,
                IsActive = contact.IsActive,
                LastName = contact.LastName,
                PrimaryEmailId = contact.PrimaryEmailId,
                PrimaryPhoneId = contact.PrimaryPhoneId,
                Title = contact.Title
            };
        }

        public static ContactConfigurationRM GetContactConfigurationRM(ContactConfiguration contactConfiguration)
        {
            return new ContactConfigurationRM
            {
                Id = contactConfiguration.Id,
                ContactId = contactConfiguration.ContactId,
                ContactTypeId = contactConfiguration.ContactTypeId,
                EndDate = contactConfiguration.EndDate,
                Priority = contactConfiguration.Priority,
                StartDate = contactConfiguration.StartDate,
                StatusCodeId = contactConfiguration.StatusCodeId
            };
        }

        public static UserRM GetUserRM(User user)
        {
            return new UserRM
            {
                Id = user.Id,
                ContactId = user.ContactId,
                DeactivationDate = user.DeactivationDate,
                DepartmentCodeId = user.DepartmentCodeId,
                HasEGMSAccess = user.HasEGMSAccess,
                IDMSSID = user.IDMSSID.Value,
                IsActive = user.IsActive,
                IsInternal = user.IsInternal
            };
        }

        public static EMailRM GetEMailRM(EMail email)
        {
            return new EMailRM
            {
                Id = email.Id,
                ContactId = email.ContactId,
                EMailAddress = email.EMailAddress,
                IsPrimary = email.IsPrimary,
            };
        }

        public static PhoneRM GetPhoneRM(Phone phone)
        {
            return new PhoneRM { Id = phone.Id };
        }

        public static AddressRM GetAddressRM(Address address)
        {
            return new AddressRM
            {
                Id = address.Id,
                Address1 = address.Address1,
                Address2 = address.Address2,
                Address3 = address.Address3,
                Address4 = address.Address4,
                AddressTypeId = address.AddressTypeId,
                Attention = address.Attention,
                City = address.City,
                Comments = address.Comments,
                EndDate = address.EndDate,
                IsActive = address.IsActive,
                IsPrimary = address.IsPrimary,
                PostalCode = address.PostalCode,
                StartDate = address.StartDate,
                StateCodeId = address.StateCodeId
            };
        }

        public static AgentRelationshipRM GetAgentRelationshipRM(AgentRelationship agentRelationship)
        {
            return new AgentRelationshipRM
            {
                Id = agentRelationship.Id,
                StartDate = agentRelationship.StartDate,
                IsActive = agentRelationship.IsActive,
                AgentId = agentRelationship.AgentId,
                PrincipalId = agentRelationship.PrincipalId
            };
        }

        // TO DO:  No real reason other than to just return an ID
        public static EGMSPermissionRM GetEGMSPermissionRM(EGMSPermission permission)
        {
            return new EGMSPermissionRM
            {
                Id = permission.Id,
                IsActive = permission.IsActive,
                PermissionName = permission.PermissionName,
                PermissionDescription = permission.PermissionDescription
            };
        }
        public static RoleEGMSPermissionRM GetRoleEGMSPermissionRM(RoleEGMSPermission roleEGMSPermission)
        {
            return new RoleEGMSPermissionRM { Id = roleEGMSPermission.Id };
        }

        public static CertificationRM GetCertificationRM(Certification certification)
        {
            return new CertificationRM
            {
                Id = certification.Id,
                CertificationStatusId = certification.CertificationStatusId,
                IsInherited = certification.IsInherited,
                DecertificationDateTime = certification.DecertificationDateTime,
                CertificationDateTime = certification.CertificationDateTime
            };
        }

        public static RoleRM GetRoleRM(Role role)
        {
            return new RoleRM { Id = role.Id };
        }

        public static CustomerRM GetCustomerRM(Customer customer)
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            CustomerRM customerRM = new CustomerRM();

            customerRM.Id = customer.Id;
            customerRM.AccountNumber = customer.AccountNumber;

            if (customer.AlternateCustomerId != null)
                customerRM.AlternateCustomerId = customer.AlternateCustomerId;

            customerRM.BalancingLevelId = customer.BalancingLevelId;

            if (customer.BasicPoolId != null)
                customerRM.BasicPoolId = customer.BasicPoolId;

            if (customer.ContractTypeId != null)
                customerRM.ContractTypeId = customer.ContractTypeId;

            if (customer.CurrentDemand != null)
                customerRM.CurrentDemand = customer.CurrentDemand;

            customerRM.CustomerTypeId = customer.CustomerTypeId;

            if (customer.DUNSNumber != null)
                customerRM.DUNSNumber = customer.DUNSNumber;

            if (customer.DailyInterruptible != null)
                customerRM.DailyInterruptible = customer.DailyInterruptible;

            customerRM.DeliveryLocation = customer.DeliveryLocation;

            if (customer.DeliveryPressure != null)
                customerRM.DeliveryPressure = customer.DeliveryPressure;

            customerRM.DeliveryTypeId = customer.DeliveryTypeId;
            customerRM.EndDate = customer.EndDate;
            customerRM.GroupTypeId = customer.GroupTypeId;

            if (customer.HourlyInterruptible != null)
                customerRM.HourlyInterruptible = customer.HourlyInterruptible;

            if (customer.InterstateSpecifiedFirm != null)
                customerRM.InterstateSpecifiedFirm = customer.InterstateSpecifiedFirm;

            if (customer.IntrastateSpecifiedFirm != null)
                customerRM.IntrastateSpecifiedFirm = customer.IntrastateSpecifiedFirm;

            customerRM.IsFederal = customer.IsFederal;

            if (customer.LDCId != null)
                customerRM.LDCId = customer.LDCId;

            if (customer.LongName != null)
                customerRM.LongName = customer.LongName;

            customerRM.LossTierId = customer.LossTierId;

            if (customer.MDQ != null)
                customerRM.MDQ = customer.MDQ;

            if (customer.MaxDailyInterruptible != null)
                customerRM.MaxDailyInterruptible = customer.MaxDailyInterruptible;

            if (customer.MaxHourlyInterruptible != null)
                customerRM.MaxHourlyInterruptible = customer.MaxHourlyInterruptible;

            if (customer.MaxHourlySpecifiedFirm != null)
                customerRM.MaxHourlySpecifiedFirm = customer.MaxHourlySpecifiedFirm;

            if (customer.NAICSCode != null)
                customerRM.NAICSCode = customer.NAICSCode.ToString();

            customerRM.NominationLevelId = customer.NominationLevelId;

            if (customer.PreviousDemand != null)
                customerRM.PreviousDemand = customer.PreviousDemand;

            if (customer.SICCode != null)
                customerRM.SICCode = customer.SICCode.ToString();

            if (customer.SICCodePercentage != null)
                customerRM.SICCodePercentage = customer.SICCodePercentage;

            customerRM.SS1 = customer.SS1;
            customerRM.ShipperId = customer.ShipperId;
            customerRM.ShippersLetterFromDate = customer.ShippersLetterFromDate;
            customerRM.ShippersLetterToDate = customer.ShippersLetterToDate;

            if (customer.ShortName != null)
                customerRM.ShortName = customer.ShortName;

            customerRM.StartDate = customer.StartDate;
            customerRM.StatusCodeId = customer.StatusCodeId;

            if (customer.TotalDailySpecifiedFirm != null)
                customerRM.TotalDailySpecifiedFirm = customer.TotalDailySpecifiedFirm;

            customerRM.TurnOffDate = customer.TurnOffDate;

            if (customer.TotalHourlySpecifiedFirm != null)
                customerRM.TotalHourlySpecifiedFirm = customer.TotalHourlySpecifiedFirm;

            customerRM.TurnOnDate = customer.TurnOnDate;

            return customerRM;
        }

        public static OperatingContextRM GetOperatingContextRM(OperatingContext operatingContext)
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            OperatingContextRM operatingContextRM = new OperatingContextRM();

            operatingContextRM.Id = operatingContext.Id;
            operatingContextRM.ActingBAType = operatingContext.ActingBATypeId;
            operatingContextRM.CertificationId = operatingContext.CertificationId;
            operatingContextRM.FacilityId = operatingContext.FacilityId;
            operatingContextRM.IsDeactivating = operatingContext.IsDeactivating;
            operatingContextRM.LegacyId = operatingContext.LegacyId;
            operatingContextRM.OperatingContextType = operatingContext.OperatingContextTypeId;
            operatingContextRM.PrimaryAddress = operatingContext.PrimaryAddressId;
            operatingContextRM.PrimaryEmail = operatingContext.PrimaryEmailId;
            operatingContextRM.PrimaryPhone = operatingContext.PrimaryPhoneId;
            operatingContextRM.ProviderType = operatingContext.ProviderTypeId;
            operatingContextRM.StartDate = operatingContext.StartDate;
            operatingContextRM.Status = operatingContext.StatusCodeId;
            operatingContextRM.ThirdPartySupplierId = operatingContext.ThirdPartySupplierId;
            
            return operatingContextRM;
        }
    }
}
