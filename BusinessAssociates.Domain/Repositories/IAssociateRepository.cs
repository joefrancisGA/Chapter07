using System.Threading.Tasks;


namespace EGMS.BusinessAssociates.Domain.Repositories
{
    public interface IAssociateRepository
    {
        Task<Associate> LoadAssociate(int id);

        bool AgentRelationshipExistsForPrincipal(AgentRelationship agentRelationship, int principalId);
        Customer AddCustomerForOperatingContext(Customer customer, int operatingContextId);

        bool AlternateFuelExistsForCustomer(int alternateFuelId, int customerId);

        void AddAlternateFuelForCustomer(int alternateFuelId, int customerId);

        Task<OperatingContext> AddOperatingContextForCustomer(OperatingContext operatingContext, int customerId);

        bool OperatingContextExistsForCustomer(OperatingContext operatingContext, int customerId);
        void AddAgentRelationshipForPrincipal(AgentRelationship agentRelationship, int principalId);
        bool CustomerExistsForOperatingContext(Customer customer, int operatingContextId);


        void AddAssociate(Associate entity);

        // No delete for Associate
        //void Delete(Associate entity);
        
        bool AssociateExists(int id);
        bool ContactConfigurationExistsForContact(ContactConfiguration contactConfiguration, int contactId);

        void AddOperatingContext(OperatingContext operatingContext);
        void AddAssociateOperatingContext(Associate associate, OperatingContext operatingContext);

        void AddContactForAssociate(Associate associate, Contact contact);

        bool AddressExistsForContact(Address address, int contactId);

        bool AddAddressForContact(Address address, int contactId);

        void AddContactConfigurationForContact(int contactId, ContactConfiguration contactConfiguration);
    }
}