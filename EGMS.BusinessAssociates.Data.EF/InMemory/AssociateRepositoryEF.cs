using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EGMS.BusinessAssociates.Data.EF.InMemory
{
    public class AssociateRepositoryEF : IAssociateRepository
    {
        private readonly BusinessAssociatesContext _context;

        // TO DO:  Need to use logging
        // ReSharper disable once NotAccessedField.Local
        private readonly ILogger _log;
        private readonly IMapper _mapper;

        // ReSharper disable once SuggestBaseTypeForParameter
        public AssociateRepositoryEF(BusinessAssociatesContext context, ILogger<AssociateRepositoryEF> log, IMapper mapper)
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
            try
            {
                _context.Associates.Add(associate);
            }
            catch (Exception ex)
            {
                ex = ex;
            }
        }


        public bool Exists(int id)
        {

            try
            {
                Associate associate = _context.Associates.FindAsync(id).Result;

                return (associate != null);
            }
            catch (Exception ex)
            {
                ex = ex;
            }

            return false;
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
            try
            {
                Associate associateEF = await _context.Associates.FindAsync(id);

                return _mapper.Map<Associate>(associateEF);
            }
            catch (Exception ex)
            {
                ex = ex;
                throw;
            }
        }

        public async Task Update(Associate associate)
        {
            Associate associateEF = await _context.Associates.FindAsync(associate.Id);

            if (associateEF == null)
            {
                throw new Exception($"Associate {associate.Id } not found for Update.");
            }

            await _context.SaveChangesAsync();
        }
    }
}
