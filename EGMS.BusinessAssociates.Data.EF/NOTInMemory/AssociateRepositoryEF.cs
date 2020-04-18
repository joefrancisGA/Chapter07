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
    public class _AssociateRepositoryEF// : IAssociateRepository
    {
        private readonly BusinessAssociatesContext _context;

        // TO DO:  Need to use logging
        // ReSharper disable once NotAccessedField.Local
        private readonly ILogger _log;
        private readonly IMapper _mapper;

        // ReSharper disable once SuggestBaseTypeForParameter
        public _AssociateRepositoryEF(BusinessAssociatesContext context, ILogger<AssociateRepositoryEF> log, IMapper mapper)
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

        public void AddAgentRelationshipForPrincipal(AgentRelationship agentRelationship, int principalId)
        {
            throw new NotImplementedException();
        }

        public bool CustomerExistsForOperatingContext(Customer customer, int operatingContextId)
        {
            throw new NotImplementedException();
        }

        public void AddAssociate(Associate associate)
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


        public bool AssociateExists(int id)
        {
            return (_context.Associates.FindAsync(id).Result != null);
        }

        public bool ContactConfigurationExistsForContact(ContactConfiguration contactConfiguration, int contactId)
        {
            throw new NotImplementedException();
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

        public void AddContactForAssociate(Associate associate, Contact contact)
        {
            throw new NotImplementedException();
        }

        public bool AddressExistsForContact(Address address, int contactId)
        {
            throw new NotImplementedException();
        }

        public bool AddAddressForContact(Address address, int contactId)
        {
            throw new NotImplementedException();
        }

        public void AddContactConfigurationForContact(int contactId, ContactConfiguration contactConfiguration)
        {
            throw new NotImplementedException();
        }

        public async Task<Associate> LoadAssociate(int id)
        {
            Associate associateEF = await _context.Associates.FindAsync(id);

            return _mapper.Map<Associate>(associateEF);
        }

        public bool AgentRelationshipExistsForPrincipal(AgentRelationship agentRelationship, int principalId)
        {
            throw new NotImplementedException();
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
