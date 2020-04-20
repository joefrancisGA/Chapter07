using System.Threading.Tasks;


namespace EGMS.BusinessAssociates.Domain.Repositories
{
    public interface IAssociateRepository
    {
        #region Adds

        void AddAddressForContact(Address address, int contactId);
        void AddAddressForOperatingContext(Address address, int operatingContextId);
        void AddAgentRelationship(AgentRelationship agentRelationship);
        void AddAlternateFuelForCustomer(int alternateFuelId, int customerId);
        void AddAssociate(Associate associate);
        void AddCertificationForOperatingContext(Certification certification, int operatingContextId);
        void AddContact(Contact contact);
        void AddContactConfigurationForContact(int contactId, ContactConfiguration contactConfiguration);
        void AddCustomerForAssociate(Customer customer, int associateId);
        Customer AddCustomerForOperatingContext(Customer customer, int operatingContextId);
        EMail AddEMailForContact(EMail eMail, int contactId);
        void AddOperatingContext(OperatingContext operatingContext);
        void AddOperatingContextForAssociate(OperatingContext operatingContext, int associateId);
        void AddOperatingContextForCustomer(OperatingContext operatingContext, int customerId);
        void AddPermission(EGMSPermission permission);
        Phone AddPhoneForContact(Phone phone, int contactId);
        Role AddRole(Role role);
        void AddRoleEGMSPermission(RoleEGMSPermission roleEGMSPermission);
        User AddUserForAssociate(User user, int associateId);

        #endregion

        #region Existence checks

        bool AddressExistsForContact(Address address, int contactId);
        bool AddressExistsForOperatingContext(Address address, int operatingContextId);
        bool AgentRelationshipExistsForPrincipal(AgentRelationship agentRelationship, int principalId);
        bool AlternateFuelExistsForCustomer(int alternateFuelId, int customerId);
        bool AssociateExists(int id);
        bool CertificationExistsForOperatingContext(Certification certification, int operatingContextId);
        bool ContactConfigurationExistsForContact(ContactConfiguration contactConfiguration, int contactId);
        bool CustomerExistsForAssociate(Customer customer, int associateId);
        bool CustomerExistsForOperatingContext(Customer customer, int operatingContextId);
        bool EMailExistsForContact(EMail eMail, int contactId);
        bool OperatingContextExistsForCustomer(OperatingContext operatingContext, int customerId);
        bool PermissionExists(string permissionName);
        bool PhoneExistsForContact(Phone phone, int contactId);
        bool RoleEGMSPermissionExists(int roleId, int permissionId);
        bool RoleExists(string roleName);
        bool UserExistsForAssociate(User user, int associateId);
        
        #endregion

        #region Reads

        Address GetAddress(int addressId);
        Associate GetAssociate(int associateId);
        OperatingContext GetOperatingContext(int operatingContextId);

        #endregion

        #region Updates

        void UpdateAddress(Address address);
        void UpdateOperatingContext(OperatingContext operatingContext);
        

        #endregion
    }
}