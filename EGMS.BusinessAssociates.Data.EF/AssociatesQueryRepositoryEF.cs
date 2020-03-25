using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EGMS.BusinessAssociates.Query;
using EGMS.BusinessAssociates.Query.ReadModels;
using EGMS.Facilities.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EGMS.BusinessAssociates.Data.EF
{
    public class AssociatesQueryRepositoryEF : IAssociateQueryRepository
    {
        private readonly AssociatesContext _context;
        private readonly ILogger _log;
        private readonly IMapper _mapper;

        public AssociatesQueryRepositoryEF(AssociatesContext context, ILogger<AssociatesQueryRepositoryEF> log, IMapper mapper)
        {
            this._context = context;
            this._log = log;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<AssociateRM>> GetFacilities(QueryModels.FacilityQueryParams queryParams)
        {
            var facilities = _context.Associates;

            var filtered = facilities.ApplyQuery(queryParams);

            var results = await filtered.ToListAsync();

            var retVal = _mapper.Map<IEnumerable<AssociateRM>>(results);

            return retVal;
        }
    }
}
