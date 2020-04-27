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
        public async Task<IActionResult> PostCustomerForAssociate(int associateId, [FromBody]Commands.V1.Customer.CreateForAssociate request)
        {
            request.AssociateId = associateId;
            object x = await _appService.Handle(request);

            CustomerRM customerRM = (CustomerRM)x;

            return CreatedAtAction("PostCustomerForAssociate", customerRM);
        }

        [Route("{associateId}/operatingcontexts/{operatingContextId}/Certification")]
        [HttpPost]
        public async Task<IActionResult> PostCertificationForOperatingContext(int operatingContextId, [FromBody]Commands.V1.OperatingContext.Certification.CreateForOperatingContext request)
        {
            request.OperatingContextId = operatingContextId;
            object x = await _appService.Handle(request);

            CertificationRM certificationRM = (CertificationRM)x;

            return CreatedAtAction("PostCertificationForOperatingContext", certificationRM);
        }

        [Route("{associateId}/contacts/{contactId}/Configuration")]
        [HttpPost]
        public async Task<IActionResult> PostContactConfigurationForContact(int contactId, [FromBody]Commands.V1.Contact.ContactConfiguration.CreateForContact request)
        {
            request.ContactId = contactId;
            object x = await _appService.Handle(request);
            
            ContactConfigurationRM contactConfigurationRM = (ContactConfigurationRM)x;

            return CreatedAtAction("PostContactConfigurationForContact", contactConfigurationRM);
        }

        [Route("{associateId}/contacts/{contactId}/Emails")]
        [HttpPost]
        public async Task<IActionResult> PostEMailForContact(int contactId, [FromBody]Commands.V1.Contact.EMail.CreateForContact request)
        {
            request.ContactId = contactId;
            object x = await _appService.Handle(request);

            EMailRM eMailRM = (EMailRM)x;

            return CreatedAtAction("PostEMailForContact", eMailRM);
        }

        [Route("{associateId}/contacts/{contactId}/Phones")]
        [HttpPost]
        public async Task<IActionResult> PostPhoneForContact(int contactId, [FromBody]Commands.V1.Contact.Phone.CreateForContact request)
        {
            request.ContactId = contactId;
            object x = await _appService.Handle(request);

            PhoneRM phoneRM = (PhoneRM)x;

            return CreatedAtAction("PostPhoneForContact", phoneRM);
        }

        // TO DO:  Do we want to return Ok() under all circumstances?
        [Route("{associateId}/customers/{customerId}/AlternateFuels")]
        [HttpPost]
        public async Task<IActionResult> PostAlternateFuelForCustomer(int customerId, [FromBody]Commands.V1.Customer.AlternateFuel.CreateForCustomer request)
        {
            request.CustomerId = customerId;
            await _appService.Handle(request);

            return Ok();
        }

        [Route("{associateId}/customers/{customerId}/OperatingContexts")]
        [HttpPost]
        public async Task<IActionResult> PostOperatingContextForCustomer(int customerId, [FromBody]Commands.V1.OperatingContext.CreateForCustomer request)
        {
            request.CustomerId = customerId;
            object x = await _appService.Handle(request);

            OperatingContextRM operatingContextRM = (OperatingContextRM)x;

            return CreatedAtAction("PostOperatingContextForCustomer", operatingContextRM);
        }

        [Route("{associateId}/OperatingContexts/{operatingContextId}/Customers")]
        [HttpPost]
        public async Task<IActionResult> PostCustomerForOperatingContext(int operatingContextId, [FromBody]Commands.V1.OperatingContext.Customer.CreateForOperatingContext request)
        {
            request.OperatingContextId = operatingContextId;
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