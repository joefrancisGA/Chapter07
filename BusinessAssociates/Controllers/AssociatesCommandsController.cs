using System.Threading.Tasks;
using EGMS.BusinessAssociates.API.Infrastructure;
using EGMS.BusinessAssociates.Command;
using EGMS.BusinessAssociates.Query.ReadModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace EGMS.BusinessAssociates.API.Controllers
{
    [Route("api/associate")]
    public class AssociatesCommandsController : Controller
    {
        private readonly AssociatesApplicationService _appService;
        private readonly ILogger<AssociatesCommandsController> _log;

        public AssociatesCommandsController(AssociatesApplicationService appService, ILogger<AssociatesCommandsController> log)
        {
            _appService = appService;
            _log = log;
        }

        // TO DO:  Consider method-based routing to allow for better Swagger support with FromBody
        [HttpPost]
        public async Task<IActionResult> PostAssociate([FromBody]Commands.V1.Associate.Create request)
        {
            object x = await _appService.Handle(request);

            AssociateRM associateRM = (AssociateRM) x;

            return CreatedAtAction("PostAssociate", associateRM);
        }

        [Route("longname")]
        [HttpPut]
        public async Task<IActionResult> Put(Commands.V1.Associate.UpdateLongName request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        [Route("dunsnumber")]
        [HttpPut]
        public async Task<IActionResult> Put(Commands.V1.Associate.UpdateDUNSNumber request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        [Route("internalassociatetype")]
        [HttpPut]
        public async Task<IActionResult> Put(Commands.V1.Associate.UpdateAssociateType request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        [Route("shortname")]
        [HttpPut]
        public async Task<IActionResult> Put(Commands.V1.Associate.UpdateShortName request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        [Route("status")]
        [HttpPut]
        public async Task<IActionResult> Put(Commands.V1.Associate.UpdateStatus request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        [Route("isparent")]
        [HttpPut]
        public async Task<IActionResult> Put(Commands.V1.Associate.UpdateIsParent request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        [Route("{associateId}/operatingcontexts")]
        [HttpPost]
        public async Task<IActionResult> PostOperatingContextForAssociate(int associateId, Commands.V1.OperatingContext.Create request)
        {
            // Translating one command into another allows us to only get the Associate Id once
            Commands.V1.OperatingContext.CreateForAssociate cmd = 
                new Commands.V1.OperatingContext.CreateForAssociate(associateId, request);

            IActionResult result = await RequestHandler.HandleCommand(cmd, _appService.Handle, _log);

            return CreatedAtAction("PostOperatingContextForAssociate", result);
        }


        [Route("{associateId}/operatingcontexts/{operatingContextId}/Addresses")]
        [HttpPost]
        public async Task<IActionResult> PostAddressForOperatingContext(int associateId, int operatingContextId, Commands.V1.OperatingContext.Address.Create request)
        {
            // Translating one command into another allows us to only get the Associate Id once
            Commands.V1.OperatingContext.Address.CreateForOperatingContext cmd =
                new Commands.V1.OperatingContext.Address.CreateForOperatingContext(operatingContextId, request);

            IActionResult result = await RequestHandler.HandleCommand(cmd, _appService.Handle, _log);

            return CreatedAtAction("PostAddressForOperatingContext", result);
        }

        [Route("{associateId}/contacts")]
        [HttpPost]
        public async Task<IActionResult> PostContactForAssociate(int associateId, Commands.V1.Contact.Create request)
        {
            // Translating one command into another allows us to only get the Associate Id once
            Commands.V1.Contact.CreateForAssociate cmd =
                new Commands.V1.Contact.CreateForAssociate(associateId, request);

            object x = await _appService.Handle(cmd);

            ContactRM contactRM = (ContactRM)x;

            return CreatedAtAction("PostContactForAssociate", contactRM);
        }


        [Route("{associateId}/contacts/{contactId}/Addresses")]
        [HttpPost]
        public async Task<IActionResult> PostAddressForContact(int associateId, int contactId, Commands.V1.Contact.Address.Create request)
        {
            // Translating one command into another allows us to only get the Associate Id once
            Commands.V1.Contact.Address.CreateForContact cmd =
                new Commands.V1.Contact.Address.CreateForContact(contactId, request);

            IActionResult result = await RequestHandler.HandleCommand(cmd, _appService.Handle, _log);

            return CreatedAtAction("PostAddressForContact", result);
        }

        [Route("{principalId}/agentrelationships")]
        [HttpPost]
        public async Task<IActionResult> PostAgentRelationshipForPrincipal(int principalId, Commands.V1.AgentRelationship.Create request)
        {
            // Translating one command into another allows us to only get the Associate Id once
            Commands.V1.AgentRelationship.CreateForPrincipal cmd =
                new Commands.V1.AgentRelationship.CreateForPrincipal(principalId, request);

            IActionResult result = await RequestHandler.HandleCommand(cmd, _appService.Handle, _log);

            return CreatedAtAction("PostAgentRelationshipForPrincipal", result);
        }

        [Route("{associateId}/users")]
        [HttpPost]
        public async Task<IActionResult> PostUserForAssociate(int associateId, Commands.V1.User.Create request)
        {
            // Translating one command into another allows us to only get the Associate Id once
            Commands.V1.User.CreateForAssociate cmd =
                new Commands.V1.User.CreateForAssociate(associateId, request);

            IActionResult result = await RequestHandler.HandleCommand(cmd, _appService.Handle, _log);

            return CreatedAtAction("PostUserForAssociate", result);
        }

        [Route("{associateId}/agentrelationships/{agentId}/Users")]
        [HttpPost]
        public async Task<IActionResult> PostUserForAgent(int associateId, int agentId, Commands.V1.AgentRelationship.User.Create request)
        {
            Commands.V1.AgentRelationship.User.CreateForAgent cmd =
                new Commands.V1.AgentRelationship.User.CreateForAgent(agentId, request);

            IActionResult result = await RequestHandler.HandleCommand(cmd, _appService.Handle, _log);

            return CreatedAtAction("PostUserForAgent", result);
        }

        [Route("{associateId}/customers")]
        [HttpPost]
        public async Task<IActionResult> PostCustomerForAssociate(int associateId, Commands.V1.Customer.Create request)
        {
            // Translating one command into another allows us to only get the Associate Id once
            Commands.V1.Customer.CreateForAssociate cmd =
                new Commands.V1.Customer.CreateForAssociate(associateId, request);

            IActionResult result = await RequestHandler.HandleCommand(cmd, _appService.Handle, _log);

            return CreatedAtAction("PostCustomerForAssociate", result);
        }

        [Route("{associateId}/operatingcontexts/{operatingContextId}/Certification")]
        [HttpPost]
        public async Task<IActionResult> PostCertificationForOperatingContext(int associateId, int operatingContextId, Commands.V1.OperatingContext.Certification.Create request)
        {
            // Translating one command into another allows us to only get the Associate Id once
            Commands.V1.OperatingContext.Certification.CreateForOperatingContext cmd =
                new Commands.V1.OperatingContext.Certification.CreateForOperatingContext(operatingContextId, request);

            IActionResult result = await RequestHandler.HandleCommand(cmd, _appService.Handle, _log);

            return CreatedAtAction("PostCertificationForOperatingContext", result);
        }

        [Route("{associateId}/contacts/{contactId}/Configuration")]
        [HttpPost]
        public async Task<IActionResult> PostContactConfigurationForContact(int associateId, int contactId, Commands.V1.Contact.ContactConfiguration.Create request)
        {
            // Translating one command into another allows us to only get the Associate Id once
            Commands.V1.Contact.ContactConfiguration.CreateForContact cmd =
                new Commands.V1.Contact.ContactConfiguration.CreateForContact(contactId, request);

            IActionResult result = await RequestHandler.HandleCommand(cmd, _appService.Handle, _log);

            return CreatedAtAction("PostContactConfigurationForContact", result);
        }

        [Route("{associateId}/contacts/{contactId}/Emails")]
        [HttpPost]
        public async Task<IActionResult> PostEMailForContact(int associateId, int contactId, Commands.V1.Contact.EMail.Create request)
        {
            // Translating one command into another allows us to only get the Associate Id once
            Commands.V1.Contact.EMail.CreateForContact cmd =
                new Commands.V1.Contact.EMail.CreateForContact(contactId, request);

            IActionResult result = await RequestHandler.HandleCommand(cmd, _appService.Handle, _log);

            return CreatedAtAction("PostEMailForContact", result);
        }

        [Route("{associateId}/contacts/{contactId}/Phones")]
        [HttpPost]
        public async Task<IActionResult> PostPhoneForContact(int associateId, int contactId, Commands.V1.Contact.Phone.Create request)
        {
            // Translating one command into another allows us to only get the Associate Id once
            Commands.V1.Contact.Phone.CreateForContact cmd =
                new Commands.V1.Contact.Phone.CreateForContact(contactId, request);

            IActionResult result = await RequestHandler.HandleCommand(cmd, _appService.Handle, _log);

            return CreatedAtAction("PostPhoneForContact", result);
        }

        [Route("{associateId}/customers/{CustomerId}/AlternateFuels")]
        [HttpPost]
        public async Task<IActionResult> PostAlternateFuelForCustomer(int associateId, int customerId, Commands.V1.Customer.AlternateFuel.Create request)
        {
            Commands.V1.Customer.AlternateFuel.CreateForCustomer cmd =
                new Commands.V1.Customer.AlternateFuel.CreateForCustomer(customerId, request);

            IActionResult result = await RequestHandler.HandleCommand(cmd, _appService.Handle, _log);

            return CreatedAtAction("PostAlternateFuelForCustomer", result);
        }

        [Route("{associateId}/customers/{CustomerId}/OperatingContexts")]
        [HttpPost]
        public async Task<IActionResult> PostOperatingContextForCustomer(int associateId, int customerId, Commands.V1.Customer.OperatingContext.Create request)
        {
            Commands.V1.Customer.OperatingContext.CreateForCustomer cmd =
                new Commands.V1.Customer.OperatingContext.CreateForCustomer(customerId, request);

            IActionResult result = await RequestHandler.HandleCommand(cmd, _appService.Handle, _log);

            return CreatedAtAction("PostOperatingContextForCustomer", result);
        }

        [Route("{associateId}/OperatingContexts/{OperatingContextId}/Customers")]
        [HttpPost]
        public async Task<IActionResult> PostCustomerForOperatingContext(int associateId, int customerId, Commands.V1.OperatingContext.Customer.Create request)
        {
            Commands.V1.OperatingContext.Customer.CreateForOperatingContext cmd =
                new Commands.V1.OperatingContext.Customer.CreateForOperatingContext(customerId, request);

            IActionResult result = await RequestHandler.HandleCommand(cmd, _appService.Handle, _log);

            return CreatedAtAction("PostCustomerForOperatingContext", result);
        }

        [Route("{associateId}/roles")]
        [HttpPost]
        public async Task<IActionResult> PostRoleForAssociate(int associateId, Commands.V1.Role.Create request)
        {
            IActionResult result = await RequestHandler.HandleCommand(request, _appService.Handle, _log);

            return CreatedAtAction("PostRoleForAssociate", result);
        }

        [Route("{associateId}/permissions")]
        [HttpPost]
        public async Task<IActionResult> PostEGMSPermissionForAssociate(int associateId, Commands.V1.EGMSPermission.Create request)
        {
            IActionResult result = await RequestHandler.HandleCommand(request, _appService.Handle, _log);

            return CreatedAtAction("PostEGMSPermissionForAssociate", result);
        }

        [Route("{associateId}/rolepermissions")]
        [HttpPost]
        public async Task<IActionResult> PostRoleEGMSPermissionForAssociate(int associateId, Commands.V1.RoleEGMSPermission.Create request)
        {
            IActionResult result = await RequestHandler.HandleCommand(request, _appService.Handle, _log);

            return CreatedAtAction("PostRoleEGMSPermissionForAssociate", result);
        }
    }
}