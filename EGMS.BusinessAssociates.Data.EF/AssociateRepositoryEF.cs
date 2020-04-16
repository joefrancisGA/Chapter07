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

        public Customer AddCustomerForOperatingContext(Customer customer, int operatingContextId)
        {
            throw new NotImplementedException();
        }

        public bool PermissionExists(string permissionName)
        {
            throw new NotImplementedException();
        }

        public void AddPermission(EGMSPermission permission)
        {
            throw new NotImplementedException();
        }

        public bool AddressExistsForOperatingContext(Address address, int operatingContextId)
        {
            throw new NotImplementedException();
        }

        public Address AddAddressForOperatingContext(Address address, int operatingContextId)
        {
            throw new NotImplementedException();
        }

        public bool AlternateFuelExistsForCustomer(int alternateFuelId, int customerId)
        {
            throw new NotImplementedException();
        }

        public void AddAlternateFuelForCustomer(int alternateFuelId, int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<OperatingContext> AddOperatingContextForCustomer(OperatingContext operatingContext, int customerId)
        {
            throw new NotImplementedException();
        }

        public bool OperatingContextExistsForCustomer(OperatingContext operatingContext, int customerId)
        {
            throw new NotImplementedException();
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
            _context.Associates.Add(associate);
        }


        public bool AssociateExists(int id)
        {
                //Associate associate = _context.Associates[id]; 

            return (_context.Associates.Find(a => a.DUNSNumber == id) != null);
        }

        public bool ContactConfigurationExistsForContact(ContactConfiguration contactConfiguration, int contactId)
        {
            throw new NotImplementedException();
        }

        public void AddOperatingContext(OperatingContext operatingContext)
        {
            _context.OperatingContexts.Add(operatingContext);
        }

        public void AddAssociateOperatingContext(Associate associate, OperatingContext operatingContext)
        {
            int operatingContextId = _context.OperatingContexts.ToList().Last().Id;

            AssociateOperatingContext association = new AssociateOperatingContext(associate.Id, operatingContextId);

            _context.AssociateOperatingContexts.Add(association);
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

        public void AddContactConfigurationForContact(Contact contact, ContactConfiguration contactConfiguration)
        {
            throw new NotImplementedException();
        }

#pragma warning disable 1998
        public async Task<Associate> LoadAssociate(int id)
#pragma warning restore 1998
        {
            Associate associateEF = _context.Associates[id];

            return _mapper.Map<Associate>(associateEF);
        }

        public RoleEGMSPermission AddRoleEGMSPermission(RoleEGMSPermission roleEGMSPermission)
        {
            throw new NotImplementedException();
        }

        public bool RoleEGMSPermissionExists(int roleId, int permissionId)
        {
            throw new NotImplementedException();
        }

        public Role AddRole(Role role)
        {
            throw new NotImplementedException();
        }

        public bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public bool AgentRelationshipExistsForPrincipal(AgentRelationship agentRelationship, int principalId)
        {
            throw new NotImplementedException();
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
