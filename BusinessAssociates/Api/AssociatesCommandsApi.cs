using System.Threading.Tasks;
using EGMS.BusinessAssociates.API.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EGMS.BusinessAssociates.API.Api
{
    [Route("/associate")]
    public class AssociatesCommandsApi : Controller
    {
        private readonly AssociatesApplicationService _applicationService;

        public AssociatesCommandsApi(AssociatesApplicationService applicationService)
            => _applicationService = applicationService;

        [HttpPost]
        public async Task<IActionResult> Post(Associates.V1.Create request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Associates.V1.Delete request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("longname")]
        [HttpPut]
        public async Task<IActionResult> Put(Associates.V1.UpdateLongName request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("dunsnumber")]
        [HttpPut]
        public async Task<IActionResult> Put(Associates.V1.UpdateDUNSNumber request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("internalassociatetype")]
        [HttpPut]
        public async Task<IActionResult> Put(Associates.V1.UpdateAssociateType request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("shortname")]
        [HttpPut]
        public async Task<IActionResult> Put(Associates.V1.UpdateShortName request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("status")]
        [HttpPut]
        public async Task<IActionResult> Put(Associates.V1.UpdateStatus request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("isparent")]
        [HttpPut]
        public async Task<IActionResult> Put(Associates.V1.UpdateIsParent request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }
    }
}