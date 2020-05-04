using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Query;
using EGMS.BusinessAssociates.Query.ReadModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EGMS.BusinessAssociates.Data.EF
{
    class AssociateQueryRepositoryEF : IAssociateQueryRepository
    {
        private readonly BusinessAssociatesContext _context;
        // TO DO:  Need to use logging
        // ReSharper disable once NotAccessedField.Local
#pragma warning disable 169
        private readonly ILogger _log;
#pragma warning restore 169
        private readonly IMapper _mapper;

        public AssociateQueryRepositoryEF(BusinessAssociatesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public Task<AssociateRM> GetAssociateAsync(int associateId)
        {
            return Task.FromResult(_mapper.Map<Associate, AssociateRM> (_context.Associates.SingleOrDefault(a => a.Id == associateId)));
        }

        public async Task<PagedGridResult<IEnumerable<AssociateRM>>> GetAssociatesAsync(QueryModels.AssociateQueryParams queryParams)
        {
            List<Associate> associates = await _context.Associates.ApplyQuery(queryParams).ToListAsync();

            int totalCount = associates.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = _context.Associates.ApplyQuery(queryParams, false);
                totalCount = await countQuery.CountAsync();
            }

            return new PagedGridResult<IEnumerable<AssociateRM>>
            {
                Data = _mapper.Map<IEnumerable<AssociateRM>>(associates),
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            };
        }

        public Task<AddressRM> GetAddressAsync(int addressId)
        {
            return Task.FromResult(_mapper.Map<AddressRM>(_context.Addresses.SingleOrDefault(a => a.Id == addressId)));
        }

        public Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddressesAsync(QueryModels.AddressQueryParams queryParams)
        {
            List<Address> addresses = _context.Addresses.ApplyQuery(queryParams).ToList();

            int totalCount = addresses.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
                totalCount = _context.Addresses.ApplyQuery(queryParams, false).Count();

            return Task.FromResult(new PagedGridResult<IEnumerable<AddressRM>>
            {
                Data = _mapper.Map<IEnumerable<AddressRM>>(addresses),
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            });
        }

#pragma warning disable 1998
        public Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddressesForAssociateAsync(int associateId)
#pragma warning restore 1998
        {
            ValidateAssociateExists(associateId);

            List<AssociateAddress> associateAddresses = _context.AssociateAddresses.FindAll(aa => aa.AssociateId == associateId);

            if (associateAddresses == null)
                throw new InvalidOperationException("No addresses found for specified associate.");

            List<Address> addresses = associateAddresses.Select(aa => _context.Addresses.Find(aa.AddressId)).ToList();

            return Task.FromResult(new PagedGridResult<IEnumerable<AddressRM>>
            {
                Data = _mapper.Map<IEnumerable<AddressRM>>(addresses),
                Total = addresses.Count,
                Errors = null,
                AggregateResult = null
            });
        }

        public Task<AddressRM> GetAddressForContactAsync(int contactId, int addressId)
        {
            ContactAddress contactAddress =
                _context.ContactAddresses.SingleOrDefault(ca => ca.ContactId == contactId && ca.AddressId == addressId);

            if (contactAddress == null)
                throw new InvalidOperationException("Specified address not found for specified contact.");

            return Task.FromResult(_mapper.Map<AddressRM>(_context.Addresses.SingleOrDefault(a => a.Id == addressId)));
        }

#pragma warning disable 1998
        public async Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddressesForContactAsync(int associateId, int contactId)
#pragma warning restore 1998
        {
            ValidateAssociateExists(associateId);

            List<ContactAddress> contactAddresses = _context.ContactAddresses.FindAll(aa => aa.ContactId == contactId);

            if (contactAddresses == null)
                throw new InvalidOperationException("No addresses found for specified contact.");

            List<Address> addresses = contactAddresses.Select(aa => _context.Addresses.Find(aa.AddressId)).ToList();

            return new PagedGridResult<IEnumerable<AddressRM>>
            {
                Data = _mapper.Map<IEnumerable<AddressRM>>(addresses),
                Total = addresses.Count,
                Errors = null,
                AggregateResult = null
            };
        }


        public Task<PagedGridResult<IEnumerable<AgentRelationshipRM>>> GetAgentRelationshipsAsync(QueryModels.AgentRelationshipQueryParams queryParams)
        {
            List<AgentRelationship> agentRelationships = _context.AgentRelationships.ApplyQuery(queryParams).ToList();

            int totalCount = agentRelationships.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
                totalCount = _context.AgentRelationships.ApplyQuery(queryParams, false).Count();

            return Task.FromResult(new PagedGridResult<IEnumerable<AgentRelationshipRM>>
            {
                Data = _mapper.Map<IEnumerable<AgentRelationshipRM>>(agentRelationships),
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            });
        }

        public Task<AgentRelationshipRM> GetAgentRelationshipForPrincipalAsync(int principalId, int agentRelationshipId)
        {
            AgentRelationship agentRelationship = ValidateAgentRelationshipExists(principalId, agentRelationshipId);
            return Task.FromResult(_mapper.Map<AgentRelationshipRM>(agentRelationship));
        }

        public Task<UserRM> GetUserForAgentRelationshipAsync(int principalId, int agentRelationshipId, int userId)
        {
            AgentRelationship agentRelationship = ValidateAgentRelationshipExists(principalId, agentRelationshipId);

            IEnumerable<AgentUser> agentUsers = _context.AgentUsers.Where(au => au.AgentId == agentRelationship.AgentId);

            if (agentUsers == null)
                throw new InvalidOperationException("Users not found for AgentRelationship.");
            
            return Task.FromResult(_mapper.Map<UserRM>(_context.Users.SingleOrDefault(u => u.Id == userId)));
        }

        public Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersForAgentRelationshipAsync(int principalId, int agentRelationshipId)
        {
            AgentRelationship agentRelationship = ValidateAgentRelationshipExists(principalId, agentRelationshipId);

            IEnumerable<AgentUser> agentUsers = _context.AgentUsers.Where(au => au.AgentId == agentRelationship.AgentId);

            if (agentUsers == null)
                throw new InvalidOperationException("Users not found for AgentRelationship.");

            List<User> users = agentUsers.Select(agentUser => _context.Users.SingleOrDefault(u => u.Id == agentUser.UserId)).Where(user => user != null).ToList();

            return Task.FromResult(new PagedGridResult<IEnumerable<UserRM>>
            {
                Data = _mapper.Map<IEnumerable<UserRM>>(users),
                Total = users.Count,
                Errors = null,
                AggregateResult = null
            });
        }

        public Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersForAgentRelationshipAsync(QueryModels.UserQueryParams queryParams)
        {
            var filtered = _context.Users.ApplyQuery(queryParams);

            var results = filtered.ToList();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = _context.Users.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            var retVal = new PagedGridResult<IEnumerable<UserRM>>
            {
                Data = _mapper.Map<IEnumerable<UserRM>>(results),
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersForAgentRelationshipAsync(int associateId, int principalId, int agentRelationshipId)
        {
            ValidateAssociateExists(associateId);

            AgentRelationship agentRelationship =
                _context.AgentRelationships.SingleOrDefault(ar => ar.PrincipalId == principalId && ar.Id == agentRelationshipId);

            if (agentRelationship == null)
                throw new InvalidOperationException("Agent relationship not found for specified principal.");

            IEnumerable<AgentUser> agentUsers = _context.AgentUsers.Where(au => au.AgentId == agentRelationship.AgentId);

            if (agentUsers == null)
                throw new InvalidOperationException("Users not found for AgentRelationship.");

            List<User> users = agentUsers.Select(agentUser => _context.Users.Single(u => u.Id == agentUser.UserId)).Where(user => user != null).ToList();

            var retVal = new PagedGridResult<IEnumerable<UserRM>>
            {
                Data = _mapper.Map<IEnumerable<UserRM>>(users),
                Total = users.Count,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<AgentRelationshipRM> GetAgentRelationshipAsync(int agentRelationshipId)
        {
            var result = _context.AgentRelationships.SingleOrDefault(ar => ar.Id == agentRelationshipId);
            return Task.FromResult(_mapper.Map<AgentRelationshipRM>(result));
        }

        public Task<ContactRM> GetContactAsync(int associateId, int contactId)
        {
            var associateContacts = _context.AssociateContacts;

            Contact contact = null;

            foreach (var associateContact in associateContacts.Where(associateContact => associateContact.ContactId == contactId && associateContact.AssociateId == associateId))
            {
                contact = _context.Contacts.SingleOrDefault(c => c.Id == contactId);
            }

            return Task.FromResult(_mapper.Map<Contact, ContactRM>(contact));
        }

        public Task<ContactRM> GetContactAsync(int contactId)
        {
            return Task.FromResult(_mapper.Map<Contact, ContactRM>(_context.Contacts.SingleOrDefault(c => c.Id == contactId)));
        }

        public Task<PagedGridResult<IEnumerable<ContactRM>>> GetContactsAsync(QueryModels.ContactQueryParams queryParams)
        {
            var filtered = _context.Contacts.ApplyQuery(queryParams);

            var results = filtered.ToList();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = _context.Contacts.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            var retVal = new PagedGridResult<IEnumerable<ContactRM>>
            {
                Data = _mapper.Map<IEnumerable<ContactRM>>(results),
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<PagedGridResult<IEnumerable<ContactRM>>> GetContactsAsync(int associateId)
        {
            List<AssociateContact> associateContacts = _context.AssociateContacts.FindAll(ac => ac.AssociateId == associateId);

            if (associateContacts == null)
                throw new InvalidOperationException("No contacts found for specified associate.");

            List<Contact> contacts = associateContacts.Select(ac => _context.Contacts.Find(ac.ContactId)).ToList();

            var retVal = new PagedGridResult<IEnumerable<ContactRM>>
            {
                Data = _mapper.Map<IEnumerable<ContactRM>>(contacts),
                Total = contacts.Count,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<ContactConfigurationRM> GetContactConfigurationForContactAsync(int associateId, int contactId, int contactConfigurationId)
        {
            Contact contact = _context.Contacts.SingleOrDefault(c => c.Id == contactId);

            if (contact == null)
                throw new InvalidOperationException("Contact not found.");

            ContactConfiguration contactConfiguration =
                contact.ContactConfigurations.SingleOrDefault(cc => cc.Id == contactConfigurationId);
                
            if (contactConfiguration == null)
                throw new InvalidOperationException("ContactConfiguration not found.");

            return Task.FromResult(_mapper.Map<ContactConfiguration, ContactConfigurationRM>(contactConfiguration));
        }

        public Task<PagedGridResult<IEnumerable<ContactConfigurationRM>>> GetContactConfigurationsAsync(QueryModels.ContactConfigurationQueryParams queryParams)
        {
            var filtered = _context.ContactConfigurations.ApplyQuery(queryParams);

            var results = filtered.ToList();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = _context.ContactConfigurations.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            var retVal = new PagedGridResult<IEnumerable<ContactConfigurationRM>>
            {
                Data = _mapper.Map<IEnumerable<ContactConfigurationRM>>(results),
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<PagedGridResult<IEnumerable<ContactConfigurationRM>>> GetContactConfigurationsForContactAsync(int associateId, int contactId)
        {
            Contact contact = _context.Contacts.SingleOrDefault(ar => ar.Id == contactId);

            if (contact == null)
                throw new InvalidOperationException("Contact not found.");

            IEnumerable<ContactConfiguration> contactConfigurations = contact.ContactConfigurations;

            var retVal = new PagedGridResult<IEnumerable<ContactConfigurationRM>>
            {
                Data = _mapper.Map<IEnumerable<ContactConfigurationRM>>(contactConfigurations),
                Total = contactConfigurations.Count(),
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<ContactConfigurationRM> GetContactConfigurationAsync(int contactConfigurationId)
        {
            ContactConfiguration contactConfiguration = _context.ContactConfigurations.SingleOrDefault(cc => cc.Id == contactConfigurationId);
            
            return Task.FromResult(_mapper.Map<ContactConfiguration, ContactConfigurationRM>(contactConfiguration));
        }

        public Task<CustomerRM> GetCustomerAsync(int customerId)
        {
            Customer customer = _context.Customers.SingleOrDefault(c => c.Id == customerId);

            return Task.FromResult(_mapper.Map<Customer, CustomerRM>(customer));
        }

        public Task<PagedGridResult<IEnumerable<CustomerRM>>> GetCustomersAsync(QueryModels.CustomerQueryParams queryParams)
        {
            var filtered = _context.Customers.ApplyQuery(queryParams);

            var results = filtered.ToList();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = _context.Customers.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            var retVal = new PagedGridResult<IEnumerable<CustomerRM>>
            {
                Data = _mapper.Map<IEnumerable<CustomerRM>>(results),
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<PagedGridResult<IEnumerable<CustomerRM>>> GetCustomersAsync(int associateId)
        {
            List<AssociateCustomer> associateCustomers = _context.AssociateCustomers.FindAll(ac => ac.AssociateId == associateId);

            if (associateCustomers == null)
                throw new InvalidOperationException("No customers found for specified associate.");

            List<Customer> customers = associateCustomers.Select(ac => _context.Customers.Find(ac.CustomerId)).ToList();

            var retVal = new PagedGridResult<IEnumerable<CustomerRM>>
            {
                Data = _mapper.Map<IEnumerable<CustomerRM>>(customers),
                Total = customers.Count,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<EMailRM> GetEMailAsync(int eMailId)
        {
            EMail email = _context.EMails.SingleOrDefault(e => e.Id == eMailId);

            return Task.FromResult(_mapper.Map<EMail, EMailRM>(email));
        }

        public Task<EMailRM> GetEMailForContactAsync(int associateId, int contactId, int eMailId)
        {
            Contact contact = _context.Contacts.SingleOrDefault(c => c.Id == contactId);

            if (contact == null)
                throw new InvalidOperationException("Contact not found.");

            ContactEMail contactEMail = _context.ContactEMails.SingleOrDefault(ce => ce.ContactId == contactId && ce.EMailId == eMailId);

            if (contactEMail == null)
                throw new InvalidOperationException("EMails not found for Contact.");

            EMail eMail = _context.EMails.SingleOrDefault(e => e.Id == eMailId);

            return Task.FromResult(_mapper.Map<EMail, EMailRM>(eMail));
        }

        public Task<PagedGridResult<IEnumerable<EMailRM>>> GetEMailsForContactAsync(int associateId, int contactId)
        {
            List<ContactEMail> contactEMails = _context.ContactEMails.FindAll(ce => ce.ContactId == contactId);

            if (contactEMails == null)
                throw new InvalidOperationException("No emails found for contact.");

            List<EMail> eMails = contactEMails.Select(contactEMail => _context.EMails.SingleOrDefault(e => e.Id == contactEMail.EMailId)).Where(email => email != null).ToList();

            var retVal = new PagedGridResult<IEnumerable<EMailRM>>
            {
                Data = _mapper.Map<IEnumerable<EMailRM>>(eMails),
                Total = eMails.Count,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<EMailRM> GetEMailForAssociateAsync(int associateId, int eMailId)
        {
            Associate associate = _context.Associates.SingleOrDefault(a => a.Id == associateId);

            if (associate == null)
                throw new InvalidOperationException("Associate not found.");

            AssociateEMail associateEMail = _context.AssociateEMails.SingleOrDefault(ae => ae.AssociateId == associateId && ae.EMailId == eMailId);

            if (associateEMail == null)
                throw new InvalidOperationException("EMails not found for Contact.");

            EMail eMail = _context.EMails.SingleOrDefault(e => e.Id == eMailId);

            return Task.FromResult(_mapper.Map<EMail, EMailRM>(eMail));
        }

        public Task<PagedGridResult<IEnumerable<EMailRM>>> GetEMailsForAssociateAsync(int associateId)
        {
            ValidateAssociateExists(associateId);

            List<AssociateEMail> associateEMails = _context.AssociateEMails.FindAll(ce => ce.AssociateId == associateId);

            if (associateEMails == null)
                throw new InvalidOperationException("EMails not found for Associate.");
            
            List<EMail> eMails = associateEMails.Select(associateEMail => _context.EMails.SingleOrDefault(e => e.Id == associateEMail.EMailId)).Where(email => email != null).ToList();

            var retVal = new PagedGridResult<IEnumerable<EMailRM>>
            {
                Data = _mapper.Map<IEnumerable<EMailRM>>(eMails),
                Total = eMails.Count,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<PagedGridResult<IEnumerable<EMailRM>>> GetEMailsAsync(QueryModels.EMailQueryParams queryParams)
        {
            var results = _context.EMails.ApplyQuery(queryParams).ToList();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = _context.EMails.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            var retVal = new PagedGridResult<IEnumerable<EMailRM>>
            {
                Data = _mapper.Map<IEnumerable<EMailRM>>(results),
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<OperatingContextRM> GetOperatingContextAsync(int operatingContextId)
        {
            OperatingContext operatingContext = _context.OperatingContexts.SingleOrDefault(oc => oc.Id == operatingContextId);

            return Task.FromResult(_mapper.Map<OperatingContext, OperatingContextRM>(operatingContext));
        }

        public Task<OperatingContextRM> GetOperatingContextForCustomerAsync(int associateId, int customerId, int operatingContextId)
        {
            Associate associate = ValidateAssociateExists(associateId);

            AssociateCustomer associateCustomer =
                _context.AssociateCustomers.SingleOrDefault(ac =>
                    ac.AssociateId == associate.Id && ac.CustomerId == customerId);
            
            if (associateCustomer == null)
                throw new InvalidOperationException("Customer not found for associate.");

            CustomerOperatingContext customerOperatingContext =
                _context.CustomerOperatingContexts.SingleOrDefault(coc =>
                    coc.CustomerId == customerId && coc.OperatingContextId == operatingContextId);

            if (customerOperatingContext == null)
                throw new InvalidOperationException("OperatingContext not found for Customer.");

            return Task.FromResult(_mapper.Map<OperatingContext, OperatingContextRM>(_context.OperatingContexts.SingleOrDefault(oc => oc.Id == operatingContextId)));
        }

        public Task<PagedGridResult<IEnumerable<OperatingContextRM>>> GetOperatingContextsAsync(QueryModels.OperatingContextQueryParams queryParams)
        {
            List<OperatingContext> operatingContexts = _context.OperatingContexts.ApplyQuery(queryParams).ToList();

            int totalCount = operatingContexts.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
                totalCount = _context.OperatingContexts.ApplyQuery(queryParams, false).Count();

            return Task.FromResult(new PagedGridResult<IEnumerable<OperatingContextRM>>
            {
                Data = _mapper.Map<IEnumerable<OperatingContextRM>>(operatingContexts),
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            });
        }

        public Task<PagedGridResult<IEnumerable<OperatingContextRM>>> GetOperatingContextsForAssociateAsync(int associateId)
        {
            List<AssociateOperatingContext> associateOperatingContexts = _context.AssociateOperatingContexts.FindAll(aoc => aoc.AssociateId == associateId);

            if (associateOperatingContexts == null)
                throw new InvalidOperationException("No Operating Contexts found for Associate.");

            List<OperatingContext> operatingContexts = associateOperatingContexts.Select(associateOperatingContext => _context.OperatingContexts.SingleOrDefault(e => e.Id == associateOperatingContext.OperatingContextId)).Where(operatingContext => operatingContext != null).ToList();

            var retVal = new PagedGridResult<IEnumerable<OperatingContextRM>>
            {
                Data = _mapper.Map<IEnumerable<OperatingContextRM>>(operatingContexts),
                Total = operatingContexts.Count,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<PagedGridResult<IEnumerable<OperatingContextRM>>> GetOperatingContextsForCustomerAsync(int associateId, int customerId)
        {
            List<CustomerOperatingContext> customerOperatingContexts = _context.CustomerOperatingContexts.FindAll(aoc => aoc.CustomerId == customerId);

            if (customerOperatingContexts == null)
                throw new InvalidOperationException("No Operating Contexts found for Customer.");

            List<OperatingContext> operatingContexts = customerOperatingContexts.Select(customerOperatingContext => _context.OperatingContexts.SingleOrDefault(e => e.Id == customerOperatingContext.OperatingContextId)).Where(operatingContext => operatingContext != null).ToList();

            var retVal = new PagedGridResult<IEnumerable<OperatingContextRM>>
            {
                Data = _mapper.Map<IEnumerable<OperatingContextRM>>(operatingContexts),
                Total = operatingContexts.Count,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<PhoneRM> GetPhoneAsync(int phoneId)
        {
            Phone phone = _context.Phones.SingleOrDefault(oc => oc.Id == phoneId);

            return Task.FromResult(_mapper.Map<Phone, PhoneRM>(phone));
        }

        public Task<PhoneRM> GetPhoneForContactAsync(int associateId, int contactId, int phoneId)
        {
            ValidateAssociateExists(associateId);
            ValidateContactExists(contactId);

            ContactPhone contactPhone = _context.ContactPhones.SingleOrDefault(ae => ae.ContactId == contactId && ae.PhoneId == phoneId);

            if (contactPhone == null)
                throw new InvalidOperationException("Phone not found for Contact.");

            Phone phone = _context.Phones.SingleOrDefault(e => e.Id == phoneId);

            return Task.FromResult(_mapper.Map<Phone, PhoneRM>(_context.Phones.SingleOrDefault(e => e.Id == phoneId)));
        }

        public Task<PagedGridResult<IEnumerable<PhoneRM>>> GetPhonesForContactAsync(int associateId, int contactId)
        {
            Contact contact = _context.Contacts.SingleOrDefault(c => c.Id == contactId);

            if (contact == null)
                throw new InvalidOperationException("Contact not found.");

            List<ContactPhone> contactPhones = _context.ContactPhones.FindAll(cp => cp.ContactId == contactId);

            if (contactPhones == null)
                throw new InvalidOperationException("No phones found for Contact");

            List<Phone> phones = contactPhones.Select(contactPhone => _context.Phones.SingleOrDefault(oc => oc.Id == contactPhone.PhoneId)).Where(phone => phone != null).ToList();

            var retVal = new PagedGridResult<IEnumerable<PhoneRM>>
            {
                Data = _mapper.Map<IEnumerable<PhoneRM>>(phones),
                Total = phones.Count,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<PhoneRM> GetPhoneForAssociateAsync(int associateId, int phoneId)
        {
            ValidateAssociateExists(associateId);

            AssociatePhone associatePhone = _context.AssociatePhones.SingleOrDefault(ae => ae.AssociateId == associateId && ae.PhoneId == phoneId);

            if (associatePhone == null)
                throw new InvalidOperationException("Phone not found for associate.");

            return Task.FromResult(_mapper.Map<Phone, PhoneRM>(_context.Phones.SingleOrDefault(e => e.Id == phoneId)));
        }

        public Task<PagedGridResult<IEnumerable<PhoneRM>>> GetPhonesForAssociateAsync(int associateId)
        {
            List<AssociatePhone> associatePhones = _context.AssociatePhones.FindAll(ap => ap.AssociateId == associateId);

            if (associatePhones == null)
                throw new InvalidOperationException("No Phones found for Associate.");

            List<Phone> phones = associatePhones.Select(associatePhone => _context.Phones.SingleOrDefault(p => p.Id == associatePhone.PhoneId)).Where(phone => phone != null).ToList();

            return Task.FromResult(new PagedGridResult<IEnumerable<PhoneRM>>
            {
                Data = _mapper.Map<IEnumerable<PhoneRM>>(phones),
                Total = phones.Count,
                Errors = null,
                AggregateResult = null
            });
        }

        public Task<PagedGridResult<IEnumerable<PhoneRM>>> GetPhonesAsync(QueryModels.PhoneQueryParams queryParams)
        {
            var results = _context.Phones.ApplyQuery(queryParams).ToList();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = _context.Phones.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            return Task.FromResult(new PagedGridResult<IEnumerable<PhoneRM>>
            {
                Data = _mapper.Map<IEnumerable<PhoneRM>>(results),
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            });
        }

        public Task<RoleRM> GetRoleAsync(int roleId)
        {
            Role role = _context.Roles.SingleOrDefault(r => r.Id == roleId);

            return Task.FromResult(_mapper.Map<Role, RoleRM>(role));
        }

        public Task<PagedGridResult<IEnumerable<RoleRM>>> GetRolesAsync(QueryModels.RoleQueryParams queryParams)
        {
            var results = _context.Roles.ApplyQuery(queryParams).ToList();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = _context.Roles.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            return Task.FromResult(new PagedGridResult<IEnumerable<RoleRM>>
            {
                Data = _mapper.Map<IEnumerable<RoleRM>>(results),
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            });
        }

        public Task<RoleRM> GetRoleForOperatingContextAsync(int associateId, int operatingContextId, int roleId)
        {
            ValidateOperatingContextExists(operatingContextId);

            OperatingContextRole operatingContextRole = _context.OperatingContextRoles.SingleOrDefault(ocr => ocr.RoleId == roleId);

            if (operatingContextRole == null)
                throw new InvalidOperationException("Role not found for OperatingContext.");

            return Task.FromResult(_mapper.Map<Role, RoleRM>(_context.Roles.SingleOrDefault(r => r.Id == roleId)));
        }

        public Task<PagedGridResult<IEnumerable<RoleRM>>> GetRolesForOperatingContextAsync(int associateId, int operatingContextId)
        {
            List<OperatingContextRole> operatingContextRoles = _context.OperatingContextRoles.FindAll(ocr =>ocr.OperatingContextId == operatingContextId);

            if (operatingContextRoles == null)
                throw new InvalidOperationException("No Roles found for OperatingContext.");

            List<Role> roles = operatingContextRoles.Select(operatingContextRole => _context.Roles.SingleOrDefault(r => r.Id == operatingContextRole.RoleId)).Where(role => role != null).ToList();

            return Task.FromResult(new PagedGridResult<IEnumerable<RoleRM>>
            {
                Data = _mapper.Map<IEnumerable<RoleRM>>(roles),
                Total = roles.Count,
                Errors = null,
                AggregateResult = null
            });
        }

        public Task<EGMSPermissionRM> GetEGMSPermissionAsync(int egmsPermissionId)
        {
            return Task.FromResult(_mapper.Map<EGMSPermission, EGMSPermissionRM>(_context.EGMSPermissions.SingleOrDefault(ep => ep.Id == egmsPermissionId)));
        }

        public Task<PagedGridResult<IEnumerable<EGMSPermissionRM>>> GetEGMSPermissionsForRoleAsync(int roleId)
        {
            ValidateRoleExists(roleId);

            IQueryable<RoleEGMSPermission> roleEGMSPermissions = _context.RoleEGMSPermissions.Where(rep => rep.RoleId == roleId);

            if (roleEGMSPermissions == null)
                throw new InvalidOperationException("No EGMSPermissions found for role.");

            List<EGMSPermission> egmsPermissions = new List<EGMSPermission>();

            foreach (RoleEGMSPermission roleEGMSPermission in roleEGMSPermissions)
            {
                EGMSPermission egmsPermission = _context.EGMSPermissions.SingleOrDefault(ep => ep.Id == roleEGMSPermission.EGMSPermissionId);

                if (egmsPermission != null)
                    egmsPermissions.Add(egmsPermission);
            }

            var retVal = new PagedGridResult<IEnumerable<EGMSPermissionRM>>
            {
                Data = _mapper.Map<IEnumerable<EGMSPermissionRM>>(egmsPermissions),
                Total = egmsPermissions.Count,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<EGMSPermissionRM> GetEGMSPermissionForRoleAsync(int roleId, int permissionId)
        {
            ValidateRoleExists(roleId);

            RoleEGMSPermission roleEGMSPermissions = _context.RoleEGMSPermissions.SingleOrDefault(rep => rep.RoleId == roleId && rep.EGMSPermissionId == permissionId);

            if (roleEGMSPermissions == null)
                throw new InvalidOperationException("EGMSPermissions not found for role.");

            return Task.FromResult(_mapper.Map<EGMSPermissionRM>(_context.EGMSPermissions.SingleOrDefault(ep => ep.Id == permissionId)));
        }

        public Task<PagedGridResult<IEnumerable<EGMSPermissionRM>>> GetEGMSPermissionsAsync(QueryModels.EGMSPermissionQueryParams queryParams)
        {
            List<EGMSPermission> egmsPermissions = _context.EGMSPermissions.ApplyQuery(queryParams).ToList();

            int totalCount = egmsPermissions.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = _context.EGMSPermissions.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            var retVal = new PagedGridResult<IEnumerable<EGMSPermissionRM>>
            {
                Data = _mapper.Map<IEnumerable<EGMSPermissionRM>>(egmsPermissions),
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<RoleEGMSPermissionRM> GetRoleEGMSPermissionAsync(int roleEGMSPermissionId)
        {
            RoleEGMSPermission roleEGMSPermission = _context.RoleEGMSPermissions.SingleOrDefault(rep => rep.Id == roleEGMSPermissionId);

            return Task.FromResult(_mapper.Map<RoleEGMSPermission, RoleEGMSPermissionRM>(roleEGMSPermission));
        }

        public Task<PagedGridResult<IEnumerable<RoleEGMSPermissionRM>>> GetRoleEGMSPermissionsAsync(QueryModels.RoleEGMSPermissionQueryParams queryParams)
        {
            List<RoleEGMSPermission> roleEGMSPermissions = _context.RoleEGMSPermissions.ApplyQuery(queryParams).ToList();

            int totalCount = roleEGMSPermissions.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = _context.RoleEGMSPermissions.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            return Task.FromResult(new PagedGridResult<IEnumerable<RoleEGMSPermissionRM>>
            {
                Data = _mapper.Map<IEnumerable<RoleEGMSPermissionRM>>(roleEGMSPermissions),
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            });
        }

        public Task<UserRM> GetUserAsync(int userId)
        {
            User user = _context.Users.SingleOrDefault(a => a.Id == userId);

            return Task.FromResult(_mapper.Map<User, UserRM>(user));
        }

        public Task<UserRM> GetUserForAssociateAsync(int associateId, int userId)
        {
            ValidateAssociateExists(associateId);

            AssociateUser associateUser = _context.AssociateUsers.SingleOrDefault(au => au.AssociateId == associateId && au.UserId == userId);

            if (associateUser == null)
                throw new InvalidOperationException("User not found for associate.");

            return Task.FromResult(_mapper.Map<User, UserRM>(_context.Users.SingleOrDefault(u => u.Id == userId)));
        }

        public Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersAsync(QueryModels.UserQueryParams queryParams)
        {
            List<User> users = _context.Users.ApplyQuery(queryParams).ToList();

            int totalCount = users.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = _context.Users.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            return Task.FromResult(new PagedGridResult<IEnumerable<UserRM>>
            {
                Data = _mapper.Map<IEnumerable<UserRM>>(users),
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            });
        }

        public Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersForAssociateAsync(int associateId)
        {
            ValidateAssociateExists(associateId);

            List<AssociateUser> associateUsers = _context.AssociateUsers.FindAll(au => au.AssociateId == associateId);

            if (associateUsers == null)
                throw new InvalidOperationException("Users not found for associate.");

            List<User> users = associateUsers.Select(associateUser => _context.Users.SingleOrDefault(u => u.Id == associateUser.UserId)).Where(user => user != null).ToList();

            return Task.FromResult(new PagedGridResult<IEnumerable<UserRM>>
            {
                Data = _mapper.Map<IEnumerable<UserRM>>(users),
                Total = users.Count,
                Errors = null,
                AggregateResult = null
            });
        }

        public Task<PagedGridResult<IEnumerable<CertificationRM>>> GetCertificationsAsync(QueryModels.CertificationQueryParams queryParams)
        {
            var results = _context.Certifications.ApplyQuery(queryParams).ToList();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = _context.Certifications.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            return Task.FromResult(new PagedGridResult<IEnumerable<CertificationRM>>
            {
                Data = _mapper.Map<IEnumerable<CertificationRM>>(results),
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            });
        }

        // TO DO:  Add checks for AssociateId
        public Task<CertificationRM> GetCertificationForOperatingContextAsync(int associateId, int operatingContextId, int certificationId)
        {
            OperatingContext operatingContext = ValidateOperatingContextExists(operatingContextId);

            CertificationRM certificationRM = _mapper.Map<Certification, CertificationRM>(_context.Certifications.SingleOrDefault(c => c.Id == operatingContext.CertificationId));

            return Task.FromResult(certificationRM);
        }


        #region Helper Methods

        private Associate ValidateAssociateExists(int associateId)
        {
            Associate associate = _context.Associates.SingleOrDefault(a => a.Id == associateId);

            if (associate == null)
                throw new InvalidOperationException("Associate not found.");

            return associate;
        }

        private OperatingContext ValidateOperatingContextExists(int operatingContextId)
        {
            OperatingContext operatingContext = _context.OperatingContexts.SingleOrDefault(a => a.Id == operatingContextId);

            if (operatingContext == null)
                throw new InvalidOperationException("OperatingContext not found.");

            return operatingContext;
        }

        private void ValidateRoleExists(int roleId)
        {
            Role role = _context.Roles.SingleOrDefault(r => r.Id == roleId);

            if (role == null)
                throw new InvalidOperationException("Role not found.");
        }

        private void ValidateContactExists(int contactId)
        {
            Contact contact = _context.Contacts.SingleOrDefault(c => c.Id == contactId);

            if (contact == null)
                throw new InvalidOperationException("Contact not found.");
        }

        private AgentRelationship ValidateAgentRelationshipExists(int principalId, int agentRelationshipId)
        {
            AgentRelationship agentRelationship =
                _context.AgentRelationships.SingleOrDefault(ar =>
                    ar.PrincipalId == principalId && ar.Id == agentRelationshipId);

            if (agentRelationship == null)
                throw new InvalidOperationException("Agent relationship not found for specified principal.");

            return agentRelationship;
        }

        #endregion
    }
}
