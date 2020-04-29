using System.Data.Common;
using System.Threading.Tasks;
using EGMS.BusinessAssociates.API.Infrastructure;
using EGMS.BusinessAssociates.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace EGMS.BusinessAssociates.API.Controllers
{
    [Route("api/associate")]
    public class AssociateQueriesController : Controller
    {
        private readonly IAssociateQueryRepository _queryRepo;
        private readonly ILogger _log;

        public AssociateQueriesController(IAssociateQueryRepository queryRepo, ILogger<AssociateQueriesController> log)
        {
            _log = log;
            _queryRepo = queryRepo;
        }


        [HttpGet]
        public Task<IActionResult> Get(QueryModels.AssociateQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetAssociatesAsync(request), _log);

        [HttpGet]
        [Route("{associateId}")]
        public Task<IActionResult> Get(int associateId) => RequestHandler.HandleQuery(() => _queryRepo.GetAssociateAsync(associateId), _log);


        [HttpGet]
        [Route("addresses")]
        public Task<IActionResult> GetAddresses([FromQuery]QueryModels.AddressQueryParams request) => RequestHandler.HandleQuery(() => _queryRepo.GetAddressesAsync(request), _log);

        [HttpGet]
        [Route("{associateId}/addresses")]
        public Task<IActionResult> GetAddresses(int associateId, [FromQuery]QueryModels.AddressQueryParams request)
        {
            return RequestHandler.HandleQuery(() => _queryRepo.GetAssociateAsync(associateId), _log);
        }


        private const string GetAddressAPI = "";
        private const string GetAgentRelationshipAPI = "";
        private const string GetAlternateFuelAPI = "";
        private const string GetCertificationAPI = "";
        private const string GetContactAPI = "";
        private const string GetContactConfigurationAPI = "";
        private const string GetCustomerAPI = "";
        private const string GetEMailAPI = "";
        private const string GetOperatingContextAPI = "";
        private const string GetPhoneAPI = "";
        private const string GetRoleAPI = "";
        private const string GetRoleEGMSPermissionAPI = "";
        private const string GetUserAPI = "";
        
    }
}
