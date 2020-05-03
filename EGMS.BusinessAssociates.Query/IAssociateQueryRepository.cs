using System.Collections.Generic;
using System.Threading.Tasks;
using EGMS.BusinessAssociates.Query.ReadModels;


namespace EGMS.BusinessAssociates.Query
{
    public interface IAssociateQueryRepository
    {
        Task<AssociateRM> GetAssociateAsync(int associateId);
        Task<PagedGridResult<IEnumerable<AssociateRM>>> GetAssociatesAsync(QueryModels.AssociateQueryParams queryParams);

        Task<AddressRM> GetAddressAsync(int addressId);
        Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddressesAsync(QueryModels.AddressQueryParams queryParams);
        Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddressesForAssociateAsync(int associateId);

        Task<AddressRM> GetAddressForContactAsync(int contactId, int addressId);
        Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddressesForContactAsync(int associateId, int contactId);

        Task<PagedGridResult<IEnumerable<AgentRelationshipRM>>> GetAgentRelationshipsAsync(QueryModels.AgentRelationshipQueryParams queryParams);
        Task<PagedGridResult<IEnumerable<AgentRelationshipRM>>> GetAgentRelationshipsForPrincipalAsync(int principalId, QueryModels.AgentRelationshipQueryParams queryParams);
        Task<AgentRelationshipRM> GetAgentRelationshipForPrincipalAsync(int principalId, int agentRelationshipId);

        Task<UserRM> GetUserForAgentRelationshipAsync(int associateId, int agentRelationshipId, int userId);
        Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersForAgentRelationshipAsync(int associateId, int agentRelationshipId);

        Task<ContactRM> GetContactAsync(int associateId, int contactId);
        Task<PagedGridResult<IEnumerable<ContactRM>>> GetContactsAsync(QueryModels.ContactQueryParams queryParams);
        Task<PagedGridResult<IEnumerable<ContactRM>>> GetContactsAsync(int associateId);

        Task<ContactConfigurationRM> GetContactConfigurationForContactAsync(int associateId, int contactId, int contactConfigurationId);
        Task<PagedGridResult<IEnumerable<ContactConfigurationRM>>> GetContactConfigurationsAsync(QueryModels.ContactConfigurationQueryParams queryParams);
        Task<PagedGridResult<IEnumerable<ContactConfigurationRM>>> GetContactConfigurationsForContactAsync(int associateId, int contactId);
        
        Task<CustomerRM> GetCustomerAsync(int customerId);
        Task<PagedGridResult<IEnumerable<CustomerRM>>> GetCustomersAsync(QueryModels.CustomerQueryParams queryParams);
        Task<PagedGridResult<IEnumerable<CustomerRM>>> GetCustomersAsync(int associateId);

        Task<EMailRM> GetEMailAsync(int eMailId);
        Task<EMailRM> GetEMailForContactAsync(int associateId, int contactId, int eMailId);
        Task<PagedGridResult<IEnumerable<EMailRM>>> GetEMailsForContactAsync(int associateId, int contactId);
        Task<EMailRM> GetEMailForAssociateAsync(int associateId, int eMailId);
        Task<PagedGridResult<IEnumerable<EMailRM>>> GetEMailsForAssociateAsync(int associateId);
        Task<PagedGridResult<IEnumerable<EMailRM>>> GetEMailsAsync(QueryModels.EMailQueryParams queryParams);

        Task<OperatingContextRM> GetOperatingContextAsync(int operatingContextId);
        Task<PagedGridResult<IEnumerable<OperatingContextRM>>> GetOperatingContextsAsync(QueryModels.OperatingContextQueryParams queryParams);
        Task<PagedGridResult<IEnumerable<OperatingContextRM>>> GetOperatingContextsForAssociateAsync(int associateId);
        Task<PagedGridResult<IEnumerable<OperatingContextRM>>> GetOperatingContextsForCustomerAsync(int associateId, int customerId);

        Task<PhoneRM> GetPhoneAsync(int phoneId);
        Task<PhoneRM> GetPhoneForContactAsync(int associateId, int contactId, int phoneId);
        Task<PagedGridResult<IEnumerable<PhoneRM>>> GetPhonesForContactAsync(int associateId, int contactId);
        Task<PhoneRM> GetPhoneForAssociateAsync(int associateId, int phoneId);
        Task<PagedGridResult<IEnumerable<PhoneRM>>> GetPhonesForAssociateAsync(int associateId);
        Task<PagedGridResult<IEnumerable<PhoneRM>>> GetPhonesAsync(QueryModels.PhoneQueryParams queryParams);

        Task<RoleRM> GetRoleAsync(int roleId);
        Task<PagedGridResult<IEnumerable<RoleRM>>> GetRolesAsync(QueryModels.RoleQueryParams queryParams);
        Task<RoleRM> GetRoleForOperatingContextAsync(int associateId, int operatingContextId, int roleId);
        Task<PagedGridResult<IEnumerable<RoleRM>>> GetRolesForOperatingContextAsync(int associateId, int operatingContextId);

        Task<EGMSPermissionRM> GetEGMSPermissionAsync(int egmsPermissionId);
        Task<EGMSPermissionRM> GetEGMSPermissionForRoleAsync(int roleId, int egmsPermissionId);
        public Task<PagedGridResult<IEnumerable<EGMSPermissionRM>>> GetEGMSPermissionsAsync(QueryModels.EGMSPermissionQueryParams request);
        Task<PagedGridResult<IEnumerable<EGMSPermissionRM>>> GetEGMSPermissionsForRoleAsync(int roleId);

        Task<RoleEGMSPermissionRM> GetRoleEGMSPermissionAsync(int roleEGMSPermissionId);
        Task<PagedGridResult<IEnumerable<RoleEGMSPermissionRM>>> GetRoleEGMSPermissionsAsync(QueryModels.RoleEGMSPermissionQueryParams queryParams);

        Task<UserRM> GetUserAsync(int userId);
        Task<UserRM> GetUserForAssociateAsync(int associateId, int userId);
        Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersAsync(QueryModels.UserQueryParams queryParams);
        Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersForAssociateAsync(int associateId);

        Task<CertificationRM> GetCertificationForOperatingContextAsync(int associateId, int operatingContextId, int certificationId);
        Task<PagedGridResult<IEnumerable<CertificationRM>>> GetCertificationsAsync(QueryModels.CertificationQueryParams queryParams);


        //Task<IEnumerable<OptionItemRM>> GetFacilityTypesAsync(int? id);

        //Task<IEnumerable<OptionItemRM>> GetAssetTypesAsync(int? id);

        //Task<IEnumerable<OptionItemRM>> GetTimeZonesAsync(int? id);

        //Task<IEnumerable<OptionItemRM>> GetPoolTypesAsync(int? id);

        //Task<IEnumerable<StateProvinceRM>> GetStateProvincesAsync(int? id);

        //Task<IEnumerable<OptionItemRM>> GetTransferTypesAsync(int? id);
    }
}
