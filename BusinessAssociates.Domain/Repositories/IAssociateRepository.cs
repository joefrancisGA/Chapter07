using System.Threading.Tasks;


namespace EGMS.BusinessAssociates.Domain.Repositories
{
    public interface IAssociateRepository
    {
        #region Links

        // TO DO:  Links should have an unlink
        void LinkAlternateFuelToCustomer(int alternateFuelId, int customerId);
        
        #endregion Links

        #region Adds

        // TO DO:  Adds should have a corresponding update
        void AddAgentRelationship(AgentRelationship agentRelationship);
        void AddAssociate(Associate associate);
        void AddContact(Contact contact);
        void AddOperatingContext(OperatingContext operatingContext);
        void AddPermission(EGMSPermission permission);
        void AddRole(Role role);
        void AddRoleEGMSPermission(RoleEGMSPermission roleEGMSPermission);

        #endregion

        #region Add and Link

        void AddAddressForAssociate(Address address, int associateId);
        void AddAddressForContact(Address address, int contactId);
        void AddAddressForCustomer(Address address, int customerId);
        void AddCertificationForOperatingContext(Certification certification, int operatingContextId);
        void AddContactForAssociate(Contact contact, int associateId);
        void AddContactConfigurationForContact(ContactConfiguration contactConfiguration, int contactId);
        void AddCustomerForAssociate(Customer customer, int associateId);
        void AddCustomerForOperatingContext(Customer customer, int operatingContextId);
        void AddEMailForAssociate(EMail eMail, int associateId);
        void AddEMailForContact(EMail eMail, int contactId);
        void AddEMailForCustomer(EMail eMail, int customerId);
        void AddOperatingContextForAssociate(OperatingContext operatingContext, int associateId);
        void AddOperatingContextForCustomer(OperatingContext operatingContext, int customerId);
        void AddPhoneForAssociate(Phone phone, int contactId);
        void AddPhoneForContact(Phone phone, int contactId);
        void AddPhoneForCustomer(Phone phone, int customerId);
        void AddUserForAssociate(User user, int associateId);

        #endregion Add and Link

        #region Existence checks

        bool AddressExistsForContact(Address address, int contactId);
        bool AddressExistsForAssociate(Address address, int associateId);
        bool AgentRelationshipExistsForPrincipal(AgentRelationship agentRelationship, int principalId);
        bool AlternateFuelExistsForCustomer(int alternateFuelId, int customerId);

        // TO DO: Probably need to look for other attributes to determine equality 
        bool AssociateExists(int associateId);
        bool CertificationExistsForOperatingContext(Certification certification, int operatingContextId);
        bool ContactConfigurationExistsForContact(ContactConfiguration contactConfiguration, int contactId);
        bool CustomerExistsForAssociate(Customer customer, int associateId);
        bool CustomerExistsForOperatingContext(Customer customer, int operatingContextId);
        bool EMailExistsForContact(EMail eMail, int contactId);
        bool OperatingContextExistsForCustomer(OperatingContext operatingContext, int customerId);
        bool OperatingContextExistsForAssociate(OperatingContext operatingContext, int asociateId);
        bool PermissionExists(string permissionName);
        bool PhoneExistsForContact(Phone phone, int contactId);
        bool RoleEGMSPermissionExists(int roleId, int permissionId);
        bool RoleExists(string roleName);
        bool UserExistsForAssociate(User user, int associateId);
        
        #endregion

        #region Reads

        Address GetAddress(int addressId);
        Associate GetAssociate(int associateId);
        Customer GetCustomer(int customerId);
        OperatingContext GetOperatingContext(int operatingContextId);
        User GetUser(int userId);

        #endregion

        #region Updates

        // TO DO:  Need for updates
        void UpdateAddress(Address address);
        void UpdateOperatingContext(OperatingContext operatingContext);
        

        #endregion
    }
}