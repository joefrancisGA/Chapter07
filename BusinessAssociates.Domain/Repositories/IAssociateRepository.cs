using System.Threading.Tasks;


namespace EGMS.BusinessAssociates.Domain.Repositories
{
    public interface IAssociateRepository
    {
        void UpdateAddress(Address address);
        Task<Associate> LoadAssociate(int associateId);
        Address LoadAddress(int addressId);
        void UpdateOperatingContext(OperatingContext operatingContext);
        OperatingContext LoadOperatingContext(int operatingContextId);
        Phone AddPhoneForContact(Phone phone, int contactId);
        bool PhoneExistsForContact(Phone phone, int contactId);
        Certification AddCertificationForOperatingContext(Certification certification, int operatingContextId);
        bool CertificationExistsForOperatingContext(Certification certification, int operatingContextId);
        EMail AddEMailForContact(EMail eMail, int contactId);
        bool EMailExistsForContact(EMail eMail, int contactId);
        User AddUserForAssociate(User user, int associateId);
        bool UserExistsForAssociate(User user, int associateId);
        RoleEGMSPermission AddRoleEGMSPermission(RoleEGMSPermission roleEGMSPermission);
        bool RoleEGMSPermissionExists(int roleId, int permissionId);
        Role AddRole(Role role);
        bool RoleExists(string roleName);
        bool AgentRelationshipExistsForPrincipal(AgentRelationship agentRelationship, int principalId);
        Customer AddCustomerForOperatingContext(Customer customer, int operatingContextId);
        bool PermissionExists(string permissionName);
        void AddPermission(EGMSPermission permission);
        bool AddressExistsForOperatingContext(Address address, int operatingContextId);
        Address AddAddressForOperatingContext(Address address, int operatingContextId);

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