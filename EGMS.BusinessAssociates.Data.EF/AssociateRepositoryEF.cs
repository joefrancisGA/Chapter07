﻿using System.Linq;
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
            _context.Customers[customerId].CustomerAlternateFuels
                .Add(new CustomerAlternateFuel(customerId, alternateFuelTypeId));
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

        public void AddAddressForOperatingContext(Address address, int operatingContextId)
        {
            _context.OperatingContexts[operatingContextId].Addresses.Add(address);
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
            _context.OperatingContexts[operatingContextId].Certification = certification;
        }

        public void AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
        }

        public void AddContactConfigurationForContact(ContactConfiguration contactConfiguration, int contactId)
        {
            _context.Contacts[contactId].ContactConfigurations.Add(contactConfiguration);
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
            return _context.Contacts[contactId].Addresses.FirstOrDefault(a => a == address) != null;
        }

        public bool AddressExistsForOperatingContext(Address address, int operatingContextId)
        {
            return _context.OperatingContexts[operatingContextId].Addresses.FirstOrDefault(a => a == address) != null;
        }

        public bool AgentRelationshipExistsForPrincipal(AgentRelationship agentRelationship, int principalId)
        {
            return _context.AgentRelationships.Exists(ar =>
                ar.PrincipalId == principalId && ar.AgentId == agentRelationship.AgentId);
        }

        public bool AlternateFuelExistsForCustomer(int alternateFuelTypeId, int customerId)
        {
            return _context.CustomerAlternateFuels.Exists(caf =>
                caf.CustomerId == customerId && caf.AlternateFuelTypeId == alternateFuelTypeId);
        }
        
        public bool AssociateExists(int id)
        {
            return _context.Associates.Find(a => a.DUNSNumber == id) != null;
        }

        public bool CertificationExistsForOperatingContext(Certification certification, int operatingContextId)
        {
            return _context.OperatingContexts[operatingContextId].CertificationId != null;
        }

        public bool ContactConfigurationExistsForContact(ContactConfiguration contactConfiguration, int contactId)
        {
            return _context.Contacts[contactId].ContactConfigurations.FirstOrDefault(cc =>
                cc.FacilityId == contactConfiguration.FacilityId &&
                cc.ContactTypeId == contactConfiguration.ContactTypeId) != null;
        }

        public bool CustomerExistsForAssociate(Customer customer, int associateId)
        {
            DebugLog.Log("Entering AssociateRepositoryEF::CustomerExistsForAssociate");

            Associate associate = GetAssociate(associateId);
            return associate.Customers.FirstOrDefault(c => c == customer) != null;
        }

        public bool CustomerExistsForOperatingContext(Customer customer, int operatingContextId)
        {
            return _context.OperatingContextCustomers.Exists(occ =>
                occ.CustomerId == customer.Id && occ.OperatingContextId == operatingContextId);
        }

        public bool EMailExistsForContact(EMail eMail, int contactId)
        {
            return _context.Contacts[contactId].Emails.FirstOrDefault(e => e == eMail) != null;
        }

        public bool OperatingContextExistsForCustomer(OperatingContext operatingContext, int customerId)
        {
            return _context.OperatingContextCustomers.Exists(occ => occ.OperatingContextId == operatingContext.Id && occ.CustomerId == customerId);
        }
        
        public bool PermissionExists(string permissionName)
        {
            return _context.EGMSPermissions.Exists(p => p.PermissionName == permissionName);
        }
        
        public bool PhoneExistsForContact(Phone phone, int contactId)
        {
            return _context.Contacts[contactId].Phones.FirstOrDefault(p => p == phone) != null;
        }

        public bool RoleEGMSPermissionExists(int roleId, int egmsPermissionId)
        {
            return _context.RoleEGMSPermissions.Exists(rep =>
                rep.EGMSPermissionId == egmsPermissionId && rep.RoleId == roleId);
        }
        
        public bool RoleExists(string roleName)
        {
            return _context.Roles.Exists(r => r.RoleName == roleName);
        }
        
        public bool UserExistsForAssociate(User user, int associateId)
        {
            DebugLog.Log("Looking for User for Associate " + associateId);

            Associate associate = GetAssociate(associateId);

            return associate.AssociateUsers.FirstOrDefault(au => au.AssociateId == associateId && au.UserId == user.Id) != null;
        }

        #endregion Exists

        #region Reads

        public Address GetAddress(int addressId)
        {
            return _context.Addresses[addressId];
        }

        public Associate GetAssociate(int associateId)
        {
            return _context.Associates.Single(a => a.Id == associateId);
        }
        
        public OperatingContext GetOperatingContext(int operatingContextId)
        {
            return _context.OperatingContexts[operatingContextId];
        }

        #endregion Reads

        #region Updates

        public void UpdateAddress(Address address)
        {
            _context.Addresses[address.Id] = address;
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
