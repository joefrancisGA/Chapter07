using System;
using System.Threading.Tasks;
using AutoMapper;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.Repositories;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using EGMS.BusinessAssociates.Query.ReadModels;
using IApplicationService = EGMS.BusinessAssociates.Framework.IApplicationService;


namespace EGMS.BusinessAssociates.Command
{
    public class AssociatesApplicationService : IApplicationService
    {
        private static int _addresses = 1;
        private static int _agentRelationships = 1;
        private static int _associates = 1;
        private static int _certifications = 1;
        private static int _contacts = 1;
        private static int _contactConfigurations = 1;
        private static int _customers = 1;
        private static int _emails = 1;
        private static int _operatingContexts = 1;
        private static int _permissions = 1;
        private static int _phones = 1;
        private static int _roleEGMSPermissions = 1;
        private static int _roles = 1;
        private static int _users = 1;
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
                    UpdateAssociate(cmd.Id, ia => ia.UpdateDUNSNumber(DUNSNumber.Create(cmd.DUNSNumber)));
                    break;

                case Commands.V1.Associate.UpdateAssociateType cmd:
                    UpdateAssociate(cmd.Id, ia => ia.UpdateAssociateType(AssociateTypeLookup.AssociateTypes[cmd.AssociateType]));
                    break;

                case Commands.V1.Associate.UpdateLongName cmd:
                    UpdateAssociate(cmd.Id, ia => ia.UpdateLongName(LongName.Create(cmd.LongName)));
                    break;

                case Commands.V1.Associate.UpdateIsParent cmd:
                    UpdateAssociate(cmd.Id, ia => ia.UpdateIsParent(cmd.IsParent));
                    break;

                case Commands.V1.Associate.UpdateStatus cmd:
                    UpdateAssociate(cmd.Id, ia => ia.UpdateStatus(StatusCodeLookup.StatusCodes[cmd.Status]));
                    break;

                case Commands.V1.Associate.UpdateShortName cmd:
                    UpdateAssociate(cmd.Id, ia => ia.UpdateShortName(ShortName.Create(cmd.ShortName)));
                    break;

                case Commands.V1.Associate.Phone.CreateForAssociate cmd:
                    return CreatePhoneForAssociate(cmd);

                case Commands.V1.Associate.EMail.CreateForAssociate cmd:
                    return CreateEMailForAssociate(cmd);

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
                    UpdateAddressForContact(cmd);
                    break;

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
                    return CreateOperatingContextForAssociate(cmd);

                case Commands.V1.OperatingContext.CreateForCustomer cmd:
                    return CreateOperatingContextForCustomer(cmd);

                case Commands.V1.Associate.Address.CreateForAssociate cmd:
                    return CreateAddressForAssociate(cmd);

                case Commands.V1.OperatingContext.Certification.CreateForOperatingContext cmd:
                    return CreateCertificationForOperatingContext(cmd);

                case Commands.V1.OperatingContext.Customer.CreateForOperatingContext cmd:
                    return CreateCustomerForOperatingContext(cmd);

                case Commands.V1.OperatingContext.Customer.AlternateFuel.CreateForCustomer cmd:
                    return CreateAlternateFuelForCustomer(cmd);

                case Commands.V1.OperatingContext.Update cmd:
                    UpdateOperatingContext(cmd);
                    return null;

                #endregion


                default:
                    throw new InvalidOperationException($"Commands type {command.GetType().FullName} is unknown");
            }

            return null;
        }

#pragma warning disable 1998
        private async void UpdateAssociate(int associateId, Action<Associate> operation)
