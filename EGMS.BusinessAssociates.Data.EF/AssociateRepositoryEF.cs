using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace EGMS.BusinessAssociates.Data.EF
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
                //Associate associate = _context.Associates[id]; 

                Associate associate = _context.Associates.Find(a => a.DUNSNumber == id);

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
        }

        public async void AddAssociateOperatingContext(Associate associate, OperatingContext operatingContext)
        {
            int operatingContextId = _context.OperatingContexts.ToList().Last().Id;

            AssociateOperatingContext association = new AssociateOperatingContext(associate.Id, operatingContextId);

            _context.AssociateOperatingContexts.Add(association);
        }

        public void AddContactForAssociate(Associate associate, Contact contact)
        {
            throw new NotImplementedException();
        }

#pragma warning disable 1998
        public async Task<Associate> Load(int id)
#pragma warning restore 1998
        {
            try
            {
                Associate associateEF = _context.Associates[id];

                return _mapper.Map<Associate>(associateEF);
            }
            catch (Exception ex)
            {
                ex = ex;
                throw;
            }
        }

#pragma warning disable 1998
        public async Task Update(Associate associate)
#pragma warning restore 1998
        {
            Associate associateEF = _context.Associates[associate.Id];

            if (associateEF == null)
            {
                throw new Exception($"Associate {associate.Id} not found for Update.");
            }

            _context.Associates[associate.Id] = associate;
        }
    }
}
