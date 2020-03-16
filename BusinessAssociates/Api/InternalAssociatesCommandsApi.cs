using System.Threading.Tasks;
using BusinessAssociates.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BusinessAssociates.Api
{
    [Route("/internalassociate")]
    public class InternalAssociatesCommandsApi : Controller
    {
        private readonly InternalAssociatesApplicationService _applicationService;

        public InternalAssociatesCommandsApi(InternalAssociatesApplicationService applicationService)
            => _applicationService = applicationService;

        [HttpPost]
        public async Task<IActionResult> Post(InternalAssociates.V1.Create request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("longname")]
        [HttpPut]
        public async Task<IActionResult> Put(InternalAssociates.V1.UpdateLongName request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("dunsnumber")]
        [HttpPut]
        public async Task<IActionResult> Put(InternalAssociates.V1.UpdateDUNSNumber request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("internalassociatetype")]
        [HttpPut]
        public async Task<IActionResult> Put(InternalAssociates.V1.UpdateInternalAssociateType request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("shortname")]
        [HttpPut]
        public async Task<IActionResult> Put(InternalAssociates.V1.UpdateShortName request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("status")]
        [HttpPut]
        public async Task<IActionResult> Put(InternalAssociates.V1.UpdateStatus request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("isparent")]
        [HttpPut]
        public async Task<IActionResult> Put(InternalAssociates.V1.UpdateIsParent request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }
    }
}