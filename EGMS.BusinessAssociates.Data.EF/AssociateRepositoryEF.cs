using System;
using System.Threading.Tasks;
using AutoMapper;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Repositories;
using EGMS.Facilities.Data.EF;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        public void Delete(Associate entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateDUNSNumber(Associate entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateAssociateType(Associate entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateLongName(Associate entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateIsParent(Associate entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatus(Associate entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateShortName(Associate entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            Associate associate = _context.Associates.FindAsync(id).Result;

            return associate != null;
        }

        public void AddOperatingContext(int id, OperatingContext operatingContext)
        {
            throw new NotImplementedException();
        }

        public async Task<Associate> Load(int id)
        {
            var facilityEF = await _context.Associates.FindAsync(id);

            var facility = _mapper.Map<Associate>(facilityEF);

            // since we automapped it, any changes to this object will not automatically be
            // detected by EF...
            return facility;
        }

        public async Task Update(Associate associate)
        {
            Associate associateEF = await _context.Associates.FindAsync(associate.Id);

            if (associateEF == null)
            {
                throw new Exception($"Associate {associate.Id } not found for Update.");
            }

            //_mapper.Map<Domain.Models.Facility, Facility>(facility, facilityEF);
        }
    }
}
