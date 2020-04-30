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
            return RequestHandler.HandleQuery(() => _queryRepo.GetAddressesAsync(associateId), _log);
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
        public Task<IActionResult> GetOperatingContextsAsync([FromQuery]QueryModels.OperatingContextQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetOperatingContextsForAssociateAsync(request), _log);

        [HttpGet]
        [Route("{associateId}/operatingcontexts")]
        public Task<IActionResult> GetOperatingContextsForAssociateAsync(int associateId, [FromQuery]QueryModels.OperatingContextQueryParams request)
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
        public Task<IActionResult> GetOperatingContextsForCustomerAsync(int associateId, int customerId, [FromQuery]QueryModels.OperatingContextQueryParams request)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetOperatingContextsForCustomerAsync(associateId, customerId), _log);
        }

        [HttpGet]
        [Route("{associateId}/customers/{customerId}/operatingcontexts/{operatingContextId}")]
        public Task<IActionResult> GetOperatingContextForCustomerAsync(int associateId, int customerId, int operatingContextId) => RequestHandler.HandleQuery(() => _queryRepo.GetOperatingContextAsync(operatingContextId), _log);

        #endregion OperatingContextForCustomer

        #region AddressForContact

        [HttpGet]
        [Route("{associateId}/contact/{contactId}")]
        public Task<IActionResult> GetAddressForContactAsync(int associateId, int customerId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetAddressForContactAsync(associateId, customerId), _log);
        }

        [HttpGet]
        [Route("{associateId}/contact/{contactId}/Addresses/{addressId}")]
        public Task<IActionResult> GetAddressForContactAsync(int associateId, int customerId, int addressId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetAddressForContactAsync(customerId, addressId), _log);
        }

        [HttpGet]
        [Route("{associateId}/contacts/{contactId}/Addresses")]
        public Task<IActionResult> GetAddressesForContactAsync(int associateId, int contactId) => RequestHandler.HandleQuery(() => _queryRepo.GetAddressesForContactAsync(associateId, contactId), _log);

        #endregion AddressForContact


        #region AgentRelationships

        [HttpGet]
        [Route("agentrelationships")]
        public Task<IActionResult> GetAgentRelationshipsAsync([FromQuery]QueryModels.AgentRelationshipQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetAgentRelationshipsAsync(request), _log);

        [HttpGet]
        [Route("{principalId}/agentrelationships")]
        public Task<IActionResult> GetAgentRelationshipsForPrincipalAsync(int principalId, [FromQuery]QueryModels.AgentRelationshipQueryParams request)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetAgentRelationshipsForPrincipalAsync(request), _log);
        }

        [HttpGet]
        [Route("{principalId}/agentrelationships/{agentRelationshipId}")]
        public Task<IActionResult> GetAgentRelationshipForPrincipalAsync(int principalId, int agentRelationshipId) => RequestHandler.HandleQuery(() => _queryRepo.GetAgentRelationshipForPrincipalAsync(principalId, agentRelationshipId), _log);

        #endregion AgentRelationships

        #region AgentRelationshipUser

        [HttpGet]
        [Route("{associateId}/agentrelationships/{agentRelationshipId}/Users/{UserId}")]
        public Task<IActionResult> GetUserForAgentRelationshipAsync(int associateId, int agentRelationshipId, int userId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetUserForAgentRelationshipAsync(associateId, agentRelationshipId, userId), _log);
        }

        [HttpGet]
        [Route("{associateId}/agentrelationships/{agentRelationshipId}/Users")]
        public Task<IActionResult> GetUsersForAgentRelationshipAsync(int agentRelationshipId, [FromQuery]QueryModels.UserQueryParams request)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetUsersForAgentRelationshipAsync(request), _log);
        }

        [HttpGet]
        [Route("{associateId}/agentrelationships/{agentRelationshipId}")]
        public Task<IActionResult> GetUsersForAgentRelationshipAsync(int associateId, int agentRelationshipId) => RequestHandler.HandleQuery(() => _queryRepo.GetUsersForAgentRelationshipAsync(associateId, agentRelationshipId), _log);

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

        private const string GetContactConfigurationForContactAPI = @"{associateId}/contacts/{contactId}/ContactConfiguration/{contactConfigurationId}";
        private const string GetContactConfigurationsForContactAPI = @"{associateId}/contacts/{contactId}/ContactConfiguration";

        #endregion ContactConfiguration

        #region EMail

        private const string GetEMailForAssociateAPI = @"{associateId}/contacts/{contactId}/Emails/{emailId}";
        private const string GetEMailsForAssociateAPI = @"{associateId}/contacts/{contactId}/Emails";

        #endregion EMail

        #region Phone

        private const string GetPhoneForContactAPI = @"{associateId}/contacts/{contactId}/Phones/{phoneId}";
        private const string GetPhonesForContactAPI = @"{associateId}/contacts/{contactId}/Phones";

        #endregion Phone

        #region CustomerForOperatingContext

        private const string GetCustomerForOperatingContextAPI = @"{associateId}/OperatingContexts/{operatingContextId}/Customers/{customerId}";
        private const string GetCustomersForOperatingContextAPI = @"{associateId}/OperatingContexts/{operatingContextId}/Customers";

        #endregion CustomerForOperatingContext

        #region Role

        private const string GetRoleAPI = @"{associateId}/roles/{roleId}";
        private const string GetRolesAPI = @"{associateId}/roles";

        #endregion Role

        #region EGMSPermission

        private const string GetEGMSPermissionAPI = @"{associateId}/egmspermission/{egmspermissionid}";
        private const string GetEGMSPermissionsAPI = @"{associateId}/egmspermissions";

        #endregion EGMSPermission

        #region RoleEGMSPermission

        private const string GetRoleEGMSPermissionAPI = @"{associateId}/roleegmspermissions/{roleegmspermissionid}";
        private const string GetRoleEGMSPermissionsAPI = @"{associateId}/roleegmspermissions";

        #endregion RoleEGMSPermission
    }
}
