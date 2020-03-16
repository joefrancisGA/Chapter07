using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessAssociates.Infrastructure;
using BusinessAssociates.InternalAssociate;
using BusinessAssociates.Projections;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BusinessAssociates.Api
{
    [Route("/ad")]
    public class InternalAssociatesQueryApi : Controller
    {
        private static ILogger _log = Log.ForContext<InternalAssociatesQueryApi>();

        private readonly IEnumerable<ReadModels.InternalAssociateDetails> _items;

        public InternalAssociatesQueryApi(IEnumerable<ReadModels.InternalAssociateDetails> items)
            => _items = items;

        [HttpGet]
        public IActionResult Get(QueryModels.GetInternalAssociates request)
            => RequestHandler.HandleQuery(() => _items.Query(request), _log);
    }
}
