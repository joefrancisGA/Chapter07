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
        public Task<IActionResult> GetAddressAsync(int addressId) => RequestHandler.HandleQuery(() => _queryRepo.GetAddressAsync(addressId), _log);

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

        #region AddressForOperatingContext


        //[HttpGet]
        //[Route("operatingcontexts")]
        //public Task<IActionResult> GetOperatingContextsAsync([FromQuery]QueryModels.OperatingContextQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetOperatingContextsForAssociateAsync(request), _log);


        //[HttpGet]
        //[Route("{associateId}/customers/{customerId}/operatingcontexts")]
        //public Task<IActionResult> GetOperatingContextsForCustomerAsync(int associateId, int customerId, [FromQuery]QueryModels.OperatingContextQueryParams request)
        //{
        //    return RequestHandler.HandleQuery(() => _queryRepo.GetOperatingContextsForCustomerAsync(associateId, customerId), _log);
        //}

        //[HttpGet]
        //[Route("{associateId}/customers/{customerId}/operatingcontexts/{operatingContextId}")]
        //public Task<IActionResult> GetOperatingContextForCustomerAsync(int associateId, int customerId, int operatingContextId) => RequestHandler.HandleQuery(() => _queryRepo.GetOperatingContextAsync(operatingContextId), _log);


        private const string GetAddressForOperatingContextAPI = @"{associateId}/operatingcontexts/{operatingContextId}/Addresses/{addressId}";
        private const string GetAddressesForOperatingContextAPI = @"{associateId}/operatingcontexts/{operatingContextId}/Addresses";

        #endregion AddressForOperatingContext

        #region AddressForContact

        private const string GetAddressForContactAPI = @"{associateId}/contact/{contactId}/Addresses/{addressId}";
        private const string GetAddressesForContactAPI = @"{associateId}/contacts/{contactId}/Addresses";

        #endregion AddressForContact

        #region AgentRelationships

        private const string GetAgentRelationshipsForPrincipalAPI = @"{principalId}/agentrelationships";
        private const string GetAgentRelationshipForPrincipalAPI = @"{principalId}/agentrelationships/{agentRelationshipId}";

        #endregion AgentRelationships

        #region AgentRelationshipUser

        private const string GetUserForAgentRelationshipAPI = @"{associateId}/agentrelationships/{agentId}/Users";              // GET
        private const string GetUsersForAgentRelationshipAPI = @"{associateId}/agentrelationships/{agentId}/Users/{userId}";    // GET

        #endregion AgentRelationshipUser

        #region Certification

        private const string CreateCertificationForOperatingContextAPI = @"{associateId}/operatingcontexts/{operatingContextId}/Certification";
        private const string GetCertificationForOperatingContextAPI = @"{associateId}/operatingcontexts/{operatingContextId}/Certification/{certificationId}";

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
