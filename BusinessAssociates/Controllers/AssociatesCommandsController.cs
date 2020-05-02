using System.Threading.Tasks;
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

        // TO DO:  Use this or eliminate it
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

        [Route("{associateId}/operatingcontexts")]
        [HttpPost]
        public IActionResult PostOperatingContextForAssociate(int associateId, [FromBody]Commands.V1.OperatingContext.Create request)
        {
            Commands.V1.OperatingContext.CreateForAssociate createForAssociate =
                new Commands.V1.OperatingContext.CreateForAssociate(associateId, request);

            return CreatedAtAction("PostOperatingContextForAssociate", (OperatingContextRM)_appService.Handle(createForAssociate).Result);
        }


        [Route("{associateId}/operatingcontexts/{operatingContextId}/Addresses")]
        [HttpPost]
        public IActionResult PostAddressForAssociate(int associateId, [FromBody]Commands.V1.Associate.Address.Create request)
        {
            Commands.V1.Associate.Address.CreateForAssociate createForAssociate =
                new Commands.V1.Associate.Address.CreateForAssociate(associateId, request);

            return CreatedAtAction("PostAddressForAssociate", (AddressRM)_appService.Handle(createForAssociate).Result);
        }

        [Route("{associateId}/contacts")]
        [HttpPost]
        public IActionResult PostContactForAssociate(int associateId, [FromBody]Commands.V1.Contact.Create request)
        {
            Commands.V1.Contact.CreateForAssociate createForAssociate =
                new Commands.V1.Contact.CreateForAssociate(associateId, request);

            return CreatedAtAction("PostContactForAssociate", (ContactRM)_appService.Handle(createForAssociate).Result);
        }


        [Route("{associateId}/contacts/{contactId}/Addresses")]
        [HttpPost]
        public IActionResult PostAddressForContact(int contactId, [FromBody]Commands.V1.Contact.Address.CreateForContact request)
        {
            Commands.V1.Contact.Address.CreateForContact createForContact =
                new Commands.V1.Contact.Address.CreateForContact(contactId, request);

            return CreatedAtAction("PostAddressForContact", (ContactRM)_appService.Handle(createForContact).Result);
        }

        [Route("{principalId}/agentrelationships")]
        [HttpPost]
        public IActionResult PostAgentRelationshipForPrincipal(int principalId, [FromBody]Commands.V1.AgentRelationship.Create request)
        {
            Commands.V1.AgentRelationship.CreateForPrincipal createForPrincipal =
                new Commands.V1.AgentRelationship.CreateForPrincipal(principalId, request);

            return CreatedAtAction("PostAgentRelationshipForPrincipal", (ContactRM)_appService.Handle(createForPrincipal).Result);
        }

        [Route("{associateId}/users")]
        [HttpPost]
        public IActionResult PostUserForAssociate(int associateId, [FromBody]Commands.V1.User.Create request)
        {
            Commands.V1.User.CreateForAssociate createForAssociate =
                new Commands.V1.User.CreateForAssociate(associateId, request);

            return CreatedAtAction("PostUserForAssociate", (UserRM)_appService.Handle(createForAssociate).Result);
        }

        [Route("{associateId}/agentrelationships/{agentId}/Users")]
        [HttpPost]
        public IActionResult PostUserForAgent(int agentId, [FromBody]Commands.V1.AgentRelationship.User.Create request)
        {
            Commands.V1.AgentRelationship.User.CreateForAgent createForAgent =
                new Commands.V1.AgentRelationship.User.CreateForAgent(agentId, request);

            return CreatedAtAction("PostUserForAgent", (UserRM)_appService.Handle(createForAgent).Result);
        }

        [Route("{associateId}/customers")]
        [HttpPost]
        public IActionResult PostCustomerForAssociate(int associateId, [FromBody]Commands.V1.Customer.Create request)
        {
            Commands.V1.Customer.CreateForAssociate createForAssociate =
                new Commands.V1.Customer.CreateForAssociate(associateId, request);

            return CreatedAtAction("PostCustomerForAssociate", (CustomerRM)_appService.Handle(createForAssociate).Result);
        }

        [Route("{associateId}/operatingcontexts/{operatingContextId}/Certification")]
        [HttpPost]
        public IActionResult PostCertificationForOperatingContext(int operatingContextId, [FromBody]Commands.V1.OperatingContext.Certification.Create request)
        {
            Commands.V1.OperatingContext.Certification.CreateForOperatingContext createForOperatingContext =
                new Commands.V1.OperatingContext.Certification.CreateForOperatingContext(operatingContextId, request);

            return CreatedAtAction("PostCertificationForOperatingContext", (CustomerRM)_appService.Handle(createForOperatingContext).Result);
        }

        [Route("{associateId}/contacts/{contactId}/Configuration")]
        [HttpPost]
        public IActionResult PostContactConfigurationForContact(int contactId, [FromBody]Commands.V1.Contact.ContactConfiguration.Create request)
        {
            Commands.V1.Contact.ContactConfiguration.CreateForContact createForContact =
                new Commands.V1.Contact.ContactConfiguration.CreateForContact(contactId, request);

            return CreatedAtAction("PostContactConfigurationForContact", (ContactConfigurationRM)_appService.Handle(createForContact).Result);
        }

        [Route("{associateId}/contacts/{contactId}/Emails")]
        [HttpPost]
        public IActionResult PostEMailForContact(int contactId, [FromBody]Commands.V1.Contact.EMail.Create request)
        {
            Commands.V1.Contact.EMail.CreateForContact createForContact =
                new Commands.V1.Contact.EMail.CreateForContact(contactId, request);

            return CreatedAtAction("PostEMailForContact", (EMailRM)_appService.Handle(createForContact).Result);
        }

        [Route("{associateId}/contacts/{contactId}/Phones")]
        [HttpPost]
        public IActionResult PostPhoneForContact(int contactId, [FromBody]Commands.V1.Contact.Phone.Create request)
        {
            Commands.V1.Contact.Phone.CreateForContact createForContact =
                new Commands.V1.Contact.Phone.CreateForContact(contactId, request);

            return CreatedAtAction("PostPhoneForContact", (PhoneRM)_appService.Handle(createForContact).Result);
        }

        // TO DO:  Do we want to return Ok() under all circumstances?
        [Route("{associateId}/customers/{customerId}/AlternateFuels")]
        [HttpPost]
        public async Task<IActionResult> PostAlternateFuelForCustomer(int customerId, [FromBody]Commands.V1.Customer.AlternateFuel.Create request)
        {
            Commands.V1.Customer.AlternateFuel.CreateForCustomer createForCustomer =
                new Commands.V1.Customer.AlternateFuel.CreateForCustomer(customerId, request);

            await _appService.Handle(createForCustomer);

            return Ok();
        }

        [Route("{associateId}/customers/{customerId}/OperatingContexts")]
        [HttpPost]
        public IActionResult PostOperatingContextForCustomer(int customerId, [FromBody]Commands.V1.OperatingContext.Create request)
        {
            Commands.V1.OperatingContext.CreateForCustomer createForCustomer =
                new Commands.V1.OperatingContext.CreateForCustomer(customerId, request);

            return CreatedAtAction("PostOperatingContextForCustomer", (OperatingContextRM)_appService.Handle(createForCustomer).Result);
        }

        [Route("{associateId}/OperatingContexts/{operatingContextId}/Customers")]
        [HttpPost]
        public IActionResult PostCustomerForOperatingContext(int operatingContextId, [FromBody]Commands.V1.OperatingContext.Customer.Create request)
        {
            Commands.V1.OperatingContext.Customer.CreateForOperatingContext createForOperatingContext =
                new Commands.V1.OperatingContext.Customer.CreateForOperatingContext(operatingContextId, request);
            return CreatedAtAction("PostCustomerForOperatingContext", (ContactConfigurationRM)_appService.Handle(createForOperatingContext).Result);
        }

        [Route("{associateId}/roles")]
        [HttpPost]
        public async Task<IActionResult> PostRole([FromBody]Commands.V1.Role.Create request)
        {
            await _appService.Handle(request);

            return Ok();
        }

        [Route("{associateId}/egmspermissions")]
        [HttpPost]
        public async Task<IActionResult> PostEGMSPermission([FromBody]Commands.V1.EGMSPermission.Create request)
        {
            await _appService.Handle(request);

            return Ok();
        }

        [Route("{associateId}/roleegmspermissions")]
        [HttpPost]
        public async Task<IActionResult> PostRoleEGMSPermissionForAssociate([FromBody]Commands.V1.RoleEGMSPermission.Create request)
        {
            await _appService.Handle(request);

            return Ok();
        }

        #region Update Associate Properties

        [Route("longname")]
        [HttpPut]
        public async Task<IActionResult> UpdateAssociateLongName(Commands.V1.Associate.UpdateLongName request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        [Route("dunsnumber")]
        [HttpPut]
        public async Task<IActionResult> UpdateAssociateDUNSNumber(Commands.V1.Associate.UpdateDUNSNumber request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        [Route("internalassociatetype")]
        [HttpPut]
        public async Task<IActionResult> UpdateAssociateAssociateType(Commands.V1.Associate.UpdateAssociateType request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        [Route("shortname")]
        [HttpPut]
        public async Task<IActionResult> UpdateAssociateShortName(Commands.V1.Associate.UpdateShortName request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        [Route("status")]
        [HttpPut]
        public async Task<IActionResult> UpdateAssociateStatus(Commands.V1.Associate.UpdateStatus request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        [Route("isparent")]
        [HttpPut]
        public async Task<IActionResult> UpdateAssociateIsParent(Commands.V1.Associate.UpdateIsParent request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        #endregion Update Associate Properties
    }
}