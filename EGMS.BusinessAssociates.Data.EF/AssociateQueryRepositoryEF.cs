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
            Address address = _context.Addresses.SingleOrDefault(a => a.Id == addressId);
            return Task.FromResult(_mapper.Map<AddressRM>(address));
        }

        public async Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddressesAsync(QueryModels.AddressQueryParams queryParams)
        {
            List<Address> addresses = await _context.Addresses.ApplyQuery(queryParams).ToListAsync();

            int totalCount = addresses.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = _context.Addresses.ApplyQuery(queryParams, false);
                totalCount = await countQuery.CountAsync();
            }

            return new PagedGridResult<IEnumerable<AddressRM>>
            {
                Data = _mapper.Map<IEnumerable<AddressRM>>(addresses),
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            };
        }

#pragma warning disable 1998
        public async Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddressesForAssociateAsync(int associateId)
#pragma warning restore 1998
        {
            ValidateAssociateExists(associateId);

            List<AssociateAddress> associateAddresses = _context.AssociateAddresses.FindAll(aa => aa.AssociateId == associateId);

            if (associateAddresses == null)
                throw new InvalidOperationException("No addresses found for specified associate.");

            List<Address> addresses2 = new List<Address>();

            foreach (AssociateAddress aa in associateAddresses)
            {
                addresses2.Add(_context.Addresses.Find(aa.AddressId));
            }

            return new PagedGridResult<IEnumerable<AddressRM>>
            {
                Data = _mapper.Map<IEnumerable<AddressRM>>(addresses2),
                Total = addresses2.Count,
                Errors = null,
                AggregateResult = null
            };
        }

        public Task<AddressRM> GetAddressForContactAsync(int contactId, int addressId)
        {
            ContactAddress contactAddress =
                _context.ContactAddresses.SingleOrDefault(ca => ca.ContactId == contactId && ca.AddressId == addressId);

            if (contactAddress == null)
                throw new InvalidOperationException("Specified address not found for specified contact.");

            Address address = _context.Addresses.SingleOrDefault(a => a.Id == addressId);

            if (address == null)
                throw new InvalidOperationException("Address not found.");

            return Task.FromResult(_mapper.Map<AddressRM>(address));
        }

#pragma warning disable 1998
        public async Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddressesForContactAsync(int associateId, int contactId)
