using System.Threading.Tasks;
using EGMS.BusinessAssociates.API.Infrastructure;
using EGMS.BusinessAssociates.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace EGMS.BusinessAssociates.API.Controllers
{
    [Route("api/associate")]
    public class AssociateQueriesController : Controller
    {
        private readonly IAssociateQueryRepository _queryRepo;
        private readonly ILogger _log;

        public AssociateQueriesController(IAssociateQueryRepository queryRepo, ILogger<AssociateQueriesController> log)
        {
            _log = log;
            _queryRepo = queryRepo;
        }


        [HttpGet]
        public Task<IActionResult> GetAssociateAsync(QueryModels.AssociateQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetAssociatesAsync(request), _log);

        [HttpGet]
        [Route("{associateId}")]
        public Task<IActionResult> GetAssociateAsync(int associateId) => RequestHandler.HandleQuery(() => _queryRepo.GetAssociateAsync(associateId), _log);

        #region Addresses

        [HttpGet]
        [Route("addresses")]
        public Task<IActionResult> GetAddressesAsync([FromQuery]QueryModels.AddressQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetAddressesAsync(request), _log);

        [HttpGet]
        [Route("{associateId}/addresses")]
        public Task<IActionResult> GetAddressesAsync(int associateId, [FromQuery]QueryModels.AddressQueryParams request)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetAddressesForAssociateAsync(associateId), _log);
        }

        [HttpGet]
        [Route("{associateId}/addresses/{addressId}")]
        public Task<IActionResult> GetAddressForAssociateAsync(int addressId) => RequestHandler.HandleQuery(() => _queryRepo.GetAddressAsync(addressId), _log);

        #endregion

        #region Contacts For Associate

        [HttpGet]
        [Route("contacts")]
        public Task<IActionResult> GetContactsAsync([FromQuery]QueryModels.ContactQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetContactsAsync(request), _log);

        [HttpGet]
        [Route("{associateId}/contacts")]
        public Task<IActionResult> GetContactsForAssociateAsync(int associateId, [FromQuery]QueryModels.ContactQueryParams request)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetContactsAsync(associateId), _log);
        }

        [HttpGet]
        [Route("{associateId}/contacts/{contactId}")]
        public Task<IActionResult> GetContactForAssociateAsync(int associateId, int contactId) => RequestHandler.HandleQuery(() => _queryRepo.GetContactAsync(associateId, contactId), _log);

        #endregion Contacts For Associate

        #region UserForAssociate

        [HttpGet]
        [Route("users")]
        public Task<IActionResult> GetUsersAsync([FromQuery]QueryModels.UserQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetUsersAsync(request), _log);

        [HttpGet]
        [Route("{associateId}/users")]
        public Task<IActionResult> GetUsersForAssociateAsync(int associateId, [FromQuery]QueryModels.UserQueryParams request)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetUsersAsync(associateId), _log);
        }

        [HttpGet]
        [Route("{associateId}/users/{userId}")]
        public Task<IActionResult> GetUsersForAssociateAsync(int associateId, int userId) => RequestHandler.HandleQuery(() => _queryRepo.GetUserAsync(associateId, userId), _log);

        #endregion UserForAssociate

        #region CustomerForAssociate

        [HttpGet]
        [Route("customers")]
        public Task<IActionResult> GetCustomersAsync([FromQuery]QueryModels.CustomerQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetCustomersAsync(request), _log);

        [HttpGet]
        [Route("{associateId}/customers")]
        public Task<IActionResult> GetCustomersForAssociateAsync(int associateId, [FromQuery]QueryModels.CustomerQueryParams request)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetCustomersAsync(associateId), _log);
        }

        [HttpGet]
        [Route("{associateId}/customers/{customerId}")]
        public Task<IActionResult> GetCustomerForAssociateAsync(int associateId, int customerId) => RequestHandler.HandleQuery(() => _queryRepo.GetCustomerAsync(customerId), _log);

        #endregion CustomerForAssociate

        #region OperatingContextForAssociate

        [HttpGet]
        [Route("operatingcontexts")]
        public Task<IActionResult> GetOperatingContextsAsync([FromQuery]QueryModels.OperatingContextQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetOperatingContextsAsync(request), _log);

        [HttpGet]
        [Route("{associateId}/operatingcontexts")]
        public Task<IActionResult> GetOperatingContextsForAssociateAsync(int associateId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetOperatingContextsForAssociateAsync(associateId), _log);
        }

        [HttpGet]
        [Route("{associateId}/operatingcontexts/{operatingContextId}")]
        public Task<IActionResult> GetOperatingContextForAssociateAsync(int associateId, int operatingContextId) => RequestHandler.HandleQuery(() => _queryRepo.GetOperatingContextAsync(operatingContextId), _log);

        #endregion OperatingContextForAssociate

        #region OperatingContextForCustomer

        [HttpGet]
        [Route("{associateId}/customers/{customerId}/operatingcontexts")]
        public Task<IActionResult> GetOperatingContextsForCustomerAsync(int associateId, int customerId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetOperatingContextsForCustomerAsync(associateId, customerId), _log);
        }

        [HttpGet]
        [Route("{associateId}/customers/{customerId}/operatingcontexts/{operatingContextId}")]
        public Task<IActionResult> GetOperatingContextForCustomerAsync(int associateId, int customerId, int operatingContextId) => RequestHandler.HandleQuery(() => _queryRepo.GetOperatingContextAsync(operatingContextId), _log);

        #endregion OperatingContextForCustomer

        #region AddressForContact

        [HttpGet]
        [Route("{associateId}/contacts/{contactId}/Addresses")]
        public Task<IActionResult> GetAddressesForContactAsync(int associateId, int contactId) => RequestHandler.HandleQuery(() => _queryRepo.GetAddressesForContactAsync(associateId, contactId), _log);

        [HttpGet]
        [Route("{associateId}/contact/{contactId}/Addresses/{addressId}")]
        public Task<IActionResult> GetAddressForContactAsync(int associateId, int contactId, int addressId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetAddressForContactAsync(contactId, addressId), _log);
        }

        #endregion AddressForContact
        
        #region AgentRelationships

        [HttpGet]
        [Route("agentrelationships")]
        public Task<IActionResult> GetAgentRelationshipsAsync([FromQuery]QueryModels.AgentRelationshipQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetAgentRelationshipsAsync(request), _log);

        [HttpGet]
        [Route("{associateId}/agentrelationships")]
        public Task<IActionResult> GetAgentRelationshipsForPrincipalAsync(int principalId, [FromQuery]QueryModels.AgentRelationshipQueryParams request)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetAgentRelationshipsForPrincipalAsync(principalId, request), _log);
        }

        [HttpGet]
        [Route("{associateId}/agentrelationships/{agentRelationshipId}")]
        public Task<IActionResult> GetAgentRelationshipForPrincipalAsync(int principalId, int agentRelationshipId) => RequestHandler.HandleQuery(() => _queryRepo.GetAgentRelationshipForPrincipalAsync(principalId, agentRelationshipId), _log);

        #endregion AgentRelationships

        #region AgentRelationshipUser

        [HttpGet]
        [Route("{associateId}/agentrelationships/{agentRelationshipId}/Users")]
        public Task<IActionResult> GetUsersForAgentRelationshipAsync(int associateId, int agentRelationshipId) => RequestHandler.HandleQuery(() => _queryRepo.GetUsersForAgentRelationshipAsync(associateId, agentRelationshipId), _log);

        [HttpGet]
        [Route("{associateId}/agentrelationships/{agentRelationshipId}/Users/{UserId}")]
        public Task<IActionResult> GetUserForAgentRelationshipAsync(int associateId, int agentRelationshipId, int userId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetUserForAgentRelationshipAsync(associateId, agentRelationshipId, userId), _log);
        }

        #endregion AgentRelationshipUser

        #region Certification
        
        [HttpGet]
        [Route("certifications")]
        public Task<IActionResult> GetCertificationsAsync([FromQuery]QueryModels.CertificationQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetCertificationsAsync(request), _log);

        [HttpGet]
        [Route("{associateId}/operatingcontexts/{operatingContextId}/Certifications")]
        public Task<IActionResult> GetCertificationsForOperatingContextAsync(int associateId, int operatingContextId, [FromQuery]QueryModels.CertificationQueryParams request)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetCertificationsForOperatingContextAsync(associateId, operatingContextId, request), _log);
        }

        [HttpGet]
        [Route("{associateId}/operatingcontexts/{operatingContextId/Certification/{certificationId}")]
        public Task<IActionResult> GetCertificationForOperatingContextAsync(int associateId, int operatingContextId, int certificationId) => RequestHandler.HandleQuery(() => _queryRepo.GetCertificationForOperatingContextAsync(associateId, operatingContextId, certificationId), _log);

        #endregion Certification

        #region ContactConfiguration

        [HttpGet]
        [Route("contactconfigurations")]
        public Task<IActionResult> GetContactConfigurationsAsync([FromQuery]QueryModels.ContactConfigurationQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetContactConfigurationsAsync(request), _log);

        [HttpGet]
        [Route("{associateId}/contacts/{contactId}/ContactConfiguration/{contactConfigurationId}")]
        public Task<IActionResult> GetContactConfigurationForContactAsync(int associateId, int contactId, int configurationContactId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetContactConfigurationForContactAsync(associateId, contactId, configurationContactId), _log);
        }

        [HttpGet]
        [Route("{associateId}/contacts/{contactId/ContactConfigurations")]
        public Task<IActionResult> GetContactConfigurationsForContactAsync(int associateId, int contactId) => RequestHandler.HandleQuery(() => _queryRepo.GetContactConfigurationsForContactAsync(associateId, contactId), _log);

        #endregion ContactConfiguration

        #region EMail

        [HttpGet]
        [Route("emails")]
        public Task<IActionResult> GetEMailsAsync([FromQuery]QueryModels.EMailQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetEMailsAsync(request), _log);

        [HttpGet]
        [Route("{associateId}/contacts/{contactId}/Emails/{emailId}")]
        public Task<IActionResult> GetEMailForContactAsync(int associateId, int contactId, int eMailId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetEMailForContactAsync(associateId, contactId, eMailId), _log);
        }

        [HttpGet]
        [Route("{associateId}/contacts/{contactId}/Emails")]
        public Task<IActionResult> GetEMailsForContactAsync(int associateId, int contactId) => RequestHandler.HandleQuery(() => _queryRepo.GetEMailsForContactAsync(associateId, contactId), _log);


        [HttpGet]
        [Route("{associateId}/Emails/{emailId}")]
        public Task<IActionResult> GetEMailForAssociateAsync(int associateId, int eMailId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetEMailForAssociateAsync(associateId, eMailId), _log);
        }

        [HttpGet]
        [Route("{associateId}/Emails")]
        public Task<IActionResult> GetEMailsForAssociateAsync(int associateId) => RequestHandler.HandleQuery(() => _queryRepo.GetEMailsForAssociateAsync(associateId), _log);

        #endregion EMail

        #region Phone

        [HttpGet]
        [Route("phones")]
        public Task<IActionResult> GetPhonesAsync([FromQuery]QueryModels.PhoneQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetPhonesAsync(request), _log);

        [HttpGet]
        [Route("{associateId}/contacts/{contactId}/Phones/{phoneId}")]
        public Task<IActionResult> GetPhoneForContactAsync(int associateId, int contactId, int phoneId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetPhoneForContactAsync(associateId, contactId, phoneId), _log);
        }

        [HttpGet]
        [Route("{associateId}/contacts/{contactId}/Phones")]
        public Task<IActionResult> GetPhonesForContactAsync(int associateId, int contactId) => RequestHandler.HandleQuery(() => _queryRepo.GetPhonesForContactAsync(associateId, contactId), _log);


        [HttpGet]
        [Route("{associateId}/Phones/{phoneId}")]
        public Task<IActionResult> GetPhoneForAssociateAsync(int associateId, int phoneId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetPhoneForAssociateAsync(associateId, phoneId), _log);
        }

        [HttpGet]
        [Route("{associateId}/Phones")]
        public Task<IActionResult> GetPhonesForAssociateAsync(int associateId) => RequestHandler.HandleQuery(() => _queryRepo.GetPhonesForAssociateAsync(associateId), _log);

        #endregion Phone
            
        #region Role

        [HttpGet]
        [Route("roles")]
        public Task<IActionResult> GetRolesAsync([FromQuery]QueryModels.RoleQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetRolesAsync(request), _log);

        [HttpGet]
        [Route("{associateId}/operatingcontexts/{operatingContextId}/roles")]
        public Task<IActionResult> GetRolesForOperatingContextAsync(int associateId, int operatingContextId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetRolesForOperatingContextAsync(associateId, operatingContextId), _log);
        }

        [HttpGet]
        [Route("{associateId}/operatingcontexts/{operatingContextId}/roles/{roleId}")]
        public Task<IActionResult> GetRoleForOperatingContextAsync(int associateId, int operatingContextId, int roleId) => RequestHandler.HandleQuery(() => _queryRepo.GetRoleForOperatingContextAsync(associateId, operatingContextId, roleId), _log);

        #endregion Role

        #region EGMSPermission

        [HttpGet]
        [Route("EGMSPermissions")]
        public Task<IActionResult> GetEGMSPermissionsAsync([FromQuery]QueryModels.EGMSPermissionQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetEGMSPermissionsAsync(request), _log);

        [HttpGet]
        [Route("{associateId}/egmspermission/{egmspermissionid}")]
        public Task<IActionResult> GetEGMSPermissionForAssociateAsync(int associateId, int egmsPermissionId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetEGMSPermissionForAssociateAsync(associateId, egmsPermissionId), _log);
        }

        [HttpGet]
        [Route("{associateId}/egmspermissions")]
        public Task<IActionResult> GetEGMSPermissionsForAssociateAsync(int associateId) => RequestHandler.HandleQuery(() => _queryRepo.GetEGMSPermissionsForAssociateAsync(associateId), _log);

        #endregion EGMSPermission

        #region RoleEGMSPermission

        [HttpGet]
        [Route("RoleEGMSPermissions")]
        public Task<IActionResult> GetRoleEGMSPermissionsAsync([FromQuery]QueryModels.RoleEGMSPermissionQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetRoleEGMSPermissionsAsync(request), _log);

        [HttpGet]
        [Route("{associateId}/roleEGMSpermissions/{roleegmspermissionid}")]
        public Task<IActionResult> GetRoleEGMSPermissionForAssociateAsync(int associateId, int roleEGMSPermissionId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetRoleEGMSPermissionForAssociateAsync(associateId, roleEGMSPermissionId), _log);
        }

        [HttpGet]
        [Route("{associateId}/roleEGMSpermissions")]
        public Task<IActionResult> GetRoleEGMSPermissionsForAssociateAsync(int associateId) => RequestHandler.HandleQuery(() => _queryRepo.GetRoleEGMSPermissionsForAssociateAsync(associateId), _log);

        #endregion RoleEGMSPermission
    }
}
