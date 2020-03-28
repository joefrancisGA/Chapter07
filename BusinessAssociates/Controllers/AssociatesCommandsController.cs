using System;
using System.Threading.Tasks;
using EGMS.BusinessAssociates.API.Infrastructure;
using EGMS.BusinessAssociates.Command;
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

        [HttpPost]
        public async Task<IActionResult> Post(Commands.V1.Associate.Create request)
        {
            await _appService.Handle(request);
            return Ok();
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

        [Route("operatingcontexts")]
        [HttpPost]
        public async Task<IActionResult> Post(Commands.V1.OperatingContext.Create request)
        {
            try
            {
                var result = await RequestHandler.HandleCommand(request, _appService.Handle, _log);

                return CreatedAtAction("Post", result);
            }
            catch (Exception exc)
            {
                return new BadRequestObjectResult(
                    new
                    {
                        error = exc.Message,
                        stackTrace = exc.StackTrace
                    });
            }
        }

        [Route("{associateId}/operatingcontexts")]
        [HttpPost]
        public async Task<IActionResult> Post(int associateId, Commands.V1.OperatingContext.Create request)
        {
            request.AssociateId = associateId;
            return await Post(request);
        }

    }
}