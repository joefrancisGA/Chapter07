using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace EGMS.BusinessAssociates.Data.EF
{
    public class AssociateRepositoryEF : IAssociateRepository
    {
        private readonly AssociatesContext _context;
        private readonly ILogger _log;
        private readonly IMapper _mapper;

        public AssociateRepositoryEF(AssociatesContext context, ILogger<AssociateRepositoryEF> log, IMapper mapper)
        {
            _context = context;
            _log = log;
            _mapper = mapper;
        }

        public int GetNextAssociateId()
        {
            SqlParameter parameter = new SqlParameter("@result", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.Output
            };

            _context.Database.ExecuteSqlRaw("SET @result = NEXT VALUE FOR AssociateSequence", parameter);
            var nextVal = (int)parameter.Value;
            return nextVal;
        }

        public void Add(Associate associate)
        {
            _context.Associates.Add(associate);
        }


        public bool Exists(int id)
        {
            return _context.Associates.FindAsync(id).Result != null;
        }

        public void AddOperatingContext(OperatingContext operatingContext)
        {
            _context.OperatingContexts.Add(operatingContext);
            _context.SaveChanges();
        }

        public async void AddAssociateOperatingContext(Associate associate, OperatingContext operatingContext)
        {
            int operatingContextId = _context.OperatingContexts.ToList().Last().Id;

            AssociateOperatingContext association = new AssociateOperatingContext(associate.Id, operatingContextId);

            _context.AssociateOperatingContexts.Add(association);

            await _context.SaveChangesAsync();
        }

        public async Task<Associate> Load(int id)
        {
            Associate associateEF = await _context.Associates.FindAsync(id);

            return _mapper.Map<Associate>(associateEF);
        }

        public async Task Update(Associate associate)
        {
            Associate associateEF = await _context.Associates.FindAsync(associate.Id);

            if (associateEF == null)
            {
                throw new Exception($"Associate {associate.Id } not found for Update.");
            }
        }
    }
}
