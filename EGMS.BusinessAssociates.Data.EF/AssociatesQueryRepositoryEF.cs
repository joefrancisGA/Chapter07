﻿using AutoMapper;
using EGMS.BusinessAssociates.Query;
using Microsoft.Extensions.Logging;

namespace EGMS.BusinessAssociates.Data.EF
{
    public class AssociatesQueryRepositoryEF : IAssociateQueryRepository
    {
        private readonly BusinessAssociatesContext _context;
        // ReSharper disable once NotAccessedField.Local
        private readonly ILogger _log;
        private readonly IMapper _mapper;

        public AssociatesQueryRepositoryEF(BusinessAssociatesContext context, ILogger log, IMapper mapper)
        {
            _context = context;
            _log = log;
            _mapper = mapper;
        }

        //public async Task<IEnumerable<AssociateRM>> GetAssociates(QueryModels.AssociateQueryParams queryParams)
        //{
        //    var facilities = _context.Associates;

        //    var filtered = facilities.ApplyQuery(queryParams);

        //    var results = await filtered.ToListAsync();

        //    var retVal = _mapper.Map<IEnumerable<AssociateRM>>(results);

        //    return retVal;
        //}
    }
}
