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

                case Commands.V1.Permission.Create cmd:
                    return CreatePermission(cmd);

                case Commands.V1.Role.Create cmd:
                    return CreateRole(cmd);

                case Commands.V1.RolePermission.Create cmd:
                    return CreateRolePermission(cmd);

                case Commands.V1.User.CreateForAssociate cmd:
                    return CreateAssociateForUser(cmd);

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
            throw new NotImplementedException();
        }

        private CustomerRM CreateCustomerForOperatingContext(Commands.V1.OperatingContext.Customer.CreateForOperatingContext cmd)
        {
            throw new NotImplementedException();
        }

        private OperatingContextRM CreateOperatingContextForCustomer(Commands.V1.Customer.OperatingContext.CreateForCustomer cmd)
        {
            throw new NotImplementedException();
        }

        private AlternateFuelRM CreateAlternateFuelForCustomer(Commands.V1.OperatingContext.Customer.AlternateFuel.CreateForCustomer cmd)
        {
            throw new NotImplementedException();
        }

        private AlternateFuelRM CreateAlternateFuelForCustomer(Commands.V1.Customer.AlternateFuel.CreateForCustomer cmd)
        {
            throw new NotImplementedException();
        }

        private EGMSPermissionRM CreatePermission(Commands.V1.Permission.Create cmd)
        {
            throw new NotImplementedException();
        }

        private AddressRM CreateAddressForOperatingContext(Commands.V1.OperatingContext.Address.CreateForOperatingContext cmd)
        {
            throw new NotImplementedException();
        }

        private RoleRM CreateRole(Commands.V1.Role.Create cmd)
        {
            throw new NotImplementedException();
        }

        private RoleEGMSPermissionRM CreateRolePermission(Commands.V1.RolePermission.Create cmd)
        {
            throw new NotImplementedException();
        }

        private AssociateRM CreateAssociateForUser(Commands.V1.User.CreateForAssociate cmd)
        {
            throw new NotImplementedException();
        }

        private EMailRM CreateEMailForContact(Commands.V1.Contact.EMail.CreateForContact cmd)
        {
            throw new NotImplementedException();
        }

        private CertificationRM CreateCertificationForOperatingContext(Commands.V1.OperatingContext.Certification.CreateForOperatingContext cmd)
        {
            throw new NotImplementedException();
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

            // TODO:  Dispatch Events.

            try
            {
                return GetContactRM(contact);
            }
            catch (Exception ex)
            {
                ex = ex;
                throw;
            }
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
    }
}