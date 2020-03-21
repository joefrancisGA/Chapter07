using System.Data.Common;
using System.Threading.Tasks;
using EGMS.BusinessAssociates.API.Infrastructure;
using EGMS.BusinessAssociates.API.Queries;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace EGMS.BusinessAssociates.API.Api
{
    [Route("/associate")]
    public class AssociatesQueryApi : Controller
    {
        private static readonly ILogger Log = Serilog.Log.ForContext<AssociatesQueryApi>();

        private readonly DbConnection _connection;

        public AssociatesQueryApi(DbConnection connection) => _connection = connection;

        [HttpGet]
        [Route("list")]
        public Task<IActionResult> Get(QueryModels.GetAssociates request)
            => RequestHandler.HandleQuery(() => _connection.Query(request), Log);

        [HttpGet]
        public Task<IActionResult> Get(QueryModels.GetAssociate request)
            => RequestHandler.HandleQuery(() => _connection.Query(request), Log);
    }
}
