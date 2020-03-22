using System.Threading.Tasks;
using EGMS.BusinessAssociates.Command;
using Microsoft.AspNetCore.Mvc;

namespace EGMS.BusinessAssociates.API.Controllers
{
    [Route("api/associate")]
    public class AssociatesCommandsController : Controller
    {
        private readonly AssociatesApplicationService _appService;

        public AssociatesCommandsController(AssociatesApplicationService appService) => _appService = appService;

        [HttpPost]
        public async Task<IActionResult> Post(Commands.V1.Associate.Create request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        [HttpPost("{id}/OperatingContext")]
        public async Task<IActionResult> Post(Commands.V1.OperatingContext.Create request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Commands.V1.Associate.Delete request)
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
    }
}