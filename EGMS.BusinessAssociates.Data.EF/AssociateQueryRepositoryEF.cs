﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EGMS.BusinessAssociates.Query;
using EGMS.BusinessAssociates.Query.ReadModels;

namespace EGMS.BusinessAssociates.Data.EF
{
    class AssociateQueryRepositoryEF : IAssociateQueryRepository
    {
        public Task<AssociateRM> GetAssociateAsync(int associateId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<AssociateRM>>> GetAssociatesAsync(QueryModels.AssociateQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<AddressRM> GetAddressAsync(int addressId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddressesAsync(QueryModels.AddressQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddressesAsync(int associateId)
        {
            throw new NotImplementedException();
        }

        public Task<AddressRM> GetAddressForContactAsync(int contactId, int addressId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddressesForContactAsync(QueryModels.AddressQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddressesForContactAsync(int associateId, int contactId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddressForContactAsync(int associateId, int contactId, int addressRelationshipId)
        {
            throw new NotImplementedException();
        }

        Task<AgentRelationshipRM> IAssociateQueryRepository.GetAgentRelationshipsAsync(QueryModels.AgentRelationshipQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<AgentRelationshipRM>>> GetAgentRelationshipsForPrincipalAsync(QueryModels.AgentRelationshipQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<AgentRelationshipRM>>> GetAgentRelationshipForPrincipalAsync(int principalId, int agentRelationshipId)
        {
            throw new NotImplementedException();
        }

        public Task<UserRM> GetUserForAgentRelationshipAsync(int associateId, int agentRelationshipId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserRM> GetUserForAgentRelationshipAsync(int agentRelationshipI, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersForAgentRelationshipAsync(QueryModels.UserQueryParams queryParams)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersForAgentRelationshipAsync(int associateId, int agentRelationshipId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersForAgentRelationshipAsync(int associateId, int principalId, int agentRelationshipId)
        {
            throw new NotImplementedException();
        }

        public Task<AgentRelationshipRM> GetAgentRelationshipAsync(int agentRelationshipId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedGridResult<IEnumerable<AgentRelationshipRM>>> GetAgentRelationshipsAsync(QueryModels.AgentRelationshipQueryParams queryParams)
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
