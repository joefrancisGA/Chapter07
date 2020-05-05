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
        public Task<IActionResult> GetAssociate(QueryModels.AssociateQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetAssociates(request), _log);

        [HttpGet]
        [Route("{associateId}")]
        public Task<IActionResult> GetAssociate(int associateId) => RequestHandler.HandleQuery(() => _queryRepo.GetAssociate(associateId), _log);

        #region Addresses

        [HttpGet]
        [Route("addresses")]
        public Task<IActionResult> GetAddresses([FromQuery]QueryModels.AddressQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetAddresses(request), _log);

        [HttpGet]
        [Route("{associateId}/addresses")]
        public Task<IActionResult> GetAddresses(int associateId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetAddressesForAssociate(associateId), _log);
        }

        [HttpGet]
        [Route("{associateId}/addresses/{addressId}")]
        public Task<IActionResult> GetAddressForAssociate(int addressId) => RequestHandler.HandleQuery(() => _queryRepo.GetAddress(addressId), _log);

        #endregion

        #region Contacts For Associate

        [HttpGet]
        [Route("contacts")]
        public Task<IActionResult> GetContacts([FromQuery]QueryModels.ContactQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetContacts(request), _log);

        [HttpGet]
        [Route("{associateId}/contacts")]
        public Task<IActionResult> GetContactsForAssociate(int associateId, [FromQuery]QueryModels.ContactQueryParams request)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetContacts(associateId), _log);
        }

        [HttpGet]
        [Route("{associateId}/contacts/{contactId}")]
        public Task<IActionResult> GetContactForAssociate(int associateId, int contactId) => RequestHandler.HandleQuery(() => _queryRepo.GetContact(associateId, contactId), _log);

        #endregion Contacts For Associate

        #region UserForAssociate

        [HttpGet]
        [Route("users")]
        public Task<IActionResult> GetUsers([FromQuery]QueryModels.UserQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetUsers(request), _log);

        [HttpGet]
        [Route("{associateId}/users")]
        public Task<IActionResult> GetUsersForAssociate(int associateId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetUsersForAssociate(associateId), _log);
        }

        [HttpGet]
        [Route("{associateId}/users/{userId}")]
        public Task<IActionResult> GetUsersForAssociate(int associateId, int userId) => RequestHandler.HandleQuery(() => _queryRepo.GetUserForAssociate(associateId, userId), _log);

        #endregion UserForAssociate

        #region CustomerForAssociate

        [HttpGet]
        [Route("customers")]
        public Task<IActionResult> GetCustomers([FromQuery]QueryModels.CustomerQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetCustomers(request), _log);

        [HttpGet]
        [Route("{associateId}/customers")]
        public Task<IActionResult> GetCustomersForAssociate(int associateId, [FromQuery]QueryModels.CustomerQueryParams request)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetCustomers(associateId), _log);
        }

        [HttpGet]
        [Route("{associateId}/customers/{customerId}")]
        public Task<IActionResult> GetCustomerForAssociate(int associateId, int customerId) => RequestHandler.HandleQuery(() => _queryRepo.GetCustomer(customerId), _log);

        #endregion CustomerForAssociate

        #region OperatingContextForAssociate

        [HttpGet]
        [Route("operatingcontexts")]
        public Task<IActionResult> GetOperatingContexts([FromQuery]QueryModels.OperatingContextQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetOperatingContexts(request), _log);

        [HttpGet]
        [Route("{associateId}/operatingcontexts")]
        public Task<IActionResult> GetOperatingContextsForAssociate(int associateId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetOperatingContextsForAssociate(associateId), _log);
        }

        [HttpGet]
        [Route("{associateId}/operatingcontexts/{operatingContextId}")]
        public Task<IActionResult> GetOperatingContextForAssociate(int associateId, int operatingContextId) => RequestHandler.HandleQuery(() => _queryRepo.GetOperatingContext(operatingContextId), _log);

        #endregion OperatingContextForAssociate

        #region OperatingContextForCustomer

        [HttpGet]
        [Route("{associateId}/customers/{customerId}/operatingcontexts")]
        public Task<IActionResult> GetOperatingContextsForCustomer(int associateId, int customerId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetOperatingContextsForCustomer(associateId, customerId), _log);
        }

        [HttpGet]
        [Route("{associateId}/customers/{customerId}/operatingcontexts/{operatingContextId}")]
        public Task<IActionResult> GetOperatingContextForCustomer(int associateId, int customerId, int operatingContextId) => RequestHandler.HandleQuery(() => _queryRepo.GetOperatingContextForCustomer(associateId, customerId, operatingContextId), _log);

        #endregion OperatingContextForCustomer

        #region AddressForContact

        [HttpGet]
        [Route("{associateId}/contacts/{contactId}/Addresses")]
        public Task<IActionResult> GetAddressesForContact(int associateId, int contactId) => RequestHandler.HandleQuery(() => _queryRepo.GetAddressesForContact(associateId, contactId), _log);

        [HttpGet]
        [Route("{associateId}/contact/{contactId}/Addresses/{addressId}")]
        public Task<IActionResult> GetAddressForContact(int associateId, int contactId, int addressId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetAddressForContact(contactId, addressId), _log);
        }

        #endregion AddressForContact
        
        #region AgentRelationships

        [HttpGet]
        [Route("agentrelationships")]
        public Task<IActionResult> GetAgentRelationships([FromQuery]QueryModels.AgentRelationshipQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetAgentRelationships(request), _log);

        [HttpGet]
        [Route("{associateId}/agentrelationships/{agentRelationshipId}")]
        public Task<IActionResult> GetAgentRelationshipForPrincipal(int principalId, int agentRelationshipId) => RequestHandler.HandleQuery(() => _queryRepo.GetAgentRelationshipForPrincipal(principalId, agentRelationshipId), _log);

        #endregion AgentRelationships

        #region AgentRelationshipUser

        [HttpGet]
        [Route("{associateId}/agentrelationships/{agentRelationshipId}/Users")]
        public Task<IActionResult> GetUsersForAgentRelationship(int associateId, int agentRelationshipId) => RequestHandler.HandleQuery(() => _queryRepo.GetUsersForAgentRelationship(associateId, agentRelationshipId), _log);

        [HttpGet]
        [Route("{associateId}/agentrelationships/{agentRelationshipId}/Users/{UserId}")]
        public Task<IActionResult> GetUserForAgentRelationship(int associateId, int agentRelationshipId, int userId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetUserForAgentRelationship(associateId, agentRelationshipId, userId), _log);
        }

        #endregion AgentRelationshipUser

        #region Certification
        
        [HttpGet]
        [Route("certifications")]
        public Task<IActionResult> GetCertifications([FromQuery]QueryModels.CertificationQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetCertifications(request), _log);

        [HttpGet]
        [Route("{associateId}/operatingcontexts/{operatingContextId/Certification/{certificationId}")]
        public Task<IActionResult> GetCertificationForOperatingContext(int associateId, int operatingContextId, int certificationId) => RequestHandler.HandleQuery(() => _queryRepo.GetCertificationForOperatingContext(associateId, operatingContextId, certificationId), _log);

        #endregion Certification

        #region ContactConfiguration

        [HttpGet]
        [Route("contactconfigurations")]
        public Task<IActionResult> GetContactConfigurations([FromQuery]QueryModels.ContactConfigurationQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetContactConfigurations(request), _log);

        [HttpGet]
        [Route("{associateId}/contacts/{contactId/ContactConfigurations")]
        public Task<IActionResult> GetContactConfigurationsForContact(int associateId, int contactId) => RequestHandler.HandleQuery(() => _queryRepo.GetContactConfigurationsForContact(associateId, contactId), _log);

        [HttpGet]
        [Route("{associateId}/contacts/{contactId}/ContactConfigurations/{contactConfigurationId}")]
        public Task<IActionResult> GetContactConfigurationForContact(int associateId, int contactId, int configurationContactId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetContactConfigurationForContact(associateId, contactId, configurationContactId), _log);
        }

        #endregion ContactConfiguration

        #region EMail

        [HttpGet]
        [Route("emails")]
        public Task<IActionResult> GetEMails([FromQuery]QueryModels.EMailQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetEMails(request), _log);

        [HttpGet]
        [Route("{associateId}/Emails/{emailId}")]
        public Task<IActionResult> GetEMail(int eMailId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetEMail(eMailId), _log);
        }

        [HttpGet]
        [Route("{associateId}/contacts/{contactId}/Emails/{emailId}")]
        public Task<IActionResult> GetEMailForContact(int associateId, int contactId, int eMailId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetEMailForContact(associateId, contactId, eMailId), _log);
        }

        [HttpGet]
        [Route("{associateId}/contacts/{contactId}/Emails")]
        public Task<IActionResult> GetEMailsForContact(int associateId, int contactId) => RequestHandler.HandleQuery(() => _queryRepo.GetEMailsForContact(associateId, contactId), _log);


        [HttpGet]
        [Route("{associateId}/Emails/{emailId}")]
        public Task<IActionResult> GetEMailForAssociate(int associateId, int eMailId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetEMailForAssociate(associateId, eMailId), _log);
        }

        [HttpGet]
        [Route("{associateId}/Emails")]
        public Task<IActionResult> GetEMailsForAssociate(int associateId) => RequestHandler.HandleQuery(() => _queryRepo.GetEMailsForAssociate(associateId), _log);

        #endregion EMail

        #region Phone

        [HttpGet]
        [Route("phones")]
        public Task<IActionResult> GetPhones([FromQuery]QueryModels.PhoneQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetPhones(request), _log);

        [HttpGet]
        [Route("{associateId}/contacts/{contactId}/Phones/{phoneId}")]
        public Task<IActionResult> GetPhoneForContact(int associateId, int contactId, int phoneId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetPhoneForContact(associateId, contactId, phoneId), _log);
        }

        [HttpGet]
        [Route("{associateId}/contacts/{contactId}/Phones")]
        public Task<IActionResult> GetPhonesForContact(int associateId, int contactId) => RequestHandler.HandleQuery(() => _queryRepo.GetPhonesForContact(associateId, contactId), _log);


        [HttpGet]
        [Route("{associateId}/Phones/{phoneId}")]
        public Task<IActionResult> GetPhoneForAssociate(int associateId, int phoneId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetPhoneForAssociate(associateId, phoneId), _log);
        }

        [HttpGet]
        [Route("{associateId}/Phones")]
        public Task<IActionResult> GetPhonesForAssociate(int associateId) => RequestHandler.HandleQuery(() => _queryRepo.GetPhonesForAssociate(associateId), _log);

        #endregion Phone
            
        #region Role

        [HttpGet]
        [Route("roles")]
        public Task<IActionResult> GetRoles([FromQuery]QueryModels.RoleQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetRoles(request), _log);

        [HttpGet]
        [Route("{associateId}/operatingcontexts/{operatingContextId}/roles")]
        public Task<IActionResult> GetRolesForOperatingContext(int associateId, int operatingContextId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetRolesForOperatingContext(associateId, operatingContextId), _log);
        }

        [HttpGet]
        [Route("{associateId}/operatingcontexts/{operatingContextId}/roles/{roleId}")]
        public Task<IActionResult> GetRoleForOperatingContext(int associateId, int operatingContextId, int roleId) => RequestHandler.HandleQuery(() => _queryRepo.GetRoleForOperatingContext(associateId, operatingContextId, roleId), _log);

        #endregion Role

        #region EGMSPermission

        [HttpGet]
        [Route("EGMSPermissions")]
        public Task<IActionResult> GetEGMSPermissions([FromQuery]QueryModels.EGMSPermissionQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetEGMSPermissions(request), _log);

        [HttpGet]
        [Route("roles/{roleId}/egmspermissions")]
        public Task<IActionResult> GetEGMSPermissionsForRole(int associateId) => RequestHandler.HandleQuery(() => _queryRepo.GetEGMSPermissionsForRole(associateId), _log);


        [HttpGet]
        [Route("roles/{roleId}/egmspermissions/{egmspermissionid}")]
        public Task<IActionResult> GetEGMSPermissionForRole(int associateId, int egmsPermissionId)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetEGMSPermissionForRole(associateId, egmsPermissionId), _log);
        }
        
        #endregion EGMSPermission

        #region RoleEGMSPermission

        [HttpGet]
        [Route("RoleEGMSPermissions")]
        public Task<IActionResult> GetRoleEGMSPermissions([FromQuery]QueryModels.RoleEGMSPermissionQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetRoleEGMSPermissions(request), _log);

        #endregion RoleEGMSPermission
    }
}
