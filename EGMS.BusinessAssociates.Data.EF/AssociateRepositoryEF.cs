using System;
using System.Threading.Tasks;
using AutoMapper;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Repositories;
using EGMS.BusinessAssociates.Domain.ValueObjects;
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
            var p = new SqlParameter("@result", System.Data.SqlDbType.Int);
            p.Direction = System.Data.ParameterDirection.Output;
            _context.Database.ExecuteSqlRaw("SET @result = NEXT VALUE FOR AssociateSequence", p);
            var nextVal = (int)p.Value;
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

        public bool Exists(AssociateId id)
        {
            Associate associate = _context.Associates.FindAsync(id).Result;

            return associate != null;
        }

        public void AddOperatingContext(AssociateId id, OperatingContext operatingContext)
        {
            throw new NotImplementedException();
        }

        public async Task<Associate> Load(AssociateId id)
        {
            var facilityEF = await _context.Associates.FindAsync(id);

            var facility = _mapper.Map<Associate>(facilityEF);

            // since we automapped it, any changes to this object will not automatically be
            // detected by EF...
            return facility;
        }

        public async Task Update(Associate facility)
        {
            var facilityEF = await _context.Associates.FindAsync(facility.Id);

            if (facilityEF == null)
            {
                // Exception?  Add it?
                throw new Exception($"Facility { (int)facility.Id } not found for Update.");
            }

            //_mapper.Map<Domain.Models.Facility, Facility>(facility, facilityEF);
        }
    }
}
