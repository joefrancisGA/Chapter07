using System.Collections.Generic;
using BusinessAssociates.Infrastructure;
using BusinessAssociates.Projections;
using BusinessAssociates.Queries;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BusinessAssociates.Api
{
    [Route("/associate")]
    public class AssociatesQueryApi : Controller
    {
        private static ILogger _log = Log.ForContext<AssociatesQueryApi>();

        private readonly IEnumerable<ReadModels.AssociateDetails> _items;

        public AssociatesQueryApi(IEnumerable<ReadModels.AssociateDetails> items) => _items = items;

        [HttpGet]
        public IActionResult Get(QueryModels.GetAssociates request)
            => RequestHandler.HandleQuery(() => _items.Query(request), _log);
    }
}
