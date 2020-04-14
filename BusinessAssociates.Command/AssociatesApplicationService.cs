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
        private static int Associates = 1;
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
                    try
                    {
                        return CreateAssociate(cmd);
                    }
                    catch (Exception ex)
                    {
                        ex = ex;
                        throw;
                    }

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
            Associate associate = _repository.Load(associateId).Result;

            if (associate == null)
                throw new InvalidOperationException($"Entity with id {associateId} cannot be found");

            operation(associate);
        }

        private async Task<OperatingContextRM> AddOperatingContextForAssociate(Commands.V1.OperatingContext.CreateForAssociate cmd)
        {
            Associate associate = await _repository.Load(AssociateId.FromInt(cmd.AssociateId));

            if (associate == null)
                throw new InvalidOperationException($"Associate with id {cmd.AssociateId} cannot be found");

            OperatingContext operatingContext = new OperatingContext(OperatingContextTypeLookup.OperatingContextTypes[cmd.OperatingContextType], cmd.FacilityId,
                cmd.ThirdPartySupplierId, ActingAssociateTypeLookup.ActingAssociateTypes[cmd.ActingBATypeID], cmd.CertificationId, cmd.IsDeactivating,
                cmd.LegacyId, cmd.PrimaryAddressId, cmd.PrimaryEmailId, cmd.PrimaryPhoneId,
                cmd.ProviderType, cmd.StartDate, StatusCodeLookup.StatusCodes[cmd.Status]);

            _repository.AddOperatingContext(operatingContext);
            _repository.AddAssociateOperatingContext(associate, operatingContext);

            //associate.OperatingContexts.Add(operatingContext);

            return _mapper.Map<OperatingContextRM>(operatingContext);
        }

        private async Task<AssociateRM> CreateAssociate(Commands.V1.Associate.Create cmd)
        {
            if (_repository.Exists(cmd.DUNSNumber))
                throw new InvalidOperationException($"Entity with DUNSNumber {cmd.DUNSNumber} already exists");

            Associate associate = Associate.Create(Associates++, cmd.DUNSNumber, cmd.LongName, cmd.ShortName, cmd.IsInternal, cmd.IsParent, cmd.IsDeactivating,
                AssociateTypeLookup.AssociateTypes[cmd.AssociateTypeId], StatusCodeLookup.StatusCodes[cmd.StatusCodeId]);
            _repository.Add(associate);

            // TODO:  Dispatch Events.

            try
            {
                return GetAssociateRM(associate);
            }
            catch (Exception ex)
            {
                ex = ex;
                throw;
            }
        }

        private async Task<AddressRM> CreateContactConfigurationForContact(Commands.V1.Contact.ContactConfiguration.CreateForContact cmd)
        {
            throw new NotImplementedException();
        }

        private async Task<AddressRM> CreateAddressForContact(Commands.V1.Contact.Address.CreateForContact cmd)
        {
            throw new NotImplementedException();
        }

        private async Task<AddressRM> CreateAgentRelationshipForPrincipal(Commands.V1.AgentRelationship.CreateForPrincipal cmd)
        {
            throw new NotImplementedException();
        }

        private async Task<AddressRM> CreateCustomerForOperatingContext(Commands.V1.OperatingContext.Customer.CreateForOperatingContext cmd)
        {
            throw new NotImplementedException();
        }

        private async Task<AddressRM> CreateOperatingContextForCustomer(Commands.V1.Customer.OperatingContext.CreateForCustomer cmd)
        {
            throw new NotImplementedException();
        }

        private async Task<AddressRM> CreateAlternateFuelForCustomer(Commands.V1.OperatingContext.Customer.AlternateFuel.CreateForCustomer cmd)
        {
            throw new NotImplementedException();
        }

        private async Task<AddressRM> CreateAlternateFuelForCustomer(Commands.V1.Customer.AlternateFuel.CreateForCustomer cmd)
        {
            throw new NotImplementedException();
        }

        private async Task<AddressRM> CreatePermission(Commands.V1.Permission.Create cmd)
        {
            throw new NotImplementedException();
        }

        private async Task<AddressRM> CreateAddressForOperatingContext(Commands.V1.OperatingContext.Address.CreateForOperatingContext cmd)
        {
            throw new NotImplementedException();
        }

        private async Task<AddressRM> CreateRole(Commands.V1.Role.Create cmd)
        {
            throw new NotImplementedException();
        }

        private async Task<AddressRM> CreateRolePermission(Commands.V1.RolePermission.Create cmd)
        {
            throw new NotImplementedException();
        }

        private async Task<AddressRM> CreateAssociateForUser(Commands.V1.User.CreateForAssociate cmd)
        {
            throw new NotImplementedException();
        }

        private async Task<AddressRM> CreateEMailForContact(Commands.V1.Contact.EMail.CreateForContact cmd)
        {
            throw new NotImplementedException();
        }

        private async Task<AddressRM> CreateCertificationForOperatingContext(Commands.V1.OperatingContext.Certification.CreateForOperatingContext cmd)
        {
            throw new NotImplementedException();
        }

        private async Task<AddressRM> CreatePhoneForContact(Commands.V1.Contact.Phone.CreateForContact cmd)
        {
            throw new NotImplementedException();
        }

        private async Task<AddressRM> UpdateOperatingContext(Commands.V1.OperatingContext.Update cmd)
        {
            throw new NotImplementedException();
        }
        private async Task<AddressRM> UpdateAddressForContact(Commands.V1.Contact.Address.Update cmd)
        {
            throw new NotImplementedException();
        }

        private async Task<AddressRM> CreateCustomerForAssociate(Commands.V1.Customer.CreateForAssociate cmd)
        {
            throw new NotImplementedException();
        }


        private async Task<AddressRM> CreateUserForAgent(Commands.V1.AgentRelationship.User.CreateForAgent cmd)
        {
            throw new NotImplementedException();
        }


        private async Task<AssociateRM> CreateContactForAssociate(Commands.V1.Contact.CreateForAssociate cmd)
        {
            Associate associate = _repository.Load(cmd.AssociateId).Result;

            Contact contact = Contact.Create(cmd.AssociateId, cmd.PrimaryAddressId, cmd.IsActive, cmd.PrimaryEmailId, cmd.PrimaryPhoneId, cmd.FirstName, cmd.LastName,
                   cmd.Title);
            _repository.AddContactForAssociate(associate, contact);

            // TODO:  Dispatch Events.

            try
            {
                return GetAssociateRM(associate);
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
    }
}