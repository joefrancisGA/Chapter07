using System;
using System.Threading.Tasks;
using AutoMapper;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.Repositories;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Framework;
using EGMS.BusinessAssociates.Query.ReadModels;


namespace EGMS.BusinessAssociates.Command
{
    public class AssociatesApplicationService : IApplicationService
    {
        private static int _associates = 1;
        private static int _contactConfigurations = 1;
        private static int _addresses = 1;
        private readonly IAssociateRepository _repository;
        private readonly IMapper _mapper;

        public AssociatesApplicationService(IAssociateRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

#pragma warning disable 1998
        public async Task<object> Handle(object command)
#pragma warning restore 1998
        {
            switch (command)
            {
                #region Associates

                case Commands.V1.Associate.Create cmd:
                    return CreateAssociate(cmd);
                    
                case Commands.V1.Associate.UpdateDUNSNumber cmd:
                    HandleUpdate(cmd.Id, ia => ia.UpdateDUNSNumber(DUNSNumber.Create(cmd.DUNSNumber)));
                    break;

                case Commands.V1.Associate.UpdateAssociateType cmd:
                    HandleUpdate(cmd.Id, ia => ia.UpdateAssociateType(AssociateTypeLookup.AssociateTypes[cmd.AssociateType]));
                    break;

                case Commands.V1.Associate.UpdateLongName cmd:
                    HandleUpdate(cmd.Id, ia => ia.UpdateLongName(LongName.Create(cmd.LongName)));
                    break;

                case Commands.V1.Associate.UpdateIsParent cmd:
                    HandleUpdate(cmd.Id, ia => ia.UpdateIsParent(cmd.IsParent));
                    break;

                case Commands.V1.Associate.UpdateStatus cmd:
                    HandleUpdate(cmd.Id, ia => ia.UpdateStatus(StatusCodeLookup.StatusCodes[cmd.Status]));
                    break;

                case Commands.V1.Associate.UpdateShortName cmd:
                    HandleUpdate(cmd.Id, ia => ia.UpdateShortName(ShortName.Create(cmd.ShortName)));
                    break;

                #endregion
                    
                #region AgentRelationship

                case Commands.V1.AgentRelationship.CreateForPrincipal cmd:
                    return CreateAgentRelationshipForPrincipal(cmd);

                case Commands.V1.AgentRelationship.User.CreateForAgent cmd:
                    return CreateUserForAgent(cmd);

                #endregion

                #region Contact

                case Commands.V1.Contact.CreateForAssociate cmd:
                    return CreateContactForAssociate(cmd);

                case Commands.V1.Contact.Address.CreateForContact cmd:
                    return CreateAddressForContact(cmd);

                case Commands.V1.Contact.Address.Update cmd:
                    return UpdateAddressForContact(cmd);

                case Commands.V1.Contact.ContactConfiguration.CreateForContact cmd:
                    return CreateContactConfigurationForContact(cmd);

                case Commands.V1.Contact.EMail.CreateForContact cmd:
                    return CreateEMailForContact(cmd);

                case Commands.V1.Contact.Phone.CreateForContact cmd:
                    return CreatePhoneForContact(cmd);

                #endregion

                #region Customer

                case Commands.V1.Customer.CreateForAssociate cmd:
                    return CreateCustomerForAssociate(cmd);

                case Commands.V1.Customer.OperatingContext.CreateForCustomer cmd:
                    return CreateOperatingContextForCustomer(cmd);

                case Commands.V1.Customer.AlternateFuel.CreateForCustomer cmd:
                    return CreateAlternateFuelForCustomer(cmd);

                #endregion

                case Commands.V1.EGMSPermission.Create cmd:
                    return CreateEGMSPermission(cmd);

                case Commands.V1.Role.Create cmd:
                    return CreateRole(cmd);

                case Commands.V1.RoleEGMSPermission.Create cmd:
                    return CreateRoleEGMSPermission(cmd);

                case Commands.V1.User.CreateForAssociate cmd:
                    return CreateUserForAssociate(cmd);

                #region OperatingContext

                case Commands.V1.OperatingContext.CreateForAssociate cmd:
                    return AddOperatingContextForAssociate(cmd);

                case Commands.V1.OperatingContext.Address.CreateForOperatingContext cmd:
                    return CreateAddressForOperatingContext(cmd);

                case Commands.V1.OperatingContext.Certification.CreateForOperatingContext cmd:
                    return CreateCertificationForOperatingContext(cmd);

                case Commands.V1.OperatingContext.Customer.CreateForOperatingContext cmd:
                    return CreateCustomerForOperatingContext(cmd);

                case Commands.V1.OperatingContext.Customer.AlternateFuel.CreateForCustomer cmd:
                    return CreateAlternateFuelForCustomer(cmd);

                case Commands.V1.OperatingContext.Update cmd:
                    return UpdateOperatingContext(cmd);

                #endregion


                default:
                    throw new InvalidOperationException($"Commands type {command.GetType().FullName} is unknown");
            }

            return null;
        }

#pragma warning disable 1998
        private async void HandleUpdate(int associateId, Action<Associate> operation)
#pragma warning restore 1998
        {
            Associate associate = _repository.LoadAssociate(associateId).Result;

            if (associate == null)
                throw new InvalidOperationException($"Entity with id {associateId} cannot be found");

            operation(associate);
        }

        private async Task<OperatingContextRM> AddOperatingContextForAssociate(Commands.V1.OperatingContext.CreateForAssociate cmd)
        {
            Associate associate = await _repository.LoadAssociate(AssociateId.FromInt(cmd.AssociateId));

            if (associate == null)
                throw new InvalidOperationException($"Associate with id {cmd.AssociateId} cannot be found");

            OperatingContext operatingContext = new OperatingContext(OperatingContextTypeLookup.OperatingContextTypes[cmd.OperatingContextType], cmd.FacilityId,
                cmd.ThirdPartySupplierId, ActingAssociateTypeLookup.ActingAssociateTypes[cmd.ActingBATypeID], cmd.CertificationId, cmd.IsDeactivating,
                cmd.LegacyId, cmd.PrimaryAddressId, cmd.PrimaryEmailId, cmd.PrimaryPhoneId,
                cmd.ProviderType, cmd.StartDate, StatusCodeLookup.StatusCodes[cmd.Status]);

            _repository.AddOperatingContext(operatingContext);
            _repository.AddAssociateOperatingContext(associate, operatingContext);

            //associate.OperatingContexts.AddAssociate(operatingContext);

            return _mapper.Map<OperatingContextRM>(operatingContext);
        }

        private AssociateRM CreateAssociate(Commands.V1.Associate.Create cmd)
        {
            if (_repository.AssociateExists(cmd.DUNSNumber))
                throw new InvalidOperationException($"Associate with DUNSNumber {cmd.DUNSNumber} already exists");

            Associate associate = Associate.Create(_associates++, cmd.DUNSNumber, cmd.LongName, cmd.ShortName, cmd.IsInternal, cmd.IsParent, cmd.IsDeactivating,
                AssociateTypeLookup.AssociateTypes[cmd.AssociateTypeId], StatusCodeLookup.StatusCodes[cmd.StatusCodeId]);
            _repository.AddAssociate(associate);

            return GetAssociateRM(associate);
        }

        private ContactConfigurationRM CreateContactConfigurationForContact(Commands.V1.Contact.ContactConfiguration.CreateForContact cmd)
        {
            ContactConfiguration contactConfiguration = ContactConfiguration.Create(_contactConfigurations++, cmd.StartDate, cmd.StatusCodeId, cmd.EndDate, cmd.ContactId, cmd.FacilityId, cmd.ContactTypeId, cmd.Priority);

            if (_repository.ContactConfigurationExistsForContact(contactConfiguration, cmd.ContactId))
                throw new InvalidOperationException($"ContactConfiguration with ContactId {cmd.ContactId} already exists");

            _repository.AddContactConfigurationForContact(cmd.ContactId, contactConfiguration);

            return GetContactConfigurationRM(contactConfiguration);
        }

        private AddressRM CreateAddressForContact(Commands.V1.Contact.Address.CreateForContact cmd)
        {
            Address address = Address.Create(_addresses++, cmd.IsActive, cmd.EndDate, AddressLine.Create(cmd.Address1),
                AddressLine.Create(cmd.Address2), AddressLine.Create(cmd.Address3), AddressLine.Create(cmd.Address4), 
                cmd.IsPrimary, AddressTypeLookup.AddressTypes[cmd.AddressType], Attention.Create(cmd.Attention), 
                City.Create(cmd.City), Comments.Create(cmd.Comments), PostalCode.Create(cmd.PostalCode), 
                StateCodeLookup.StateCodes[cmd.GeographicState]);

            if (_repository.AddressExistsForContact(address, cmd.ContactId))
            {
                throw new InvalidOperationException($"Address already exists for contact {cmd.ContactId}");
            }

            _repository.AddAddressForContact(address, cmd.ContactId);

            return GetAddressRM(address);
        }

        private AgentRelationshipRM CreateAgentRelationshipForPrincipal(Commands.V1.AgentRelationship.CreateForPrincipal cmd)
        {
            AgentRelationship agentRelationship = new AgentRelationship();

            if (_repository.AgentRelationshipExistsForPrincipal(agentRelationship, cmd.PrincipalId))
            {
                throw new InvalidOperationException($"Agent Relationship already exists for Associate Principal {cmd.PrincipalId}");
            }

            _repository.AddAgentRelationshipForPrincipal(agentRelationship, cmd.PrincipalId);

            return GetAgentRelationshipRM(agentRelationship);
        }

        private CustomerRM CreateCustomerForOperatingContext(Commands.V1.OperatingContext.Customer.CreateForOperatingContext cmd)
        {
            Customer customer = new Customer();

            if (_repository.CustomerExistsForOperatingContext(customer, cmd.OperatingContextId))
            {
                throw new InvalidOperationException($"Customer already already exists for Operating Context {cmd.OperatingContextId}");
            }

            _repository.AddCustomerForOperatingContext(customer, cmd.OperatingContextId);

            return GetCustomerRM(customer);
        }

        private OperatingContextRM CreateOperatingContextForCustomer(Commands.V1.Customer.OperatingContext.CreateForCustomer cmd)
        {
            OperatingContext operatingContext = new OperatingContext();

            if (_repository.OperatingContextExistsForCustomer(operatingContext, cmd.CustomerId))
            {
                throw new InvalidOperationException($"Operating context already exists for Customer {cmd.CustomerId}");
            }

            _repository.AddOperatingContextForCustomer(operatingContext, cmd.CustomerId);

            return GetOperatingContextRM(operatingContext);
        }

        // TO DO:  There is probably a better return value than bool here
        private bool CreateAlternateFuelForCustomer(Commands.V1.OperatingContext.Customer.AlternateFuel.CreateForCustomer cmd)
        {
            if (_repository.AlternateFuelExistsForCustomer(cmd.AlternateFuelId, cmd.CustomerId))
            {
                throw new InvalidOperationException($"Alternate fuel already exists for Customer {cmd.CustomerId}");
            }

            _repository.AddAlternateFuelForCustomer(cmd.AlternateFuelId, cmd.CustomerId);

            return true;
        }

        // This API looks a lot like the one above, but they are for different contexts
        private bool CreateAlternateFuelForCustomer(Commands.V1.Customer.AlternateFuel.CreateForCustomer cmd)
        {
            if (_repository.AlternateFuelExistsForCustomer(cmd.AlternateFuelId, cmd.CustomerId))
            {
                throw new InvalidOperationException($"Alternate fuel already exists for Customer {cmd.CustomerId}");
            }

            _repository.AddAlternateFuelForCustomer(cmd.AlternateFuelId, cmd.CustomerId);

            return true;
        }

        private EGMSPermissionRM CreateEGMSPermission(Commands.V1.EGMSPermission.Create cmd)
        {
            if (_repository.PermissionExists(cmd.PermissionName))
                throw new InvalidOperationException($"Permission with name {cmd.PermissionName} already exists");

            EGMSPermission permission = new EGMSPermission();

            _repository.AddPermission(permission);

            return GetEGMSPermissionRM(permission);
        }

        private AddressRM CreateAddressForOperatingContext(Commands.V1.OperatingContext.Address.CreateForOperatingContext cmd)
        {
            Address address = new Address();

            if (_repository.AddressExistsForOperatingContext(address, cmd.OperatingContextId))
            {
                throw new InvalidOperationException($"Address already exists for Operating Context {cmd.OperatingContextId}");
            }

            _repository.AddAddressForOperatingContext(address, cmd.OperatingContextId);

            return GetAddressRM(address);
        }

        private RoleRM CreateRole(Commands.V1.Role.Create cmd)
        {
            if (_repository.RoleExists(cmd.RoleName))
                throw new InvalidOperationException($"Role with name {cmd.RoleName} already exists");

            Role role = new Role();

            _repository.AddRole(role);

            return GetRoleRM(role);
        }

        private RoleEGMSPermissionRM CreateRoleEGMSPermission(Commands.V1.RoleEGMSPermission.Create cmd)
        {
            RoleEGMSPermission roleEGMSPermission = new RoleEGMSPermission();

            if (_repository.RoleEGMSPermissionExists(cmd.RoleId, cmd.EGMSPermissionId))
            {
                throw new InvalidOperationException($"RoleEGMSPermission already exists for Role {cmd.RoleId} and EGMSPermission {cmd.EGMSPermissionId}");
            }

            _repository.AddRoleEGMSPermission(roleEGMSPermission);

            return GetRoleEGMSPermissionRM(roleEGMSPermission);
        }

        private UserRM CreateUserForAssociate(Commands.V1.User.CreateForAssociate cmd)
        {
            User user = new User();

            if (_repository.UserExistsForAssociate(user, cmd.AssociateId))
            {
                throw new InvalidOperationException($"User already exists for Associate {cmd.AssociateId}");
            }

            _repository.AddUserForAssociate(user, cmd.AssociateId);

            return GetUserRM(user);
        }

        private EMailRM CreateEMailForContact(Commands.V1.Contact.EMail.CreateForContact cmd)
        {
            EMail eMail = new EMail();

            if (_repository.EMailExistsForContact(eMail, cmd.ContactId))
            {
                throw new InvalidOperationException($"EMail already exists for Contact {cmd.ContactId}");
            }

            _repository.AddEMailForContact(eMail, cmd.ContactId);

            return GetEMailRM(eMail);
        }

        private CertificationRM CreateCertificationForOperatingContext(Commands.V1.OperatingContext.Certification.CreateForOperatingContext cmd)
        {
            Certification certification = new Certification();

            if (_repository.CertificationExistsForOperatingContext(certification, cmd.OperatingContextId))
            {
                throw new InvalidOperationException($"Certification already exists for Operating Context {cmd.OperatingContextId}");
            }

            _repository.AddCertificationForOperatingContext(certification, cmd.OperatingContextId);

            return GetCertificationRM(certification);
        }

        private PhoneRM CreatePhoneForContact(Commands.V1.Contact.Phone.CreateForContact cmd)
        {
            throw new NotImplementedException();
        }

        private OperatingContextRM UpdateOperatingContext(Commands.V1.OperatingContext.Update cmd)
        {
            throw new NotImplementedException();
        }

        private AddressRM UpdateAddressForContact(Commands.V1.Contact.Address.Update cmd)
        {
            throw new NotImplementedException();
        }

        private CustomerRM CreateCustomerForAssociate(Commands.V1.Customer.CreateForAssociate cmd)
        {
            throw new NotImplementedException();
        }
        
        private UserRM CreateUserForAgent(Commands.V1.AgentRelationship.User.CreateForAgent cmd)
        {
            throw new NotImplementedException();
        }
        
        private ContactRM CreateContactForAssociate(Commands.V1.Contact.CreateForAssociate cmd)
        {
            Associate associate = _repository.LoadAssociate(cmd.AssociateId).Result;

            Contact contact = Contact.Create(cmd.AssociateId, cmd.PrimaryAddressId, cmd.IsActive, cmd.PrimaryEmailId, cmd.PrimaryPhoneId, cmd.FirstName, cmd.LastName,
                   cmd.Title);
            _repository.AddContactForAssociate(associate, contact);

            return GetContactRM(contact);
        }

        AssociateRM GetAssociateRM(Associate associate)
        {
            AssociateRM associateRM = new AssociateRM();
            associateRM.AssociateType = associate.AssociateTypeId;
            associateRM.DUNSNumber = associate.DUNSNumber;
            associateRM.Id = associate.Id;
            associateRM.IsDeactivating = associate.IsDeactivating;
            associateRM.IsInternal = associate.IsInternal;
            associateRM.IsParent = associate.IsParent;
            associateRM.LongName = associate.LongName;
            associateRM.ShortName = associate.ShortName;
            associateRM.StatusCode = associate.StatusCodeId;

            return associateRM;
        }

        ContactRM GetContactRM(Contact contact)
        {
            ContactRM contactRM = new ContactRM();

            contactRM.PrimaryAddressId = contact.PrimaryAddressId;
            contactRM.FirstName = contact.FirstName;
            contactRM.IsActive = contact.IsActive;
            contactRM.LastName = contact.LastName;
            contactRM.PrimaryEmailId = contact.PrimaryEmailId;
            contactRM.PrimaryPhoneId = contact.PrimaryPhoneId;
            contactRM.Title = contact.Title;

            return contactRM;
        }

        ContactConfigurationRM GetContactConfigurationRM(ContactConfiguration contactConfiguration)
        {
            ContactConfigurationRM contactConfigurationRM = new ContactConfigurationRM();

            contactConfigurationRM.Id = contactConfiguration.Id;
            contactConfigurationRM.ContactId = contactConfiguration.ContactId;
            contactConfigurationRM.ContactTypeId = contactConfiguration.ContactTypeId;
            contactConfigurationRM.EndDate = contactConfiguration.EndDate;
            contactConfigurationRM.Priority = contactConfiguration.Priority;
            contactConfigurationRM.StartDate = contactConfiguration.StartDate; 
            contactConfigurationRM.StatusCodeId = contactConfiguration.StatusCodeId;

            return contactConfigurationRM;
        }

        UserRM GetUserRM(User user)
        {
            UserRM userRM = new UserRM();

            userRM.Id = user.Id;
            userRM.ContactId = user.ContactId;
            userRM.DeactivationDate = user.DeactivationDate;
            userRM.DepartmentCode = user.DepartmentCode;
            userRM.HasEGMSAccess = user.HasEGMSAccess;
            userRM.IDMSSID = user.IDMSSID.Value;
            userRM.IsActive = user.IsActive;
            userRM.IsInternal = user.IsInternal;

            return userRM;
        }

        private EMailRM GetEMailRM(EMail email)
        {
            EMailRM emailRM = new EMailRM();

            emailRM.Id = email.Id;
            emailRM.ContactId = email.ContactId;
            emailRM.EMailAddress = email.EMailAddress;
            emailRM.IsPrimary = email.IsPrimary;
            emailRM.UserId = email.UserId;

            return emailRM;
        }

        private AddressRM GetAddressRM(Address address)
        {
            AddressRM addressRM = new AddressRM();

            addressRM.Id = address.Id;
            addressRM.Address1 = address.Address1;
            addressRM.Address2 = address.Address2;
            addressRM.Address3 = address.Address3;
            addressRM.Address4 = address.Address4;
            addressRM.AddressTypeId = address.AddressTypeId;
            addressRM.Attention = address.Attention;
            addressRM.City = address.City;
            addressRM.Comments = address.Comments;
            addressRM.EndDate = address.EndDate;
            addressRM.IsActive = address.IsActive;
            addressRM.IsPrimary = address.IsPrimary;
            addressRM.PostalCode = address.PostalCode;
            addressRM.StartDate = address.StartDate;
            addressRM.StateCodeId = address.StateCodeId;

            return addressRM;
        }

        private AgentRelationshipRM GetAgentRelationshipRM(AgentRelationship agentRelationship)
        {
            AgentRelationshipRM agentRelationshipRM = new AgentRelationshipRM();

            agentRelationshipRM.Id = agentRelationship.Id;
            agentRelationshipRM.StartDate = agentRelationship.StartDate;
            agentRelationshipRM.IsActive = agentRelationship.IsActive;
            agentRelationshipRM.StartDate = agentRelationship.StartDate;
            agentRelationshipRM.AgentId = agentRelationship.AgentId;
            agentRelationshipRM.PrincipalId = agentRelationship.PrincipalId;

            return agentRelationshipRM;
        }

        // TO DO:  No real reason other than to just return an ID
        private EGMSPermissionRM GetEGMSPermissionRM(EGMSPermission permission)
        {
            EGMSPermissionRM egmsPermissionRM = new EGMSPermissionRM();

            egmsPermissionRM.Id = permission.Id;
            egmsPermissionRM.IsActive = permission.IsActive;
            egmsPermissionRM.PermissionName = permission.PermissionName;
            egmsPermissionRM.PermissionDescription = permission.PermissionDescription;

            return egmsPermissionRM;
        }

        private RoleEGMSPermissionRM GetRoleEGMSPermissionRM(RoleEGMSPermission roleEGMSPermission)
        {
            return new RoleEGMSPermissionRM {Id = roleEGMSPermission.Id};
        }

        private CertificationRM GetCertificationRM(Certification certification)
        {
            CertificationRM certificationRM = new CertificationRM();

            certificationRM.Id = certification.Id;
            certificationRM.CertificationStatusId = certification.CertificationStatusId;
            certificationRM.IsInherited = certification.IsInherited;
            certificationRM.DecertificationDateTime = certification.DecertificationDateTime;
            certificationRM.CertificationDateTime = certification.CertificationDateTime;

            return certificationRM;
        }

        private RoleRM GetRoleRM(Role role)
        {
            return new RoleRM {Id = role.Id};
        }

        private CustomerRM GetCustomerRM(Customer customer)
        {
            CustomerRM customerRM = new CustomerRM();

            customerRM.Id = customer.Id;
            customerRM.AccountNumber = customer.AccountNumber;
            customerRM.AlternateCustomerId = customer.AlternateCustomerId;
            customerRM.BalancingLevelId = customer.BalancingLevelId;
            customerRM.BasicPoolId = customer.BasicPoolId;
            customerRM.ContractTypeId = customer.ContractTypeId;
            customerRM.CurrentDemand = customer.CurrentDemand;
            customerRM.CustomerTypeId = customer.CustomerTypeId;
            customerRM.DUNSNumber = customer.DUNSNumber;
            customerRM.DailyInterruptible = customer.DailyInterruptible;
            customerRM.DeliveryLocation = customer.DeliveryLocation;
            customerRM.DeliveryPressure = customer.DeliveryPressure;
            customerRM.DeliveryTypeId = customer.DeliveryTypeId;
            customerRM.EndDate = customer.EndDate;
            customerRM.GroupTypeId = customer.GroupTypeId;
            customerRM.HourlyInterruptible = customer.HourlyInterruptible;
            customerRM.InterstateSpecifiedFirm = customer.InterstateSpecifiedFirm;
            customerRM.IntrastateSpecifiedFirm = customer.IntrastateSpecifiedFirm;
            customerRM.IsFederal = customer.IsFederal;
            customerRM.LDCId = customer.LDCId;
            customerRM.LongName = customer.LongName;
            customerRM.LossTierId = customer.LossTierId;
            customerRM.MDQ = customer.MDQ;
            customerRM.MaxDailyInterruptible = customer.MaxDailyInterruptible;
            customerRM.MaxHourlyInterruptible = customer.MaxHourlyInterruptible;
            customerRM.MaxHourlySpecifiedFirm = customer.MaxHourlySpecifiedFirm;
            customerRM.NAICSCode = customer.NAICSCode.ToString();
            customerRM.NominationLevelId = customer.NominationLevelId;
            customerRM.PreviousDemand = customer.PreviousDemand;
            customerRM.SICCode = customer.SICCode.ToString();
            customerRM.SICCodePercentage = customer.SICCodePercentage;
            customerRM.SS1 = customer.SS1;
            customerRM.ShipperId = customer.ShipperId;
            customerRM.ShippersLetterFromDate = customer.ShippersLetterFromDate;
            customerRM.ShippersLetterToDate = customer.ShippersLetterToDate;
            customerRM.ShippersLetterFromDate = customer.ShippersLetterFromDate;
            customerRM.ShortName = customer.ShortName;
            customerRM.StartDate = customer.StartDate;
            customerRM.StatusCodeId = customer.StatusCodeId;
            customerRM.TotalDailySpecifiedFirm = customer.TotalDailySpecifiedFirm;
            customerRM.TurnOffDate = customer.TurnOffDate;
            customerRM.TotalHourlySpecifiedFirm = customer.TotalHourlySpecifiedFirm;
            customerRM.TurnOnDate = customer.TurnOnDate;
            
            return customerRM;
        }

        private OperatingContextRM GetOperatingContextRM(OperatingContext operatingContext)
        {
            OperatingContextRM operatingContextRM = new OperatingContextRM();

            operatingContextRM.Id = operatingContext.Id;
            operatingContextRM.ActingBAType = operatingContextRM.ActingBAType;
            operatingContextRM.CertificationId = operatingContext.CertificationId;
            operatingContextRM.FacilityId = operatingContext.FacilityId;
            operatingContextRM.IsDeactivating = operatingContext.IsDeactivating;
            operatingContextRM.LegacyId = operatingContext.LegacyId;
            operatingContextRM.OperatingContextType = operatingContext.OperatingContextTypeId;
            operatingContextRM.PrimaryAddress = operatingContext.PrimaryAddressId;
            operatingContextRM.PrimaryEmail = operatingContext.PrimaryEmailId;
            operatingContextRM.PrimaryPhone = operatingContext.PrimaryPhoneId;
            operatingContextRM.ProviderType = operatingContextRM.ProviderType;
            operatingContextRM.StartDate = operatingContext.StartDate;
            operatingContextRM.Status = operatingContext.StatusCodeId;
            operatingContextRM.ThirdPartySupplierId = operatingContext.ThirdPartySupplierId;

            return operatingContextRM;
        }
    }
}