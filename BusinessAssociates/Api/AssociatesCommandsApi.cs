using System.Threading.Tasks;
using EGMS.BusinessAssociates.Command;
using Microsoft.AspNetCore.Mvc;

namespace EGMS.BusinessAssociates.API.Api
{
    [Route("api/associate")]
    public class AssociatesCommandsApi : Controller
    {
        private readonly AssociatesApplicationService _appService;

        public AssociatesCommandsApi(AssociatesApplicationService appService) => _appService = appService;

        [HttpPost]
        public async Task<IActionResult> Post(Commands.V1.Create request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Commands.V1.Delete request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        [Route("longname")]
        [HttpPut]
        public async Task<IActionResult> Put(Commands.V1.UpdateLongName request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        [Route("dunsnumber")]
        [HttpPut]
        public async Task<IActionResult> Put(Commands.V1.UpdateDUNSNumber request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        [Route("internalassociatetype")]
        [HttpPut]
        public async Task<IActionResult> Put(Commands.V1.UpdateAssociateType request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        [Route("shortname")]
        [HttpPut]
        public async Task<IActionResult> Put(Commands.V1.UpdateShortName request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        [Route("status")]
        [HttpPut]
        public async Task<IActionResult> Put(Commands.V1.UpdateStatus request)
        {
            await _appService.Handle(request);
            return Ok();
        }

        [Route("isparent")]
        [HttpPut]
        public async Task<IActionResult> Put(Commands.V1.UpdateIsParent request)
        {
            await _appService.Handle(request);
            return Ok();
        }
    }
}