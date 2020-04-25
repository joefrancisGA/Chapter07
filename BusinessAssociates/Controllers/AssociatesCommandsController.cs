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
        public async Task<IActionResult> PostAddressForOperatingContext([FromBody]Commands.V1.OperatingContext.Address.CreateForOperatingContext request)
        {
            object x = await _appService.Handle(request);

            AddressRM addressRM = (AddressRM)x;

            return CreatedAtAction("PostAddressForOperatingContext", addressRM);
        }

        [Route("{associateId}/contacts")]
        [HttpPost]
        public async Task<IActionResult> PostContactForAssociate([FromBody]Commands.V1.Contact.CreateForAssociate request)
        {
            object x = await _appService.Handle(request);

            ContactRM contactRM = (ContactRM)x;

            return CreatedAtAction("PostContactForAssociate", contactRM);
        }


        [Route("{associateId}/contacts/{contactId}/Addresses")]
        [HttpPost]
        public async Task<IActionResult> PostAddressForContact([FromBody]Commands.V1.Contact.Address.CreateForContact request)
        {
            object x = await _appService.Handle(request);

            AddressRM addressRM = (AddressRM)x;

            return CreatedAtAction("PostAddressForContact", addressRM);
        }

        [Route("{principalId}/agentrelationships")]
        [HttpPost]
        public async Task<IActionResult> PostAgentRelationshipForPrincipal([FromBody]Commands.V1.AgentRelationship.CreateForPrincipal request)
        {
            object x = await _appService.Handle(request);
            
            AgentRelationshipRM agentRelationshipRM = (AgentRelationshipRM)x;

            return CreatedAtAction("PostAgentRelationshipForPrincipal", agentRelationshipRM);
        }

        [Route("{associateId}/users")]
        [HttpPost]
        public async Task<IActionResult> PostUserForAssociate(Commands.V1.User.CreateForAssociate request)
        {
            object x = await _appService.Handle(request);

            UserRM userRM = (UserRM)x;

            return CreatedAtAction("PostUserForAssociate", userRM);
        }

        [Route("{associateId}/agentrelationships/{agentId}/Users")]
        [HttpPost]
        public async Task<IActionResult> PostUserForAgent([FromBody]Commands.V1.AgentRelationship.User.CreateForAgent request)
        {
            object x = await _appService.Handle(request);

            AgentRelationshipRM agentRelationshipRM = (AgentRelationshipRM)x;

            return CreatedAtAction("PostUserForAgent", agentRelationshipRM);
        }

        [Route("{associateId}/customers")]
        [HttpPost]
        public async Task<IActionResult> PostCustomerForAssociate([FromBody]Commands.V1.Customer.Create request)
        {
            object x = await _appService.Handle(request);

            CustomerRM customerRM = (CustomerRM)x;

            return CreatedAtAction("PostCustomerForAssociate", customerRM);
        }

        [Route("{associateId}/operatingcontexts/{operatingContextId}/Certification")]
        [HttpPost]
        public async Task<IActionResult> PostCertificationForOperatingContext([FromBody]Commands.V1.OperatingContext.Certification.CreateForOperatingContext request)
        {
            object x = await _appService.Handle(request);

            CertificationRM certificationRM = (CertificationRM)x;

            return CreatedAtAction("PostCertificationForOperatingContext", certificationRM);
        }

        [Route("{associateId}/contacts/{contactId}/Configuration")]
        [HttpPost]
        public async Task<IActionResult> PostContactConfigurationForContact([FromBody]Commands.V1.Contact.ContactConfiguration.CreateForContact request)
        {
            object x = await _appService.Handle(request);
            
            ContactConfigurationRM contactConfigurationRM = (ContactConfigurationRM)x;

            return CreatedAtAction("PostContactConfigurationForContact", contactConfigurationRM);
        }

        [Route("{associateId}/contacts/{contactId}/Emails")]
        [HttpPost]
        public async Task<IActionResult> PostEMailForContact([FromBody]Commands.V1.Contact.EMail.CreateForContact request)
        {
            object x = await _appService.Handle(request);

            EMailRM eMailRM = (EMailRM)x;

            return CreatedAtAction("PostEMailForContact", eMailRM);
        }

        [Route("{associateId}/contacts/{contactId}/Phones")]
        [HttpPost]
        public async Task<IActionResult> PostPhoneForContact([FromBody]Commands.V1.Contact.Phone.CreateForContact request)
        {
            object x = await _appService.Handle(request);

            PhoneRM phoneRM = (PhoneRM)x;

            return CreatedAtAction("PostPhoneForContact", phoneRM);
        }

        [Route("{associateId}/customers/{CustomerId}/AlternateFuels")]
        [HttpPost]
        public async Task<IActionResult> PostAlternateFuelForCustomer([FromBody]Commands.V1.Customer.AlternateFuel.CreateForCustomer request)
        {
            await _appService.Handle(request);

            return Ok();
        }

        [Route("{associateId}/customers/{CustomerId}/OperatingContexts")]
        [HttpPost]
        public async Task<IActionResult> PostOperatingContextForCustomer([FromBody]Commands.V1.Customer.OperatingContext.Create request)
        {
            object x = await _appService.Handle(request);

            OperatingContextRM operatingContextRM = (OperatingContextRM)x;

            return CreatedAtAction("PostOperatingContextForCustomer", operatingContextRM);
        }

        [Route("{associateId}/OperatingContexts/{OperatingContextId}/Customers")]
        [HttpPost]
        public async Task<IActionResult> PostCustomerForOperatingContext([FromBody]Commands.V1.OperatingContext.Customer.CreateForOperatingContext request)
        {
            object x = await _appService.Handle(request);
            
            CustomerRM customerRM = (CustomerRM)x;

            return CreatedAtAction("PostCustomerForOperatingContext", customerRM);
        }

        [Route("{associateId}/roles")]
        [HttpPost]
        public async Task<IActionResult> PostRole([FromBody]Commands.V1.Role.Create request)
        {
            await _appService.Handle(request);

            return Ok();
        }

        [Route("{associateId}/permissions")]
        [HttpPost]
        public async Task<IActionResult> PostEGMSPermission([FromBody]Commands.V1.EGMSPermission.Create request)
        {
            await _appService.Handle(request);

            return Ok();
        }

        [Route("{associateId}/rolepermissions")]
        [HttpPost]
        public async Task<IActionResult> PostRoleEGMSPermissionForAssociate([FromBody]Commands.V1.RoleEGMSPermission.Create request)
        {
            await _appService.Handle(request);

            return Ok();
        }
    }
}