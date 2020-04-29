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
        Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddressesAsync(int associateId);

        Task<AgentRelationshipRM> GetAgentRelationshipAsync(int agentRelationshipId);
        Task<PagedGridResult<IEnumerable<AgentRelationshipRM>>> GetAgentRelationshipsAsync(QueryModels.AgentRelationshipQueryParams queryParams);

        Task<ContactRM> GetContactAsync(int associateId, int contactId);
        Task<PagedGridResult<IEnumerable<ContactRM>>> GetContactsAsync(QueryModels.ContactQueryParams queryParams);
        Task<PagedGridResult<IEnumerable<ContactRM>>> GetContactsAsync(int associateId);

        Task<ContactConfigurationRM> GetContactConfigurationAsync(int contactConfigurationId);
        Task<PagedGridResult<IEnumerable<ContactConfigurationRM>>> GetContactConfigurationsAsync(QueryModels.ContactConfigurationQueryParams queryParams);
        
        Task<CustomerRM> GetCustomerAsync(int customerId);
        Task<PagedGridResult<IEnumerable<CustomerRM>>> GetCustomersAsync(QueryModels.CustomerQueryParams queryParams);
        Task<PagedGridResult<IEnumerable<CustomerRM>>> GetCustomersAsync(int associateId);

        Task<EMailRM> GetEMailAsync(int eMailId);
        Task<PagedGridResult<IEnumerable<EMailRM>>> GetEMailsAsync(QueryModels.EMailQueryParams queryParams);

        Task<OperatingContextRM> GetOperatingContextAsync(int operatingContextId);
        Task<PagedGridResult<IEnumerable<OperatingContextRM>>> GetOperatingContextsForAssociateAsync(QueryModels.OperatingContextQueryParams queryParams);
        Task<PagedGridResult<IEnumerable<OperatingContextRM>>> GetOperatingContextsForAssociateAsync(int associateId);
        Task<PagedGridResult<IEnumerable<OperatingContextRM>>> GetOperatingContextsForCustomerAsync(QueryModels.OperatingContextQueryParams queryParams);
        Task<PagedGridResult<IEnumerable<OperatingContextRM>>> GetOperatingContextsForCustomerAsync(int associateId, int customerId);

        Task<PhoneRM> GetPhoneAsync(int phoneId);
        Task<PagedGridResult<IEnumerable<PhoneRM>>> GetPhonesAsync(QueryModels.PhoneQueryParams queryParams);

        Task<RoleRM> GetRoleAsync(int roleId);
        Task<PagedGridResult<IEnumerable<RoleRM>>> GetRolesAsync(QueryModels.RoleQueryParams queryParams);

        Task<EGMSPermissionRM> GetEGMSPermissionAsync(int egmsPermissionId);
        Task<PagedGridResult<IEnumerable<EGMSPermissionRM>>> GetEGMSPermissionsAsync(QueryModels.EGMSPermissionQueryParams queryParams);

        Task<RoleEGMSPermissionRM> GetRoleEGMSPermission(int roleEGMSPermissionId);
        Task<PagedGridResult<IEnumerable<RoleEGMSPermissionRM>>> GetRoleEGMSPermissionsAsync(QueryModels.RoleEGMSPermissionQueryParams queryParams);

        Task<UserRM> GetUserAsync(int associateId, int userId);
        Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersAsync(QueryModels.UserQueryParams queryParams);
        Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersAsync(int associateId);


        
        //Task<IEnumerable<OptionItemRM>> GetFacilityTypesAsync(int? id);

        //Task<IEnumerable<OptionItemRM>> GetAssetTypesAsync(int? id);

        //Task<IEnumerable<OptionItemRM>> GetTimeZonesAsync(int? id);

        //Task<IEnumerable<OptionItemRM>> GetPoolTypesAsync(int? id);

        //Task<IEnumerable<StateProvinceRM>> GetStateProvincesAsync(int? id);

        //Task<IEnumerable<OptionItemRM>> GetTransferTypesAsync(int? id);
    }
}
