using System.Collections.Generic;
using System.Threading.Tasks;
using EGMS.BusinessAssociates.Query.ReadModels;


namespace EGMS.BusinessAssociates.Query
{
    public interface IAssociateQueryRepository
    {
        Task<AssociateRM> GetAssociate(int associateId);
        Task<PagedGridResult<IEnumerable<AssociateRM>>> GetAssociates(QueryModels.AssociateQueryParams queryParams);

        Task<AddressRM> GetAddress(int addressId);
        Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddresses(QueryModels.AddressQueryParams queryParams);
        Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddressesForAssociate(int associateId);

        Task<AddressRM> GetAddressForContact(int contactId, int addressId);
        Task<PagedGridResult<IEnumerable<AddressRM>>> GetAddressesForContact(int associateId, int contactId);

        Task<PagedGridResult<IEnumerable<AgentRelationshipRM>>> GetAgentRelationships(QueryModels.AgentRelationshipQueryParams queryParams);
        Task<AgentRelationshipRM> GetAgentRelationshipForPrincipal(int principalId, int agentRelationshipId);

        Task<UserRM> GetUserForAgentRelationship(int associateId, int agentRelationshipId, int userId);
        Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersForAgentRelationship(int associateId, int agentRelationshipId);

        Task<ContactRM> GetContact(int associateId, int contactId);
        Task<PagedGridResult<IEnumerable<ContactRM>>> GetContacts(QueryModels.ContactQueryParams queryParams);
        Task<PagedGridResult<IEnumerable<ContactRM>>> GetContacts(int associateId);

        Task<ContactConfigurationRM> GetContactConfigurationForContact(int associateId, int contactId, int contactConfigurationId);
        Task<PagedGridResult<IEnumerable<ContactConfigurationRM>>> GetContactConfigurations(QueryModels.ContactConfigurationQueryParams queryParams);
        Task<PagedGridResult<IEnumerable<ContactConfigurationRM>>> GetContactConfigurationsForContact(int associateId, int contactId);
        
        Task<CustomerRM> GetCustomer(int customerId);
        Task<PagedGridResult<IEnumerable<CustomerRM>>> GetCustomers(QueryModels.CustomerQueryParams queryParams);
        Task<PagedGridResult<IEnumerable<CustomerRM>>> GetCustomers(int associateId);

        Task<EMailRM> GetEMail(int eMailId);
        Task<EMailRM> GetEMailForContact(int associateId, int contactId, int eMailId);
        Task<PagedGridResult<IEnumerable<EMailRM>>> GetEMailsForContact(int associateId, int contactId);
        Task<EMailRM> GetEMailForAssociate(int associateId, int eMailId);
        Task<PagedGridResult<IEnumerable<EMailRM>>> GetEMailsForAssociate(int associateId);
        Task<PagedGridResult<IEnumerable<EMailRM>>> GetEMails(QueryModels.EMailQueryParams queryParams);

        Task<OperatingContextRM> GetOperatingContext(int operatingContextId);
        Task<OperatingContextRM> GetOperatingContextForCustomer(int associateId, int customerId, int operatingContextId);
        Task<PagedGridResult<IEnumerable<OperatingContextRM>>> GetOperatingContexts(QueryModels.OperatingContextQueryParams queryParams);
        Task<PagedGridResult<IEnumerable<OperatingContextRM>>> GetOperatingContextsForAssociate(int associateId);
        Task<PagedGridResult<IEnumerable<OperatingContextRM>>> GetOperatingContextsForCustomer(int associateId, int customerId);

        Task<PhoneRM> GetPhone(int phoneId);
        Task<PhoneRM> GetPhoneForContact(int associateId, int contactId, int phoneId);
        Task<PagedGridResult<IEnumerable<PhoneRM>>> GetPhonesForContact(int associateId, int contactId);
        Task<PhoneRM> GetPhoneForAssociate(int associateId, int phoneId);
        Task<PagedGridResult<IEnumerable<PhoneRM>>> GetPhonesForAssociate(int associateId);
        Task<PagedGridResult<IEnumerable<PhoneRM>>> GetPhones(QueryModels.PhoneQueryParams queryParams);

        Task<RoleRM> GetRole(int roleId);
        Task<PagedGridResult<IEnumerable<RoleRM>>> GetRoles(QueryModels.RoleQueryParams queryParams);
        Task<RoleRM> GetRoleForOperatingContext(int associateId, int operatingContextId, int roleId);
        Task<PagedGridResult<IEnumerable<RoleRM>>> GetRolesForOperatingContext(int associateId, int operatingContextId);

        Task<EGMSPermissionRM> GetEGMSPermission(int egmsPermissionId);
        Task<EGMSPermissionRM> GetEGMSPermissionForRole(int roleId, int egmsPermissionId);
        public Task<PagedGridResult<IEnumerable<EGMSPermissionRM>>> GetEGMSPermissions(QueryModels.EGMSPermissionQueryParams request);
        Task<PagedGridResult<IEnumerable<EGMSPermissionRM>>> GetEGMSPermissionsForRole(int roleId);

        Task<RoleEGMSPermissionRM> GetRoleEGMSPermission(int roleEGMSPermissionId);
        Task<PagedGridResult<IEnumerable<RoleEGMSPermissionRM>>> GetRoleEGMSPermissions(QueryModels.RoleEGMSPermissionQueryParams queryParams);

        Task<UserRM> GetUser(int userId);
        Task<UserRM> GetUserForAssociate(int associateId, int userId);
        Task<PagedGridResult<IEnumerable<UserRM>>> GetUsers(QueryModels.UserQueryParams queryParams);
        Task<PagedGridResult<IEnumerable<UserRM>>> GetUsersForAssociate(int associateId);

        Task<CertificationRM> GetCertificationForOperatingContext(int associateId, int operatingContextId, int certificationId);
        Task<PagedGridResult<IEnumerable<CertificationRM>>> GetCertifications(QueryModels.CertificationQueryParams queryParams);


        //Task<IEnumerable<OptionItemRM>> GetFacilityTypes(int? id);

        //Task<IEnumerable<OptionItemRM>> GetAssetTypes(int? id);

        //Task<IEnumerable<OptionItemRM>> GetTimeZones(int? id);

        //Task<IEnumerable<OptionItemRM>> GetPoolTypes(int? id);

        //Task<IEnumerable<StateProvinceRM>> GetStateProvinces(int? id);

        //Task<IEnumerable<OptionItemRM>> GetTransferTypes(int? id);
    }
}
