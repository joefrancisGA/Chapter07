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

        [Route("text")]
        [HttpPut]
        public async Task<IActionResult> Put(InternalAssociates.V1.UpdateText request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }
    }
}