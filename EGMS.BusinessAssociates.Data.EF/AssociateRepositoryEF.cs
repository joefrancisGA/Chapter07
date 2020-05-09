using System;
using System.Linq;
using AutoMapper;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Repositories;
using Microsoft.Extensions.Logging;
using EGMS.Common;

namespace EGMS.BusinessAssociates.Data.EF
{
    public class AssociateRepositoryEF : IAssociateRepository
    {
        private readonly BusinessAssociatesContext _context;

        // TO DO:  Need to use logging
        // ReSharper disable once NotAccessedField.Local
        private readonly ILogger _log;
        // ReSharper disable once NotAccessedField.Local
        private readonly IMapper _mapper;

        // ReSharper disable once SuggestBaseTypeForParameter
        public AssociateRepositoryEF(BusinessAssociatesContext context, ILogger<AssociateRepositoryEF> log, IMapper mapper)
        {
            _context = context;
            _log = log;
            _mapper = mapper;
        }

        #region Links

        public void LinkAlternateFuelToCustomer(int alternateFuelTypeId, int customerId)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == customerId);

            if (customer == null)
                throw new InvalidOperationException("Customer not found");

            customer.CustomerAlternateFuels.Add(new CustomerAlternateFuel(customerId, alternateFuelTypeId));
        }

        #endregion Links

        #region Adds

        public void AddAddressForContact(Address address, int contactId)
        {
            try
            {
                _context.Addresses.Add(address);

                _context.ContactAddresses.Add(new ContactAddress
                {
                    ContactId = contactId,
                    AddressId = address.Id
                });
            }
            catch
            {
                Address toRemove = _context.Addresses.SingleOrDefault(a => a.Id == address.Id);

                if (toRemove != null)
                    _context.Addresses.Remove(toRemove);

                throw;
            }
        }

        public void AddAddressForCustomer(Address address, int customerId)
        {
            try
            {
                _context.Addresses.Add(address);

                _context.CustomerAddresses.Add(new CustomerAddress
                {
                    CustomerId= customerId,
                    AddressId = address.Id
                });
            }
            catch
            {
                Address toRemove = _context.Addresses.SingleOrDefault(a => a.Id == address.Id);

                if (toRemove != null)
                    _context.Addresses.Remove(toRemove);

                throw;
            }
        }


        public void AddContactForAssociate(Contact contact, int associateId)
        {
            try
            {
                _context.Contacts.Add(contact);

                _context.AssociateContacts.Add(new AssociateContact
                {
                    ContactId = contact.Id,
                    AssociateId = associateId
                });
            }
            catch
            {
                Contact toRemove = _context.Contacts.SingleOrDefault(c => c.Id == contact.Id);

                if (toRemove != null)
                    _context.Contacts.Remove(toRemove);

                throw;
            }
        }


        public void AddEMailForAssociate(EMail email, int associateId)
        {
            try
            {
                _context.EMails.Add(email);

                _context.AssociateEMails.Add(new AssociateEMail
                {
                    EMailId = email.Id,
                    AssociateId = associateId
                });
            }
            catch
            {
                EMail toRemove = _context.EMails.SingleOrDefault(e => e.Id == email.Id);

                if (toRemove != null)
                    _context.EMails.Remove(toRemove);

                throw;
            }
        }

        public void AddAddressForAssociate(Address address, int associateId)
        {
            Associate associate = _context.Associates.FirstOrDefault(a => a.Id == associateId);

            if (associate == null)
            {
                throw new InvalidOperationException("Associate not found in AddAddressForAssociate");
            }

            associate.Addresses.Add(address);
        }

        public void AddAgentRelationship(AgentRelationship agentRelationship)
        {
            _context.AgentRelationships.Add(agentRelationship);
        }

        public void AddAssociate(Associate associate)
        {
            _context.Associates.Add(associate);
        }

        public void AddOperatingContextForAssociate(OperatingContext operatingContext, int associateId)
        {
            try
            {
                _context.OperatingContexts.Add(operatingContext);

                _context.AssociateOperatingContexts.Add(new AssociateOperatingContext
                {
                    OperatingContextId = operatingContext.Id,
                    AssociateId = associateId
                });
            }
            catch
            {
                OperatingContext toRemove = _context.OperatingContexts.SingleOrDefault(oc => oc.Id == operatingContext.Id);

                if (toRemove != null)
                    _context.OperatingContexts.Remove(toRemove);

                throw;
            }
        }

        public void AddCertificationForOperatingContext(Certification certification, int operatingContextId)
        {
            OperatingContext operatingContext =
                _context.OperatingContexts.SingleOrDefault(oc => oc.Id == operatingContextId);

            if (operatingContext == null)
                throw new InvalidOperationException("OperatingContext not found.");

            operatingContext.Certification = certification;
        }

        public void AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
        }

        public void AddContactConfigurationForContact(ContactConfiguration contactConfiguration, int contactId)
        {
            Contact contact = _context.Contacts.SingleOrDefault(c => c.Id == contactId);

            if (contact == null)
                throw new InvalidOperationException("Contact not found.");

            contact.ContactConfigurations.Add(contactConfiguration);
        }

        public void AddCustomerForAssociate(Customer customer, int associateId)
        {
            try
            {
                _context.Customers.Add(customer);

                _context.AssociateCustomers.Add(new AssociateCustomer
                {
                    CustomerId = customer.Id,
                    AssociateId = associateId
                });
            }
            catch
            {
                Customer toRemove = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                if (toRemove != null)
                    _context.Customers.Remove(toRemove);

                throw;
            }
        }

        public void AddCustomerForOperatingContext(Customer customer, int operatingContextId)
        {
            try
            {
                _context.Customers.Add(customer);

                _context.OperatingContextCustomers.Add(new OperatingContextCustomer
                {
                    OperatingContextId = operatingContextId,
                    CustomerId = customer.Id
                });
            }
            catch
            {
                Customer toRemove = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                if (toRemove != null)
                    _context.Customers.Remove(toRemove);

                throw;
            }
        }
        
        public void AddEMailForContact(EMail eMail, int contactId)
        {
            try
            {
                _context.EMails.Add(eMail);

                _context.ContactEMails.Add(new ContactEMail
                {
                    ContactId = contactId,
                    EMailId = eMail.Id
                });
            }
            catch
            {
                EMail toRemove = _context.EMails.SingleOrDefault(e => e.Id == eMail.Id);

                if (toRemove != null)
                    _context.EMails.Remove(toRemove);

                throw;
            }
        }

        public void AddEMailForCustomer(EMail eMail, int customerId)
        {
            try
            {
                _context.EMails.Add(eMail);

                _context.CustomerEMails.Add(new CustomerEMail
                {
                    CustomerId = customerId,
                    EMailId = eMail.Id
                });
            }
            catch
            {
                EMail toRemove = _context.EMails.SingleOrDefault(e => e.Id == eMail.Id);

                if (toRemove != null)
                    _context.EMails.Remove(toRemove);

                throw;
            }
        }

        public void AddOperatingContext(OperatingContext operatingContext)
        {
            _context.OperatingContexts.Add(operatingContext);
        }

        public void AddOperatingContextForCustomer(OperatingContext operatingContext, int customerId)
        {
            _context.OperatingContextCustomers.Add(new OperatingContextCustomer(customerId, operatingContext.Id));
        }

        public void AddPermission(EGMSPermission permission)
        {
            _context.EGMSPermissions.Add(permission);
        }

        public void AddPhoneForContact(Phone phone, int contactId)
        {
            try
            {
                _context.Phones.Add(phone);

                _context.ContactPhones.Add(new ContactPhone
                {
                    ContactId = contactId,
                    PhoneId = phone.Id
                });
            }
            catch
            {
                Phone toRemove = _context.Phones.SingleOrDefault(p => p.Id == phone.Id);

                if (toRemove != null)
                    _context.Phones.Remove(toRemove);

                throw;
            }
        }

        public void AddPhoneForCustomer(Phone phone, int customerId)
        {
            try
            {
                _context.Phones.Add(phone);

                _context.CustomerPhones.Add(new CustomerPhone
                {
                    CustomerId = customerId,
                    PhoneId = phone.Id
                });
            }
            catch
            {
                Phone toRemove = _context.Phones.SingleOrDefault(p => p.Id == phone.Id);

                if (toRemove != null)
                    _context.Phones.Remove(toRemove);

                throw;
            }
        }


        public void AddPhoneForAssociate(Phone phone, int associateId)
        {
            try
            {
                _context.Phones.Add(phone);

                _context.AssociatePhones.Add(new AssociatePhone
                {
                    AssociateId = associateId,
                    PhoneId = phone.Id
                });
            }
            catch
            {
                Phone toRemove = _context.Phones.SingleOrDefault(p => p.Id == phone.Id);

                if (toRemove != null)
                    _context.Phones.Remove(toRemove);

                throw;
            }
        }

        public void AddRole(Role role)
        {
            _context.Roles.Add(role);
        }

        public void AddRoleEGMSPermission(RoleEGMSPermission roleEGMSPermission)
        {
            _context.RoleEGMSPermissions.Add(roleEGMSPermission);
        }

        public void AddUserForAssociate(User user, int associateId)
        {
            try
            {
                _context.Users.Add(user);

                _context.AssociateUsers.Add(new AssociateUser
                {
                    AssociateId = associateId,
                    UserId = user.Id
                });
            }
            catch
            {
                User toRemove = _context.Users.SingleOrDefault(u => u.Id == user.Id);

                if (toRemove != null)
                    _context.Users.Remove(toRemove);

                throw;
            }

            _context.Users.Add(user);

            AssociateUser associateUser = new AssociateUser { AssociateId = associateId, UserId = user.Id };

            _context.AssociateUsers.Add(associateUser);
        }


        #endregion

        #region Existence

        public bool AddressExistsForContact(Address address, int contactId)
        {
            Contact contact = _context.Contacts.FirstOrDefault(c => c.Id == contactId);

            if (contact == null)
                return false;

            if (contact.Addresses.Count == 0)
                return false;

            return contact.Addresses.FirstOrDefault(a => a == address) != null;
        }

        public bool AddressExistsForAssociate(Address address, int associateId)
        {
            Associate associate = _context.Associates.FirstOrDefault(a => a.Id == associateId);

            if (associate == null)
                return false;

            return associate.Addresses.FirstOrDefault(a => a == address) != null;
        }

        public bool AgentRelationshipExistsForPrincipal(AgentRelationship agentRelationship, int principalId)
        {
            return (_context.AgentRelationships.FirstOrDefault(ar => ar.PrincipalId == principalId && ar.AgentId == agentRelationship.AgentId) == null);
        }

        public bool AlternateFuelExistsForCustomer(int alternateFuelTypeId, int customerId)
        {
            return _context.CustomerAlternateFuels.Exists(caf =>
                caf.CustomerId == customerId && caf.AlternateFuelTypeId == alternateFuelTypeId);
        }
        
        public bool AssociateExists(int id)
        {
            return _context.Associates.FirstOrDefault(a => a.DUNSNumber == id) != null;
        }

        public bool CertificationExistsForOperatingContext(Certification certification, int operatingContextId)
        {
            OperatingContext operatingContext =
                _context.OperatingContexts.FirstOrDefault(oc => oc.Id == operatingContextId);

            if (operatingContext == null)
                return false;

            return operatingContext.CertificationId != null;
        }

        public bool ContactConfigurationExistsForContact(ContactConfiguration contactConfiguration, int contactId)
        {
            Contact contact = _context.Contacts.FirstOrDefault(c => c.Id == contactId);

            return contact?.ContactConfigurations.FirstOrDefault(cc =>
                       cc.FacilityId == contactConfiguration.FacilityId &&
                       cc.ContactTypeId == contactConfiguration.ContactTypeId) != null;
        }

        public bool CustomerExistsForAssociate(Customer customer, int associateId)
        {
            DebugLog.Log("Entering AssociateRepositoryEF::CustomerExistsForAssociate");

            Associate associate = GetAssociate(associateId);

            if (associate == null)
                return false;

            return associate.Customers.FirstOrDefault(c => c == customer) != null;
        }

        public bool CustomerExistsForOperatingContext(Customer customer, int operatingContextId)
        {
            return _context.OperatingContextCustomers.Exists(occ =>
                occ.CustomerId == customer.Id && occ.OperatingContextId == operatingContextId);
        }

        public bool EMailExistsForContact(EMail eMail, int contactId)
        {
            Contact contact = _context.Contacts.FirstOrDefault(c => c.Id == contactId);

            return contact?.Emails.FirstOrDefault(e => e == eMail) != null;
        }

        public bool OperatingContextExistsForCustomer(OperatingContext operatingContext, int customerId)
        {
            return _context.OperatingContextCustomers.Exists(occ => occ.OperatingContextId == operatingContext.Id && occ.CustomerId == customerId);
        }

        public bool OperatingContextExistsForAssociate(OperatingContext operatingContext, int associateId)
        {
            return _context.AssociateOperatingContexts.Exists(aoc => aoc.AssociateId == associateId && aoc.AssociateId == associateId);
        }

        public bool PermissionExists(string permissionName)
        {
            return (_context.EGMSPermissions.FirstOrDefault(p => p.PermissionName == permissionName) != null);
        }
        
        public bool PhoneExistsForContact(Phone phone, int contactId)
        {
            Contact contact = _context.Contacts.FirstOrDefault(c => c.Id == contactId);

            if (contact == null)
                return false;

            return contact.Phones.FirstOrDefault(p => p == phone) != null;
        }

        public bool RoleEGMSPermissionExists(int roleId, int egmsPermissionId)
        {
            return _context.RoleEGMSPermissions.SingleOrDefault(rep =>
                rep.EGMSPermissionId == egmsPermissionId && rep.RoleId == roleId) != null;
        }
        
        public bool RoleExists(string roleName)
        {
            return _context.Roles.SingleOrDefault(r => r.RoleName == roleName) != null;
        }
        
        public bool UserExistsForAssociate(User user, int associateId)
        {
            DebugLog.Log("Looking for User for Associate " + associateId);

            Associate associate = GetAssociate(associateId);

            return associate?.AssociateUsers.FirstOrDefault(au => au.AssociateId == associateId && au.UserId == user.Id) != null;
        }

        #endregion Exists

        #region Reads

        public Address GetAddress(int addressId)
        {
            return _context.Addresses.Single(a => a.Id == addressId);
        }

        public Associate GetAssociate(int associateId)
        {
            return _context.Associates.Single(a => a.Id == associateId);
        }

        public Customer GetCustomer(int customerId)
        {
            return _context.Customers.Single(a => a.Id == customerId);
        }

        public OperatingContext GetOperatingContext(int operatingContextId)
        {
            return _context.OperatingContexts.Single(oc => oc.Id == operatingContextId);
        }

        public User GetUser(int userId)
        {
            return _context.Users.Single(u => u.Id == userId);
        }


        #endregion Reads

        #region Updates

        public void UpdateAddress(Address address)
        {
            throw new NotImplementedException();
        }
        
        public void UpdateOperatingContext(OperatingContext operatingContext)
        {
            _context.OperatingContexts[operatingContext.Id] = operatingContext;
        }

        #endregion Updates


#pragma warning disable 1998


        //public async Task UpdateAssociate(Associate associate)
        //{
        //    Associate associateEF = _context.Associates[associate.Id];

        //    if (associateEF == null)
        //    {
        //        throw new Exception($"Associate {associate.Id} not found for Update.");
        //    }

        //    _context.Associates[associate.Id] = associate;
        //}
    }
}
