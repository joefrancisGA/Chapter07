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
            var associates = _context.Associates;

            var filtered = associates.ApplyQuery(queryParams);

            var results = await filtered.ToListAsync();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = associates.ApplyQuery(queryParams, false);
                totalCount = await countQuery.CountAsync();
            }

            var retData = _mapper.Map<IEnumerable<AssociateRM>>(results);

            var retVal = new PagedGridResult<IEnumerable<AssociateRM>>
            {
                Data = retData,
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            };

            return retVal;
        }

        public Task<AddressRM> GetAddressAsync(int addressId)
        {
            var addresses = _context.Addresses;

            var result = addresses.SingleOrDefault(a => a.Id == addressId);

            var retVal = _mapper.Map<AddressRM>(result);

            return Task.FromResult(retVal);
        }

        public async Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddressesAsync(QueryModels.AddressQueryParams queryParams)
        {
            var addresses = _context.Addresses;

            var filtered = addresses.ApplyQuery(queryParams);

            var results = await filtered.ToListAsync();

            int totalCount = results.Count;

            if (queryParams.Page != null && queryParams.PageSize != null)
            {
                var countQuery = addresses.ApplyQuery(queryParams, false);
                totalCount = await countQuery.CountAsync();
            }

            var retData = _mapper.Map<IEnumerable<AddressRM>>(results);

            var retVal = new PagedGridResult<IEnumerable<AddressRM>>
            {
                Data = retData,
                Total = totalCount,
                Errors = null,
                AggregateResult = null
            };

            return retVal;
        }

#pragma warning disable 1998
        public async Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddressesForAssociateAsync(int associateId)
#pragma warning restore 1998
        {
            List<AssociateAddress> associateAddresses = _context.AssociateAddresses.FindAll(aa => aa.AssociateId == associateId);

            if (associateAddresses == null)
                throw new InvalidOperationException("No addresses found for specified associate.");

            List<Address> addresses2 = new List<Address>();

            foreach (AssociateAddress aa in associateAddresses)
            {
                addresses2.Add(_context.Addresses.Find(aa.AddressId));
            }

            var retData = _mapper.Map<IEnumerable<AddressRM>>(addresses2);

            var retVal = new PagedGridResult<IEnumerable<AddressRM>>
            {
                Data = retData,
                Total = addresses2.Count,
                Errors = null,
                AggregateResult = null
            };

            return retVal;
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

            var retVal = _mapper.Map<AddressRM>(address);

            return Task.FromResult(retVal);
        }

#pragma warning disable 1998
        public async Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddressesForContactAsync(int associateId, int contactId)
