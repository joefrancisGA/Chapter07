using System.Data.Common;
using System.Threading.Tasks;
using EGMS.BusinessAssociates.API.Infrastructure;
using EGMS.BusinessAssociates.API.Queries;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace EGMS.BusinessAssociates.API.Api
{
    [Route("api/associate")]
    public class AssociateQueriesController : Controller
    {
        private static readonly ILogger Log = Serilog.Log.ForContext<AssociateQueriesController>();
        private readonly DbConnection _conn;

        public AssociateQueriesController(DbConnection conn) => _conn = conn;

        [HttpGet]
        [Route("list")]
        public Task<IActionResult> Get(QueryModels.GetAssociates request) => RequestHandler.HandleQuery(() => _conn.Query(request), Log);

        [HttpGet]
        public Task<IActionResult> Get(QueryModels.GetAssociate request) => RequestHandler.HandleQuery(() => _conn.Query(request), Log);
    }
}