#pragma warning restore 1998
        {
            Associate associate = _repository.GetAssociate(associateId);

            if (associate == null)
                throw new InvalidOperationException($"Associate with id {associateId} cannot be found");

            operation(associate);
        }

        private OperatingContextRM CreateOperatingContextForAssociate(Commands.V1.OperatingContext.CreateForAssociate cmd)
        {
            Associate associate = _repository.GetAssociate(AssociateId.FromInt(cmd.AssociateId));

            if (associate == null)
                throw new InvalidOperationException($"Associate with id {cmd.AssociateId} cannot be found");

            OperatingContext operatingContext = new OperatingContext(_operatingContexts++, OperatingContextTypeLookup.OperatingContextTypes[cmd.OperatingContextType], cmd.FacilityId,
                cmd.ThirdPartySupplierId, ExternalAssociateTypeLookup.ActingAssociateTypes[cmd.ActingBATypeID], cmd.CertificationId, cmd.IsDeactivating,
                cmd.LegacyId, cmd.PrimaryAddressId, cmd.PrimaryEmailId, cmd.PrimaryPhoneId,
                cmd.ProviderType, cmd.StartDate, StatusCodeLookup.StatusCodes[cmd.Status]);

            _repository.AddOperatingContextForAssociate(operatingContext, associate.Id);

            return Conversions.GetOperatingContextRM(operatingContext);
        }

 private AssociateRM CreateAssociate(Commands.V1.Associate.Create cmd)
        {
            if (_repository.AssociateExists(cmd.DUNSNumber))
                throw new InvalidOperationException($"Associate with DUNSNumber {cmd.DUNSNumber} already exists");

            Associate associate = Associate.Create(_associates++, cmd.DUNSNumber, cmd.LongName, cmd.ShortName, cmd.IsInternal, 
                cmd.IsParent, cmd.IsDeactivating, AssociateTypeLookup.AssociateTypes[cmd.AssociateTypeId], 
                StatusCodeLookup.StatusCodes[cmd.StatusCodeId]);

            _repository.AddAssociate(associate);

            return _mapper.Map<Associate, AssociateRM>(associate);
        }

        private ContactConfigurationRM CreateContactConfigurationForContact(Commands.V1.Contact.ContactConfiguration.CreateForContact cmd)
        {
            ContactConfiguration contactConfiguration = ContactConfiguration.Create(_contactConfigurations++, cmd.StartDate, 
                cmd.StatusCodeId, cmd.EndDate, cmd.ContactId, cmd.FacilityId, cmd.ContactTypeId, cmd.Priority);

            if (_repository.ContactConfigurationExistsForContact(contactConfiguration, cmd.ContactId))
                throw new InvalidOperationException($"ContactConfiguration with ContactId {cmd.ContactId} already exists");

            _repository.AddContactConfigurationForContact(contactConfiguration, cmd.ContactId);

            return Conversions.GetContactConfigurationRM(contactConfiguration);
        }

        private AddressRM CreateAddressForContact(Commands.V1.Contact.Address.CreateForContact cmd)
        {
            Address address = Address.Create(_addresses++, cmd.IsActive, cmd.EndDate, AddressLine.Create(cmd.Address1),
                AddressLine.Create(cmd.Address2), AddressLine.Create(cmd.Address3), AddressLine.Create(cmd.Address4), 
                cmd.IsPrimary, AddressTypeLookup.AddressTypes[cmd.AddressType], Attention.Create(cmd.Attention), 
                City.Create(cmd.City), cmd.Comments, PostalCode.Create(cmd.PostalCode), 
                StateCodeLookup.StateCodes[cmd.GeographicState]);

            if (_repository.AddressExistsForContact(address, cmd.ContactId))
            {
                throw new InvalidOperationException($"Address already exists for contact {cmd.ContactId}");
            }

            _repository.AddAddressForContact(address, cmd.ContactId);

            return Conversions.GetAddressRM(address);
        }

        private AgentRelationshipRM CreateAgentRelationshipForPrincipal(Commands.V1.AgentRelationship.CreateForPrincipal cmd)
        {
            AgentRelationship agentRelationship = AgentRelationship.Create(_agentRelationships++, cmd.IsActive, cmd.EndDate, 
                cmd.AgentId, cmd.PrincipalId, cmd.StartDate );

            if (_repository.AgentRelationshipExistsForPrincipal(agentRelationship, cmd.PrincipalId))
            {
                throw new InvalidOperationException($"Agent Relationship already exists for Associate Principal {cmd.PrincipalId}");
            }

            _repository.AddAgentRelationship(agentRelationship);

            return Conversions.GetAgentRelationshipRM(agentRelationship);
        }

        private CustomerRM CreateCustomerForOperatingContext(Commands.V1.OperatingContext.Customer.CreateForOperatingContext cmd)
        {
            Customer customer = Customer.Create(_customers++, cmd.StartDate, cmd.EndDate, cmd.StatusCodeId, 
                cmd.NominationLevelId, AccountNumber.Create(cmd.AccountNumber), cmd.CustomerTypeId, cmd.DeliveryTypeId, 
                DUNSNumber.Create(cmd.DUNSNumber), LongName.Create(cmd.LongName), ShortName.Create(cmd.ShortName), 
                cmd.LDCId, cmd.LossTierTypeId, cmd.DeliveryLocationId, cmd.ShipperId, cmd.DeliveryPressure, 
                cmd.MDQ, cmd.MaxHourlyInterruptible, cmd.MaxDailyInterruptible, cmd.HourlyInterruptible, 
                cmd.DailyInterruptible, cmd.TotalHourlySpecifiedFirm, cmd.TotalDailySpecifiedFirm,
                cmd.InterstateSpecifiedFirm, cmd.IntrastateSpecifiedFirm, cmd.CurrentDemand, cmd.PreviousDemand,
                cmd.GroupTypeId, cmd.BalancingLevelId, new NAICSCode(cmd.NAICSCode), SICCode.Create(cmd.SICCode), cmd.SICCodePercentage,
                cmd.ShippersLetterFromDate, cmd.ShippersLetterToDate, cmd.SS1, cmd.IsFederal, cmd.TurnOffDate,
                cmd.TurnOnDate);
            

            if (_repository.CustomerExistsForOperatingContext(customer, cmd.OperatingContextId))
            {
                throw new InvalidOperationException($"Customer already already exists for Operating Context {cmd.OperatingContextId}");
            }

            _repository.AddCustomerForOperatingContext(customer, cmd.OperatingContextId);

            return Conversions.GetCustomerRM(customer);
        }

        private OperatingContextRM CreateOperatingContextForCustomer(Commands.V1.OperatingContext.CreateForCustomer cmd)
        {
            OperatingContext operatingContext = new OperatingContext(_operatingContexts++, OperatingContextTypeLookup.OperatingContextTypes[cmd.OperatingContextType],
                cmd.FacilityId, cmd.ThirdPartySupplierId, ExternalAssociateTypeLookup.ActingAssociateTypes[cmd.ActingBATypeID],
                cmd.CertificationId, cmd.IsDeactivating, cmd.LegacyId, cmd.PrimaryAddressId,
                cmd.PrimaryEmailId, cmd.PrimaryPhoneId, cmd.ProviderType, cmd.StartDate, StatusCodeLookup.StatusCodes[cmd.Status]);

            if (_repository.OperatingContextExistsForCustomer(operatingContext, cmd.CustomerId))
            {
                throw new InvalidOperationException($"Operating context already exists for Customer {cmd.CustomerId}");
            }

            _repository.AddOperatingContextForCustomer(operatingContext, cmd.CustomerId);

            return Conversions.GetOperatingContextRM(operatingContext);
        }

        // TO DO:  There is probably a better return value than bool here
        private bool CreateAlternateFuelForCustomer(Commands.V1.OperatingContext.Customer.AlternateFuel.CreateForCustomer cmd)
        {
            if (_repository.AlternateFuelExistsForCustomer(cmd.AlternateFuelId, cmd.CustomerId))
            {
                throw new InvalidOperationException($"Alternate fuel already exists for Customer {cmd.CustomerId}");
            }

            _repository.LinkAlternateFuelToCustomer(cmd.AlternateFuelId, cmd.CustomerId);

            return true;
        }

        // This API looks a lot like the one above, but they are for different contexts
        private bool CreateAlternateFuelForCustomer(Commands.V1.Customer.AlternateFuel.CreateForCustomer cmd)
        {
            if (_repository.AlternateFuelExistsForCustomer(cmd.AlternateFuelId, cmd.CustomerId))
            {
                throw new InvalidOperationException($"Alternate fuel already exists for Customer {cmd.CustomerId}");
            }

            _repository.LinkAlternateFuelToCustomer(cmd.AlternateFuelId, cmd.CustomerId);

            return true;
        }

        private EGMSPermissionRM CreateEGMSPermission(Commands.V1.EGMSPermission.Create cmd)
        {
            if (_repository.PermissionExists(cmd.PermissionName))
                throw new InvalidOperationException($"Permission with name {cmd.PermissionName} already exists");

            EGMSPermission permission = EGMSPermission.Create(_permissions++, PermissionName.Create(cmd.PermissionName), 
                PermissionDescription.Create(cmd.PermissionDescription), cmd.IsActive);

            _repository.AddPermission(permission);

            return Conversions.GetEGMSPermissionRM(permission);
        }

        private AddressRM CreateAddressForAssociate(Commands.V1.Associate.Address.CreateForAssociate cmd)
        {
            Address address = Address.Create(_addresses++, cmd.IsActive, cmd.EndDate, AddressLine.Create(cmd.Address1),
                AddressLine.Create(cmd.Address2), AddressLine.Create(cmd.Address3), AddressLine.Create(cmd.Address4),
                cmd.IsPrimary, AddressTypeLookup.AddressTypes[cmd.AddressType], Attention.Create(cmd.Attention),
                City.Create(cmd.City), cmd.Comments, PostalCode.Create(cmd.PostalCode),
                StateCodeLookup.StateCodes[cmd.GeographicState]);

            if (_repository.AddressExistsForAssociate(address, cmd.AssociateId))
            {
                throw new InvalidOperationException($"Address already exists for Operating Context {cmd.AssociateId}");
            }

            _repository.AddAddressForAssociate(address, cmd.AssociateId);

            return Conversions.GetAddressRM(address);
        }

        private RoleRM CreateRole(Commands.V1.Role.Create cmd)
        {
            if (_repository.RoleExists(cmd.RoleName))
                throw new InvalidOperationException($"Role with name {cmd.RoleName} already exists");

            Role role = Role.Create(_roles++, RoleName.Create(cmd.RoleName), RoleDescription.Create(cmd.RoleDescription),
                cmd.IsActive);

            _repository.AddRole(role);

            return Conversions.GetRoleRM(role);
        }

        private RoleEGMSPermissionRM CreateRoleEGMSPermission(Commands.V1.RoleEGMSPermission.Create cmd)
        {
            RoleEGMSPermission roleEGMSPermission = RoleEGMSPermission.Create(_roleEGMSPermissions++, cmd.RoleId, 
                cmd.EGMSPermissionId);

            if (_repository.RoleEGMSPermissionExists(cmd.RoleId, cmd.EGMSPermissionId))
            {
                throw new InvalidOperationException($"RoleEGMSPermission already exists for Role {cmd.RoleId} and EGMSPermission {cmd.EGMSPermissionId}");
            }

            _repository.AddRoleEGMSPermission(roleEGMSPermission);

            return Conversions.GetRoleEGMSPermissionRM(roleEGMSPermission);
        }

        private UserRM CreateUserForAssociate(Commands.V1.User.CreateForAssociate cmd)
        {
            User user = User.Create(_users++, cmd.ContactId, IDMSSID.Create(cmd.IDMSSID), cmd.DepartmentCodeId, 
                cmd.IsInternal, cmd.IsActive, cmd.HasEGMSAccess, cmd.DeactivationDate);

            if (_repository.UserExistsForAssociate(user, cmd.AssociateId))
            {
                throw new InvalidOperationException($"User already exists for Associate {cmd.AssociateId}");
            }

            _repository.AddUserForAssociate(user, cmd.AssociateId);

            return Conversions.GetUserRM(user);
        }

        private EMailRM CreateEMailForContact(Commands.V1.Contact.EMail.CreateForContact cmd)
        {
            EMail eMail = EMail.CreateForContact(_emails++, EMailAddress.Create(cmd.EMailAddress), cmd.IsPrimary,
                cmd.ContactId);

            if (_repository.EMailExistsForContact(eMail, cmd.ContactId))
            {
                throw new InvalidOperationException($"EMail already exists for Contact {cmd.ContactId}");
            }

            _repository.AddEMailForContact(eMail, cmd.ContactId);

            return Conversions.GetEMailRM(eMail);
        }

        private CertificationRM CreateCertificationForOperatingContext(Commands.V1.OperatingContext.Certification.CreateForOperatingContext cmd)
        {
            Certification certification = Certification.Create(_certifications++, cmd.CertificationStatusId, cmd.CertificationDateTime,
                cmd.DecertificationDateTime, cmd.IsInherited, cmd.OperatingContextId);

            if (_repository.CertificationExistsForOperatingContext(certification, cmd.OperatingContextId))
            {
                throw new InvalidOperationException($"Certification already exists for Operating Context {cmd.OperatingContextId}");
            }

            _repository.AddCertificationForOperatingContext(certification, cmd.OperatingContextId);

            return Conversions.GetCertificationRM(certification);
        }

        private PhoneRM CreatePhoneForAssociate(Commands.V1.Associate.Phone.CreateForAssociate cmd)
        {
            Phone phone = Phone.CreateForAssociate(_phones++, cmd.IsPrimary, cmd.AssociateId, Extension.Create(cmd.Extension), 
                PhoneTypeLookup.PhoneTypes[cmd.PhoneTypeId]);

            if (_repository.PhoneExistsForAssociate(phone, cmd.AssociateId))
            {
                throw new InvalidOperationException($"Phone already exists for Associate {cmd.AssociateId}");
            }

            _repository.AddPhoneForAssociate(phone, cmd.AssociateId);

            return Conversions.GetPhoneRM(phone);
        }

        private EMailRM CreateEMailForAssociate(Commands.V1.Associate.EMail.CreateForAssociate cmd)
        {
            EMail email = EMail.CreateForAssociate(_emails++, EMailAddress.Create(cmd.EMailAddress), cmd.IsPrimary, cmd.AssociateId);

            if (_repository.EMailExistsForAssociate(email, cmd.AssociateId))
            {
                throw new InvalidOperationException($"EMail already exists for Associate {cmd.AssociateId}");
            }

            _repository.AddEMailForAssociate(email, cmd.AssociateId);

            return Conversions.GetEMailRM(email);
        }

        private PhoneRM CreatePhoneForContact(Commands.V1.Contact.Phone.CreateForContact cmd)
        {
            Phone phone = Phone.CreateForContact(_phones++, cmd.IsPrimary, cmd.ContactId, Extension.Create(cmd.Extension),
                PhoneTypeLookup.PhoneTypes[cmd.PhoneTypeId]);

            if (_repository.PhoneExistsForContact(phone, cmd.ContactId))
            {
                throw new InvalidOperationException($"Phone already exists for Contact {cmd.ContactId}");
            }

            _repository.AddPhoneForContact(phone, cmd.ContactId);

            return Conversions.GetPhoneRM(phone);
        }

        private void UpdateOperatingContext(Commands.V1.OperatingContext.Update cmd)
        {
            OperatingContext operatingContext = _repository.GetOperatingContext(cmd.OperatingContextId);

            if (operatingContext == null)
                throw new InvalidOperationException($"OperatingContext with id {cmd.OperatingContextId} cannot be found");

            _repository.UpdateOperatingContext(operatingContext);
        }


        // TO DO:  Need to actually move over the updated fields
        private void UpdateAddressForContact(Commands.V1.Contact.Address.Update cmd)
        {
            Address address = _repository.GetAddress(cmd.AddressId);

            if (address == null)
                throw new InvalidOperationException($"Address with id {cmd.AddressId} for Operating Context {cmd.OperatingContextId}cannot be found");

            _repository.UpdateAddress(address);
        }

        private CustomerRM CreateCustomerForAssociate(Commands.V1.Customer.CreateForAssociate cmd)
        {
            Customer customer = Customer.Create(_customers++, cmd.StartDate, cmd.EndDate, cmd.StatusCodeId,
                cmd.NominationLevelId, AccountNumber.Create(cmd.AccountNumber), cmd.CustomerTypeId, cmd.DeliveryTypeId,
                DUNSNumber.Create(cmd.DUNSNumber), LongName.Create(cmd.LongName), ShortName.Create(cmd.ShortName),
                cmd.LDCId, cmd.LossTierTypeId, cmd.DeliveryLocationId, cmd.ShipperId, cmd.DeliveryPressure,
                cmd.MDQ, cmd.MaxHourlyInterruptible, cmd.MaxDailyInterruptible, cmd.HourlyInterruptible,
                cmd.DailyInterruptible, cmd.TotalHourlySpecifiedFirm, cmd.TotalDailySpecifiedFirm,
                cmd.InterstateSpecifiedFirm, cmd.IntrastateSpecifiedFirm, cmd.CurrentDemand, cmd.PreviousDemand,
                cmd.GroupTypeId, cmd.BalancingLevelId, new NAICSCode(cmd.NAICSCode), SICCode.Create(cmd.SICCode), cmd.SICCodePercentage,
                cmd.ShippersLetterFromDate, cmd.ShippersLetterToDate, cmd.SS1, cmd.IsFederal, cmd.TurnOffDate,
                cmd.TurnOnDate);

            if (_repository.CustomerExistsForAssociate(customer, cmd.AssociateId))
            {
                throw new InvalidOperationException($"Customer already exists for Associate {cmd.AssociateId}");
            }

            _repository.AddCustomerForAssociate(customer, cmd.AssociateId);

            return Conversions.GetCustomerRM(customer);
        }
        
        // TO DO:  Combine with CreateUserForAssociate
        private UserRM CreateUserForAgent(Commands.V1.AgentRelationship.User.CreateForAgent cmd)
        {
            User user = User.Create(_users++, cmd.ContactId, IDMSSID.Create(cmd.IDMSSID), cmd.DepartmentCodeId,
                cmd.IsInternal, cmd.IsActive, cmd.HasEGMSAccess, cmd.DeactivationDate);

            if (_repository.UserExistsForAssociate(user, cmd.AgentId))
            {
                throw new InvalidOperationException($"User already exists for Associate {cmd.AgentId}");
            }

            _repository.AddUserForAssociate(user, cmd.AgentId);

            return Conversions.GetUserRM(user);
        }
        
        private ContactRM CreateContactForAssociate(Commands.V1.Contact.CreateForAssociate cmd)
        {
            Contact contact = Contact.Create(_contacts++, cmd.PrimaryAddressId, cmd.IsActive, cmd.PrimaryEmailId, 
                cmd.PrimaryPhoneId, FirstName.Create(cmd.FirstName), LastName.Create(cmd.LastName), Title.Create(cmd.Title));
            _repository.AddContactForAssociate(contact, cmd.AssociateId);

            return Conversions.GetContactRM(contact);
        }
    }
}