#pragma warning restore 1998
        {
            List<ContactAddress> contactAddresses = _context.ContactAddresses.FindAll(aa => aa.ContactId == contactId);

            if (contactAddresses == null)
                throw new InvalidOperationException("No addresses found for specified contact.");

            List<Address> addresses = new List<Address>();

            foreach (ContactAddress aa in contactAddresses)
            {
                addresses.Add(_context.Addresses.Find(aa.AddressId));
            }

            var retData = _mapper.Map<IEnumerable<AddressRM>>(addresses);

            var retVal = new PagedGridResult<IEnumerable<AddressRM>>
            {
                Data = retData,
                Total = addresses.Count,
                Errors = null,
                AggregateResult = null
            };

            return retVal;
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

        public async Task<PagedGridResult<IEnumerable<AgentRelationshipRM>>> GetAgentRelationshipsForPrincipalAsync(int principalId, QueryModels.AgentRelationshipQueryParams queryParams)
        {
            var agentRelationships = _context.AgentRelationships;

            queryParams.PrincipalId = principalId;

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
            throw new NotImplementedException();
        }

        public Task<ContactRM> GetContactAsync(int associateId, int contactId)
        {
            throw new NotImplementedException();
        }

        public Task<ContactRM> GetContactAsync(int contactId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<ContactRM>>> GetContactsAsync(QueryModels.ContactQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<ContactRM>>> GetContactsAsync(int associateId)
        {
            throw new NotImplementedException();
        }

        public Task<ContactConfigurationRM> GetContactConfigurationForContactAsync(int associateId, int contactId, int contactConfigurationId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<ContactConfigurationRM>>> GetContactConfigurationsForContactAsync(QueryModels.ContactConfigurationQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<ContactConfigurationRM>>> GetContactConfigurationsForContactAsync(int associateId, int contactId)
        {
            throw new NotImplementedException();
        }

        public Task<ContactConfigurationRM> GetContactConfigurationAsync(int contactConfigurationId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<ContactConfigurationRM>>> GetContactConfigurationsAsync(QueryModels.ContactConfigurationQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerRM> GetCustomerAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<CustomerRM>>> GetCustomersAsync(QueryModels.CustomerQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<CustomerRM>>> GetCustomersAsync(int associateId)
        {
            throw new NotImplementedException();
        }

        public Task<EMailRM> GetEMailAsync(int eMailId)
        {
            throw new NotImplementedException();
        }

        public Task<EMailRM> GetEMailForContactAsync(int associateId, int contactId, int eMailId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<EMailRM>>> GetEMailsForContactAsync(int associateId, int contactId)
        {
            throw new NotImplementedException();
        }

        public Task<EMailRM> GetEMailForAssociateAsync(int associateId, int eMailId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<EMailRM>>> GetEMailsForAssociateAsync(int associateId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<EMailRM>>> GetEMailsAsync(QueryModels.EMailQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<OperatingContextRM> GetOperatingContextAsync(int operatingContextId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<OperatingContextRM>>> GetOperatingContextsForAssociateAsync(QueryModels.OperatingContextQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<OperatingContextRM>>> GetOperatingContextsForAssociateAsync(int associateId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<OperatingContextRM>>> GetOperatingContextsForCustomerAsync(QueryModels.OperatingContextQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<OperatingContextRM>>> GetOperatingContextsForCustomerAsync(int associateId, int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<OperatingContextRM>>> GetOperatingContextsAsync(QueryModels.OperatingContextQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<PhoneRM> GetPhoneAsync(int phoneId)
        {
            throw new NotImplementedException();
        }

        public Task<PhoneRM> GetPhoneForContactAsync(int associateId, int contactId, int phoneId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<PhoneRM>>> GetPhonesForContactAsync(int associateId, int contactId)
        {
            throw new NotImplementedException();
        }

        public Task<PhoneRM> GetPhoneForAssociateAsync(int associateId, int phoneId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<PhoneRM>>> GetPhonesForAssociateAsync(int associateId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<PhoneRM>>> GetPhonesAsync(QueryModels.PhoneQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<RoleRM> GetRoleAsync(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<RoleRM>>> GetRolesAsync(QueryModels.RoleQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<RoleRM> GetRoleForOperatingContextAsync(int associateId, int operatingContextId, int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<RoleRM>>> GetRolesForOperatingContextAsync(int associateId, int operatingContextId)
        {
            throw new NotImplementedException();
        }

        public Task<EGMSPermissionRM> GetEGMSPermissionAsync(int egmsPermissionId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<EGMSPermissionRM>>> GetEGMSPermissionsForAssociateAsync(int associateId)
        {
            throw new NotImplementedException();
        }

        public Task<EGMSPermissionRM> GetEGMSPermissionForAssociateAsync(int associateId, int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<EGMSPermissionRM>>> GetEGMSPermissionsAsync(QueryModels.EGMSPermissionQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<RoleEGMSPermissionRM> GetRoleEGMSPermission(int roleEGMSPermissionId)
        {
            throw new NotImplementedException();
        }

        public Task<RoleEGMSPermissionRM> GetRoleEGMSPermissionForAssociateAsync(int associateId, int roleEGMSPermissionId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<RoleEGMSPermissionRM>>> GetRoleEGMSPermissionsAsync(QueryModels.RoleEGMSPermissionQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<RoleEGMSPermissionRM>>> GetRoleEGMSPermissionsForAssociateAsync(int associateId)
        {
            throw new NotImplementedException();
        }

        public Task<UserRM> GetUserAsync(int associateId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserRM> GetUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersAsync(QueryModels.UserQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersAsync(int associateId)
        {
            throw new NotImplementedException();
        }

        public Task<CertificationRM> GetCertificationsAsync(QueryModels.CertificationQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<CertificationRM>>> GetCertificationsForOperatingContextAsync(int associateId, int operatingContext,
            QueryModels.CertificationQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<CertificationRM>>> GetCertificationForOperatingContextAsync(int associateId, int operatingContextId, int certificationId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<CertificationRM>>> GetCertificationsForOperatingContextAsync(int operatingContext, QueryModels.CertificationQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<CertificationRM>>> GetCertificationsForOperatingContextAsync(int associateId, int operatingContextId, int certificationId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<CertificationRM>>> GetCertificationsForOperatingContextAsync(int associateId, int operatingContextId)
        {
            throw new NotImplementedException();
        }

        Task<EGMSPermissionRM> IAssociateQueryRepository.GetEGMSPermissionsAsync(QueryModels.EGMSPermissionQueryParams request)
        {
            throw new NotImplementedException();
        }
    }
}