#pragma warning restore 1998
        {
            ValidateAssociateExists(associateId);

            List<ContactAddress> contactAddresses = _context.ContactAddresses.FindAll(aa => aa.ContactId == contactId);

            if (contactAddresses == null)
                throw new InvalidOperationException("No addresses found for specified contact.");

            List<Address> addresses = new List<Address>();

            foreach (ContactAddress aa in contactAddresses)
            {
                addresses.Add(_context.Addresses.Find(aa.AddressId));
            }

            return new PagedGridResult<IEnumerable<AddressRM>>
            {
                Data = _mapper.Map<IEnumerable<AddressRM>>(addresses),
                Total = addresses.Count,
                Errors = null,
                AggregateResult = null
            };
        }


        public async Task<PagedGridResult<IEnumerable<AgentRelationshipRM>>> GetAgentRelationshipsAsync(QueryModels.AgentRelationshipQueryParams queryParams)
        {
            var agentRelationships = _context.AgentRelationships;

            var filtered = agentRelationships.ApplyQuery(queryParams);

            var results = await filtered.ToListAsync();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = agentRelationships.ApplyQuery(queryParams, false);
                totalCount = await countQuery.CountAsync();
            }

            var retData = _mapper.Map<IEnumerable<AgentRelationshipRM>>(results);

            var retVal = new PagedGridResult<IEnumerable<AgentRelationshipRM>>
            {
                Data = retData,
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            };

            return retVal;
        }

        public Task<AgentRelationshipRM> GetAgentRelationshipForPrincipalAsync(int principalId, int agentRelationshipId)
        {
            AgentRelationship agentRelationship =
                _context.AgentRelationships.SingleOrDefault(ar => ar.PrincipalId == principalId && ar.Id == agentRelationshipId);

            if (agentRelationship == null)
                throw new InvalidOperationException("Specified agent relationship not found for specified principal.");

            var retVal = _mapper.Map<AgentRelationshipRM>(agentRelationship);

            return Task.FromResult(retVal);
        }

        public Task<UserRM> GetUserForAgentRelationshipAsync(int principalId, int agentRelationshipId, int userId)
        {
            AgentRelationship agentRelationship =
                _context.AgentRelationships.SingleOrDefault(ar => ar.PrincipalId == principalId && ar.Id == agentRelationshipId);

            if (agentRelationship == null)
                throw new InvalidOperationException("Agent relationship not found for specified principal.");

            IEnumerable<AgentUser> agentUsers = _context.AgentUsers.Where(au => au.AgentId == agentRelationship.AgentId);

            if (agentUsers == null)
                throw new InvalidOperationException("Users not found for AgentRelationship.");

            User user = _context.Users.SingleOrDefault(u => u.Id == userId);
            
            UserRM retData = _mapper.Map<UserRM>(user);

            return Task.FromResult(retData);
        }

        public Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersForAgentRelationshipAsync(int principalId, int agentRelationshipId)
        {
            AgentRelationship agentRelationship = _context.AgentRelationships.SingleOrDefault(ar => ar.PrincipalId == principalId && ar.Id == agentRelationshipId);

            if (agentRelationship == null)
                throw new InvalidOperationException("Agent relationship not found for specified principal.");

            IEnumerable<AgentUser> agentUsers = _context.AgentUsers.Where(au => au.AgentId == agentRelationship.AgentId);

            if (agentUsers == null)
                throw new InvalidOperationException("Users not found for AgentRelationship.");

            List<User> users = new List<User>();

            foreach (AgentUser agentUser in agentUsers)
            {
                User user = _context.Users.SingleOrDefault(u => u.Id == agentUser.UserId);

                if (user != null)
                    users.Add(user);
            }

            var retData = _mapper.Map<IEnumerable<UserRM>>(users);

            var retVal = new PagedGridResult<IEnumerable<UserRM>>
            {
                Data = retData,
                Total = users.Count,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersForAgentRelationshipAsync(QueryModels.UserQueryParams queryParams)
        {
            var users = _context.Users;

            var filtered = users.ApplyQuery(queryParams);

            var results = filtered.ToList();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = users.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            var retData = _mapper.Map<IEnumerable<UserRM>>(results);

            var retVal = new PagedGridResult<IEnumerable<UserRM>>
            {
                Data = retData,
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersForAgentRelationshipAsync(int associateId, int principalId, int agentRelationshipId)
        {
            AgentRelationship agentRelationship =
                _context.AgentRelationships.SingleOrDefault(ar => ar.PrincipalId == principalId && ar.Id == agentRelationshipId);

            if (agentRelationship == null)
                throw new InvalidOperationException("Agent relationship not found for specified principal.");

            IEnumerable<AgentUser> agentUsers = _context.AgentUsers.Where(au => au.AgentId == agentRelationship.AgentId);

            if (agentUsers == null)
                throw new InvalidOperationException("Users not found for AgentRelationship.");

            List<User> users = new List<User>();

            foreach (AgentUser agentUser in agentUsers)
            {
                User user = _context.Users.Single(u => u.Id == agentUser.UserId);

                if (user != null)
                    users.Add(user);
            }

            var retData = _mapper.Map<IEnumerable<UserRM>>(users);

            var retVal = new PagedGridResult<IEnumerable<UserRM>>
            {
                Data = retData,
                Total = users.Count,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<AgentRelationshipRM> GetAgentRelationshipAsync(int agentRelationshipId)
        {
            var agentRelationships = _context.AgentRelationships;

            var result = agentRelationships.SingleOrDefault(ar => ar.Id == agentRelationshipId);

            var retVal = _mapper.Map<AgentRelationshipRM>(result);

            return Task.FromResult(retVal);
        }

        public Task<ContactRM> GetContactAsync(int associateId, int contactId)
        {
            var associateContacts = _context.AssociateContacts;

            Contact contact = null;

            foreach (AssociateContact associateContact in associateContacts)
            {
                if (associateContact.ContactId == contactId && associateContact.AssociateId == associateId)
                {
                    contact = _context.Contacts.SingleOrDefault(c => c.Id == contactId);
                }
            }

            return Task.FromResult(_mapper.Map<Contact, ContactRM>(contact));
        }

        public Task<ContactRM> GetContactAsync(int contactId)
        {
            return Task.FromResult(_mapper.Map<Contact, ContactRM>(_context.Contacts.SingleOrDefault(c => c.Id == contactId)));
        }

        public Task<PagedGridResult<IEnumerable<ContactRM>>> GetContactsAsync(QueryModels.ContactQueryParams queryParams)
        {
            var contacts = _context.Contacts;

            var filtered = contacts.ApplyQuery(queryParams);

            var results = filtered.ToList();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = contacts.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            var retData = _mapper.Map<IEnumerable<ContactRM>>(results);

            var retVal = new PagedGridResult<IEnumerable<ContactRM>>
            {
                Data = retData,
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

            List<Contact> contacts = new List<Contact>();

            foreach (AssociateContact ac in associateContacts)
            {
                contacts.Add(_context.Contacts.Find(ac.ContactId));
            }

            var retData = _mapper.Map<IEnumerable<ContactRM>>(contacts);

            var retVal = new PagedGridResult<IEnumerable<ContactRM>>
            {
                Data = retData,
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
            var contactConfigurations = _context.ContactConfigurations;

            var filtered = contactConfigurations.ApplyQuery(queryParams);

            var results = filtered.ToList();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = contactConfigurations.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            var retData = _mapper.Map<IEnumerable<ContactConfigurationRM>>(results);

            var retVal = new PagedGridResult<IEnumerable<ContactConfigurationRM>>
            {
                Data = retData,
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
            
            var retData = _mapper.Map<IEnumerable<ContactConfigurationRM>>(contactConfigurations);

            var retVal = new PagedGridResult<IEnumerable<ContactConfigurationRM>>
            {
                Data = retData,
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
            var customers = _context.Customers;

            var filtered = customers.ApplyQuery(queryParams);

            var results = filtered.ToList();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = customers.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            var retData = _mapper.Map<IEnumerable<CustomerRM>>(results);

            var retVal = new PagedGridResult<IEnumerable<CustomerRM>>
            {
                Data = retData,
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

            List<Customer> customers = new List<Customer>();

            foreach (AssociateCustomer ac in associateCustomers)
            {
                customers.Add(_context.Customers.Find(ac.CustomerId));
            }

            var retData = _mapper.Map<IEnumerable<CustomerRM>>(customers);

            var retVal = new PagedGridResult<IEnumerable<CustomerRM>>
            {
                Data = retData,
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

            List<EMail> eMails = new List<EMail>();

            foreach (ContactEMail contactEMail in contactEMails)
            {
                EMail email = _context.EMails.SingleOrDefault(e => e.Id == contactEMail.EMailId);

                if (email != null)
                    eMails.Add(email);
            }

            var retData = _mapper.Map<IEnumerable<EMailRM>>(eMails);

            var retVal = new PagedGridResult<IEnumerable<EMailRM>>
            {
                Data = retData,
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
            Associate associate = _context.Associates.SingleOrDefault(a => a.Id == associateId);

            if (associate == null)
                throw new InvalidOperationException("Associate not found.");

            List<AssociateEMail> associateEMails = _context.AssociateEMails.FindAll(ce => ce.AssociateId == associateId);

            if (associateEMails == null)
                throw new InvalidOperationException("EMails not found for Associate.");
            
            List<EMail> eMails = new List<EMail>();

            foreach (AssociateEMail associateEMail in associateEMails)
            {
                EMail email = _context.EMails.SingleOrDefault(e => e.Id == associateEMail.EMailId);

                if (email != null)
                    eMails.Add(email);
            }

            var retData = _mapper.Map<IEnumerable<EMailRM>>(eMails);

            var retVal = new PagedGridResult<IEnumerable<EMailRM>>
            {
                Data = retData,
                Total = eMails.Count,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<PagedGridResult<IEnumerable<EMailRM>>> GetEMailsAsync(QueryModels.EMailQueryParams queryParams)
        {
            var emails = _context.EMails;

            var filtered = emails.ApplyQuery(queryParams);

            var results = filtered.ToList();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = emails.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            var retData = _mapper.Map<IEnumerable<EMailRM>>(results);

            var retVal = new PagedGridResult<IEnumerable<EMailRM>>
            {
                Data = retData,
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
            Associate associate = _context.Associates.SingleOrDefault(a => a.Id == associateId);

            if (associate == null)
                throw new InvalidOperationException("Associate not found.");

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

            OperatingContext operatingContext = _context.OperatingContexts.SingleOrDefault(oc => oc.Id == operatingContextId);

            return Task.FromResult(_mapper.Map<OperatingContext, OperatingContextRM>(operatingContext));
        }

        public Task<PagedGridResult<IEnumerable<OperatingContextRM>>> GetOperatingContextsAsync(QueryModels.OperatingContextQueryParams queryParams)
        {
            var operatingContexts = _context.OperatingContexts;

            var filtered = operatingContexts.ApplyQuery(queryParams);

            var results = filtered.ToList();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = operatingContexts.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            var retData = _mapper.Map<IEnumerable<OperatingContextRM>>(results);

            var retVal = new PagedGridResult<IEnumerable<OperatingContextRM>>
            {
                Data = retData,
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<PagedGridResult<IEnumerable<OperatingContextRM>>> GetOperatingContextsForAssociateAsync(int associateId)
        {
            List<AssociateOperatingContext> associateOperatingContexts = _context.AssociateOperatingContexts.FindAll(aoc => aoc.AssociateId == associateId);

            if (associateOperatingContexts == null)
                throw new InvalidOperationException("No Operating Contexts found for Associate.");

            List<OperatingContext> operatingContexts = new List<OperatingContext>();

            foreach (AssociateOperatingContext associateOperatingContext in associateOperatingContexts)
            {
                OperatingContext operatingContext = _context.OperatingContexts.SingleOrDefault(e => e.Id == associateOperatingContext.OperatingContextId);

                if (operatingContext != null)
                    operatingContexts.Add(operatingContext);
            }

            var retData = _mapper.Map<IEnumerable<OperatingContextRM>>(operatingContexts);

            var retVal = new PagedGridResult<IEnumerable<OperatingContextRM>>
            {
                Data = retData,
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

            List<OperatingContext> operatingContexts = new List<OperatingContext>();

            foreach (CustomerOperatingContext customerOperatingContext in customerOperatingContexts)
            {
                OperatingContext operatingContext = _context.OperatingContexts.SingleOrDefault(e => e.Id == customerOperatingContext.OperatingContextId);

                if (operatingContext != null)
                    operatingContexts.Add(operatingContext);
            }

            var retData = _mapper.Map<IEnumerable<OperatingContextRM>>(operatingContexts);

            var retVal = new PagedGridResult<IEnumerable<OperatingContextRM>>
            {
                Data = retData,
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
            Contact contact = _context.Contacts.SingleOrDefault(a => a.Id == contactId);

            if (contact == null)
                throw new InvalidOperationException("Contact not found.");

            AssociatePhone associatePhone = _context.AssociatePhones.SingleOrDefault(ae => ae.AssociateId == associateId && ae.PhoneId == phoneId);

            if (associatePhone == null)
                throw new InvalidOperationException("Phone not found for Contact.");

            Phone phone = _context.Phones.SingleOrDefault(e => e.Id == phoneId);

            return Task.FromResult(_mapper.Map<Phone, PhoneRM>(phone));
        }

        public Task<PagedGridResult<IEnumerable<PhoneRM>>> GetPhonesForContactAsync(int associateId, int contactId)
        {
            Contact contact = _context.Contacts.SingleOrDefault(c => c.Id == contactId);

            if (contact == null)
                throw new InvalidOperationException("Contact not found.");

            List<ContactPhone> contactPhones = _context.ContactPhones.FindAll(cp => cp.ContactId == contactId);

            if (contactPhones == null)
                throw new InvalidOperationException("No phones found for Contact");

            List<Phone> phones = new List<Phone>();

            foreach (ContactPhone contactPhone in contactPhones)
            {
                Phone phone = _context.Phones.SingleOrDefault(oc => oc.Id == contactPhone.PhoneId);

                if (phone != null)
                    phones.Add(phone);
            }

            var retData = _mapper.Map<IEnumerable<PhoneRM>>(phones);

            var retVal = new PagedGridResult<IEnumerable<PhoneRM>>
            {
                Data = retData,
                Total = phones.Count,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<PhoneRM> GetPhoneForAssociateAsync(int associateId, int phoneId)
        {
            Associate associate = _context.Associates.SingleOrDefault(a => a.Id == associateId);

            if (associate == null)
                throw new InvalidOperationException("Associate not found.");

            AssociatePhone associatePhone = _context.AssociatePhones.SingleOrDefault(ae => ae.AssociateId == associateId && ae.PhoneId == phoneId);

            if (associatePhone == null)
                throw new InvalidOperationException("Phone not found for associate.");

            Phone phone = _context.Phones.SingleOrDefault(e => e.Id == phoneId);

            return Task.FromResult(_mapper.Map<Phone, PhoneRM>(phone));
        }

        public Task<PagedGridResult<IEnumerable<PhoneRM>>> GetPhonesForAssociateAsync(int associateId)
        {
            List<AssociatePhone> associatePhones = _context.AssociatePhones.FindAll(ap => ap.AssociateId == associateId);

            if (associatePhones == null)
                throw new InvalidOperationException("No Phones found for Associate.");

            List<Phone> phones = new List<Phone>();

            foreach (AssociatePhone associatePhone in associatePhones)
            {
                Phone phone = _context.Phones.SingleOrDefault(p => p.Id == associatePhone.PhoneId);

                if (phone != null)
                    phones.Add(phone);
            }

            var retData = _mapper.Map<IEnumerable<PhoneRM>>(phones);

            var retVal = new PagedGridResult<IEnumerable<PhoneRM>>
            {
                Data = retData,
                Total = phones.Count,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<PagedGridResult<IEnumerable<PhoneRM>>> GetPhonesAsync(QueryModels.PhoneQueryParams queryParams)
        {
            var phones = _context.Phones;

            var filtered = phones.ApplyQuery(queryParams);

            var results = filtered.ToList();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = phones.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            var retData = _mapper.Map<IEnumerable<PhoneRM>>(results);

            var retVal = new PagedGridResult<IEnumerable<PhoneRM>>
            {
                Data = retData,
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<RoleRM> GetRoleAsync(int roleId)
        {
            Role role = _context.Roles.SingleOrDefault(r => r.Id == roleId);

            return Task.FromResult(_mapper.Map<Role, RoleRM>(role));
        }

        public Task<PagedGridResult<IEnumerable<RoleRM>>> GetRolesAsync(QueryModels.RoleQueryParams queryParams)
        {
            var roles = _context.Roles;

            var filtered = roles.ApplyQuery(queryParams);

            var results = filtered.ToList();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = roles.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            var retData = _mapper.Map<IEnumerable<RoleRM>>(results);

            var retVal = new PagedGridResult<IEnumerable<RoleRM>>
            {
                Data = retData,
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<RoleRM> GetRoleForOperatingContextAsync(int associateId, int operatingContextId, int roleId)
        {
            OperatingContext operatingContext =
                _context.OperatingContexts.SingleOrDefault(oc => oc.Id == operatingContextId);

            if (operatingContext == null)
                throw new InvalidOperationException("OperatingContext not found.");

            OperatingContextRole operatingContextRole = _context.OperatingContextRoles.SingleOrDefault(ocr => ocr.RoleId == roleId);

            if (operatingContextRole == null)
                throw new InvalidOperationException("Role not found for OperatingContext.");

            Role role = _context.Roles.SingleOrDefault(r => r.Id == roleId);

            return Task.FromResult(_mapper.Map<Role, RoleRM>(role));
        }

        public Task<PagedGridResult<IEnumerable<RoleRM>>> GetRolesForOperatingContextAsync(int associateId, int operatingContextId)
        {
            List<OperatingContextRole> operatingContextRoles = _context.OperatingContextRoles.FindAll(ocr =>ocr.OperatingContextId == operatingContextId);

            if (operatingContextRoles == null)
                throw new InvalidOperationException("No Roles found for OperatingContext.");

            List<Role> roles = new List<Role>();

            foreach (OperatingContextRole operatingContextRole in operatingContextRoles)
            {
                Role role = _context.Roles.SingleOrDefault(r => r.Id == operatingContextRole.RoleId);

                if (role != null)
                    roles.Add(role);
            }

            var retData = _mapper.Map<IEnumerable<RoleRM>>(roles);

            var retVal = new PagedGridResult<IEnumerable<RoleRM>>
            {
                Data = retData,
                Total = roles.Count,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<EGMSPermissionRM> GetEGMSPermissionAsync(int egmsPermissionId)
        {
            EGMSPermission egmsPermission = _context.EGMSPermissions.SingleOrDefault(ep => ep.Id == egmsPermissionId);

            return Task.FromResult(_mapper.Map<EGMSPermission, EGMSPermissionRM>(egmsPermission));
        }

        public Task<PagedGridResult<IEnumerable<EGMSPermissionRM>>> GetEGMSPermissionsForRoleAsync(int roleId)
        {
            Role role = _context.Roles.SingleOrDefault(r => r.Id == roleId);

            if (role == null)
                throw new InvalidOperationException("Role not found.");

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

            var retData = _mapper.Map<IEnumerable<EGMSPermissionRM>>(egmsPermissions);

            var retVal = new PagedGridResult<IEnumerable<EGMSPermissionRM>>
            {
                Data = retData,
                Total = egmsPermissions.Count,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<EGMSPermissionRM> GetEGMSPermissionForRoleAsync(int roleId, int permissionId)
        {
            Role role = _context.Roles.SingleOrDefault(r => r.Id == roleId);

            if (role == null)
                throw new InvalidOperationException("Role not found.");

            RoleEGMSPermission roleEGMSPermissions = _context.RoleEGMSPermissions.SingleOrDefault(rep => rep.RoleId == roleId && rep.EGMSPermissionId == permissionId);

            if (roleEGMSPermissions == null)
                throw new InvalidOperationException("EGMSPermissions not found for role.");

            EGMSPermission egmsPermission = _context.EGMSPermissions.SingleOrDefault(ep => ep.Id == permissionId);

            var retVal = _mapper.Map<EGMSPermissionRM>(egmsPermission);

            return Task.FromResult(retVal);
        }

        public Task<PagedGridResult<IEnumerable<EGMSPermissionRM>>> GetEGMSPermissionsAsync(QueryModels.EGMSPermissionQueryParams queryParams)
        {
            var egmsPermissions = _context.EGMSPermissions;

            var filtered = egmsPermissions.ApplyQuery(queryParams);

            var results = filtered.ToList();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = egmsPermissions.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            var retData = _mapper.Map<IEnumerable<EGMSPermissionRM>>(results);

            var retVal = new PagedGridResult<IEnumerable<EGMSPermissionRM>>
            {
                Data = retData,
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
            var roleEGMSPermissions = _context.RoleEGMSPermissions;

            var filtered = roleEGMSPermissions.ApplyQuery(queryParams);

            var results = filtered.ToList();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = roleEGMSPermissions.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            var retData = _mapper.Map<IEnumerable<RoleEGMSPermissionRM>>(results);

            var retVal = new PagedGridResult<IEnumerable<RoleEGMSPermissionRM>>
            {
                Data = retData,
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<UserRM> GetUserAsync(int userId)
        {
            User user = _context.Users.SingleOrDefault(a => a.Id == userId);

            return Task.FromResult(_mapper.Map<User, UserRM>(user));
        }

        public Task<UserRM> GetUserForAssociateAsync(int associateId, int userId)
        {
            Associate associate = _context.Associates.SingleOrDefault(a => a.Id == associateId);

            if (associate == null)
                throw new InvalidOperationException("Associate not found.");

            AssociateUser associateUser = _context.AssociateUsers.SingleOrDefault(au => au.AssociateId == associateId && au.UserId == userId);

            if (associateUser == null)
                throw new InvalidOperationException("User not found for associate.");

            User user = _context.Users.SingleOrDefault(u => u.Id == userId);

            return Task.FromResult(_mapper.Map<User, UserRM>(user));
        }

        public Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersAsync(QueryModels.UserQueryParams queryParams)
        {
            var users = _context.Users;

            var filtered = users.ApplyQuery(queryParams);

            var results = filtered.ToList();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = users.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            var retData = _mapper.Map<IEnumerable<UserRM>>(results);

            var retVal = new PagedGridResult<IEnumerable<UserRM>>
            {
                Data = retData,
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersForAssociateAsync(int associateId)
        {
            ValidateAssociateExists(associateId);

            List<AssociateUser> associateUsers = _context.AssociateUsers.FindAll(au => au.AssociateId == associateId);

            if (associateUsers == null)
                throw new InvalidOperationException("Users not found for associate.");

            List<User> users = new List<User>();

            foreach (AssociateUser associateUser in associateUsers)
            {
                User user = _context.Users.SingleOrDefault(u => u.Id == associateUser.UserId);

                if (user != null)
                    users.Add(user);
            }
            
            var retData = _mapper.Map<IEnumerable<UserRM>>(users);

            var retVal = new PagedGridResult<IEnumerable<UserRM>>
            {
                Data = retData,
                Total = users.Count,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<PagedGridResult<IEnumerable<CertificationRM>>> GetCertificationsAsync(QueryModels.CertificationQueryParams queryParams)
        {
            var certifications = _context.Certifications;

            var filtered = certifications.ApplyQuery(queryParams);

            var results = filtered.ToList();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = certifications.ApplyQuery(queryParams, false);
                totalCount = countQuery.Count();
            }

            var retData = _mapper.Map<IEnumerable<CertificationRM>>(results);

            var retVal = new PagedGridResult<IEnumerable<CertificationRM>>
            {
                Data = retData,
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            };

            return Task.FromResult(retVal);
        }

        public Task<CertificationRM> GetCertificationForOperatingContextAsync(int associateId, int operatingContextId, int certificationId)
        {
            OperatingContext operatingContext =
                _context.OperatingContexts.SingleOrDefault(oc => oc.Id == operatingContextId);

            if (operatingContext == null)
                throw new InvalidOperationException("OperatingContext not found.");

            Certification certification = _context.Certifications.SingleOrDefault(c => c.Id == operatingContext.CertificationId);

            var retVal = _mapper.Map<Certification, CertificationRM>(certification);

            return Task.FromResult(retVal);
        }


        #region Helper Methods

        private void ValidateAssociateExists(int associateId)
        {
            Associate associate = _context.Associates.SingleOrDefault(a => a.Id == associateId);

            if (associate == null)
                throw new InvalidOperationException("Associate not found.");
        }

        #endregion
    }
}
