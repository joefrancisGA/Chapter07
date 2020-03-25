using System.Data.Common;
using System.Threading.Tasks;
using EGMS.BusinessAssociates.API.Infrastructure;
using EGMS.BusinessAssociates.API.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace EGMS.BusinessAssociates.API.Controllers
{
    [Route("api/associate")]
    public class AssociateQueriesController : Controller
    {
        private ILogger _log;
        private readonly DbConnection _conn;

        public AssociateQueriesController(DbConnection conn, ILogger<AssociateQueriesController> log)
        {
            _log = log;
            _conn = conn;
        }

        [HttpGet]
        [Route("list")]
        public Task<IActionResult> Get(QueryModels.GetAssociates request) => RequestHandler.HandleQuery(() => _conn.Query(request), _log);

        [HttpGet]
        public Task<IActionResult> Get(QueryModels.GetAssociate request) => RequestHandler.HandleQuery(() => _conn.Query(request), _log);
    }
}
