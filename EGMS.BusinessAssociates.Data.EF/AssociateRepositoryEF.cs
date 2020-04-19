using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace EGMS.BusinessAssociates.Data.EF
{
    public class AssociateRepositoryEF : IAssociateRepository
    {
        private readonly BusinessAssociatesContext _context;

        // TO DO:  Need to use logging
        // ReSharper disable once NotAccessedField.Local
        private readonly ILogger _log;
        private readonly IMapper _mapper;

        // ReSharper disable once SuggestBaseTypeForParameter
        public AssociateRepositoryEF(BusinessAssociatesContext context, ILogger<AssociateRepositoryEF> log, IMapper mapper)
        {
            _context = context;
            _log = log;
            _mapper = mapper;
        }

        public Customer AddCustomerForOperatingContext(Customer customer, int operatingContextId)
        {
            try
            {
                _context.Customers.Add(customer);

                _context.OperatingContextCustomers.Add(new OperatingContextCustomer
                {
                    OperatingContextId = operatingContextId,
                    CustomerId = customer.Id
                });

                return customer;
            }
            catch
            {
                Customer toRemove = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                if (toRemove != null)
                    _context.Customers.Remove(toRemove);

                throw;
            }
        }

        public bool PermissionExists(string permissionName)
        {
            return _context.EGMSPermissions.Exists(p => p.PermissionName == permissionName);
        }

        public void AddPermission(EGMSPermission permission)
        {
            _context.EGMSPermissions.Add(permission);
        }

        public bool AddressExistsForOperatingContext(Address address, int operatingContextId)
        {
            return _context.OperatingContexts[operatingContextId].Addresses.FirstOrDefault(a => a == address) != null;
        }

        public void AddAddressForOperatingContext(Address address, int operatingContextId)
        {
            _context.OperatingContexts[operatingContextId].Addresses.Add(address);
        }

        public bool AlternateFuelExistsForCustomer(int alternateFuelTypeId, int customerId)
        {
            return _context.CustomerAlternateFuels.Exists(caf =>
                caf.CustomerId == customerId && caf.AlternateFuelTypeId == alternateFuelTypeId);
        }

        public void AddAlternateFuelForCustomer(int alternateFuelTypeId, int customerId)
        {
            _context.Customers[customerId].CustomerAlternateFuels
                .Add(new CustomerAlternateFuel(customerId, alternateFuelTypeId));
        }

        public void AddOperatingContextForCustomer(OperatingContext operatingContext, int customerId)
        {
            _context.OperatingContextCustomers.Add(new OperatingContextCustomer(customerId, operatingContext.Id));
        }

        public bool OperatingContextExistsForCustomer(OperatingContext operatingContext, int customerId)
        {
            return _context.OperatingContextCustomers.Exists(occ => occ.OperatingContextId == operatingContext.Id && occ.CustomerId == customerId);
        }

        public void AddAgentRelationship(AgentRelationship agentRelationship)
        {
            _context.AgentRelationships.Add(agentRelationship); 
        }

        public bool CustomerExistsForOperatingContext(Customer customer, int operatingContextId)
        {
            return _context.OperatingContextCustomers.Exists(occ =>
                occ.CustomerId == customer.Id && occ.OperatingContextId == operatingContextId);
        }

        public void AddAssociate(Associate associate)
        {
            _context.Associates.Add(associate);
        }


        public bool AssociateExists(int id)
        {
            return _context.Associates.Find(a => a.DUNSNumber == id) != null;
        }

        public bool ContactConfigurationExistsForContact(ContactConfiguration contactConfiguration, int contactId)
        {
            return _context.Contacts[contactId].ContactConfigurations.FirstOrDefault(cc =>
                cc.FacilityId == contactConfiguration.FacilityId &&
                cc.ContactTypeId == contactConfiguration.ContactTypeId) != null;
        }

        public void AddOperatingContext(OperatingContext operatingContext)
        {
            _context.OperatingContexts.Add(operatingContext);
        }

        public void AddAssociateOperatingContext(Associate associate, OperatingContext operatingContext)
        {
            int operatingContextId = _context.OperatingContexts.ToList().Last().Id;

            AssociateOperatingContext association = new AssociateOperatingContext(associate.Id, operatingContextId);

            _context.AssociateOperatingContexts.Add(association);
        }

        public void AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
        }

        public bool AddressExistsForContact(Address address, int contactId)
        {
            return _context.Contacts[contactId].Addresses.FirstOrDefault(a => a == address) != null;
        }

        public Address AddAddressForContact(Address address, int contactId)
        {
            try
            {
                _context.Addresses.Add(address);

                _context.ContactAddresses.Add(new ContactAddress
                {
                    ContactId = contactId,
                    AddressId = address.Id
                });

                return address;
            }
            catch
            {
                Address toRemove = _context.Addresses.SingleOrDefault(a => a.Id == address.Id);

                if (toRemove != null)
                    _context.Addresses.Remove(toRemove);

                throw;
            }
        }

        public void AddContactConfigurationForContact(int contactId, ContactConfiguration contactConfiguration)
        {
            _context.Contacts[contactId].ContactConfigurations.Add(contactConfiguration);
        }


#pragma warning disable 1998
        public void AddCustomerForAssociate(Customer customer, int associateId)
        {
            _context.Associates[associateId].Customers.Add(customer);
        }

        public bool CustomerExistsForAssociate(Customer customer, int associateId)
        {
            return _context.Associates[associateId].Customers.FirstOrDefault(c => c == customer) != null;
        }

        public void UpdateAddress(Address address)
        {
            _context.Addresses[address.Id] = address;
        }

        public async Task<Associate> LoadAssociate(int id)
#pragma warning restore 1998
        {
            Associate associateEF = _context.Associates[id];

            return _mapper.Map<Associate>(associateEF);
        }

        public Address LoadAddress(int addressId)
        {
            return _context.Addresses[addressId];
        }

        public void UpdateOperatingContext(OperatingContext operatingContext)
        {
            _context.OperatingContexts[operatingContext.Id] = operatingContext;
        }

        public OperatingContext LoadOperatingContext(int operatingContextId)
        {
            return _context.OperatingContexts[operatingContextId];
        }

        public Phone AddPhoneForContact(Phone phone, int contactId)
        {
            try
            {
                _context.Phones.Add(phone);

                _context.ContactPhones.Add(new ContactPhone
                {
                    ContactId = contactId,
                    PhoneId = phone.Id
                });

                return phone;
            }
            catch
            {
                Phone toRemove = _context.Phones.SingleOrDefault(p => p.Id == phone.Id);

                if (toRemove != null)
                    _context.Phones.Remove(toRemove);

                throw;
            }
        }

        public bool PhoneExistsForContact(Phone phone, int contactId)
        {
            return _context.Contacts[contactId].Phones.FirstOrDefault(p => p == phone) != null;
        }

        public void AddCertificationForOperatingContext(Certification certification, int operatingContextId)
        {
            _context.OperatingContexts[operatingContextId].Certification = certification;
        }

        public bool CertificationExistsForOperatingContext(Certification certification, int operatingContextId)
        {
            return _context.OperatingContexts[operatingContextId].CertificationId != null;
        }

        public EMail AddEMailForContact(EMail eMail, int contactId)
        {
            try
            {
                _context.EMails.Add(eMail);

                _context.ContactEMails.Add(new ContactEMail
                {
                    ContactId = contactId,
                    EMailId = eMail.Id
                });

                return eMail;
            }
            catch
            {
                EMail toRemove = _context.EMails.SingleOrDefault(e => e.Id == eMail.Id);

                if (toRemove != null)
                    _context.EMails.Remove(toRemove);

                throw;
            }
        }

        public bool EMailExistsForContact(EMail eMail, int contactId)
        {
            return _context.Contacts[contactId].Emails.FirstOrDefault(e => e == eMail) != null;
        }

        public User AddUserForAssociate(User user, int associateId)
        {
            _context.Users.Add(user);

            AssociateUser associateUser = new AssociateUser {AssociateId = associateId, UserId = user.Id};

            _context.AssociateUsers.Add(associateUser);

            return user;
        }

        public bool UserExistsForAssociate(User user, int associateId)
        {
            return _context.Associates[associateId].AssociateUsers.FirstOrDefault(au => au.AssociateId == associateId && au.UserId == user.Id) != null;
        }

        public void AddRoleEGMSPermission(RoleEGMSPermission roleEGMSPermission)
        {
            _context.RoleEGMSPermissions.Add(roleEGMSPermission);
        }

        public bool RoleEGMSPermissionExists(int roleId, int egmsPermissionId)
        {
            return _context.RoleEGMSPermissions.Exists(rep =>
                rep.EGMSPermissionId == egmsPermissionId && rep.RoleId == roleId);  
        }

        public Role AddRole(Role role)
        {
            _context.Roles.Add(role);

            return role;
        }

        public bool RoleExists(string roleName)
        {
            return _context.Roles.Exists(r => r.RoleName == roleName);
        }

        public bool AgentRelationshipExistsForPrincipal(AgentRelationship agentRelationship, int principalId)
        {
            return _context.AgentRelationships.Exists(ar =>
                ar.PrincipalId == principalId && ar.AgentId == agentRelationship.AgentId);
        }

#pragma warning disable 1998
        public async Task Update(Associate associate)
#pragma warning restore 1998
        {
            Associate associateEF = _context.Associates[associate.Id];

            if (associateEF == null)
            {
                throw new Exception($"Associate {associate.Id} not found for Update.");
            }

            _context.Associates[associate.Id] = associate;
        }
    }
}
