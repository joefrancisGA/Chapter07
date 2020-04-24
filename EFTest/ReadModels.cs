using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Query.ReadModels;
using Newtonsoft.Json;

namespace EFTest
{
    public class ReadModels
    {
        public static AssociateRM GetAssociateRM(string associate)
        {
            return JsonConvert.DeserializeObject<AssociateRM>(associate);
        }

        public ContactRM GetContactRM(string contact)
        {
            return JsonConvert.DeserializeObject<ContactRM>(contact);
        }

        public ContactConfigurationRM GetContactConfigurationRM(string contactConfiguration)
        {
            return JsonConvert.DeserializeObject<ContactConfigurationRM>(contactConfiguration);
        }

        public UserRM GetUserRM(string user)
        {
            return JsonConvert.DeserializeObject<UserRM>(user);
        }

        public EMailRM GetEMailRM(string email)
        {
            return JsonConvert.DeserializeObject<EMailRM>(email);
        }

        public PhoneRM GetPhoneRM(string phone)
        {
            return JsonConvert.DeserializeObject<PhoneRM>(phone);
        }

        public AddressRM GetAddressRM(string address)
        {
            return JsonConvert.DeserializeObject<AddressRM>(address);
        }

        public AgentRelationshipRM GetAgentRelationshipRM(string agentRelationship)
        {
            return JsonConvert.DeserializeObject<AgentRelationshipRM>(agentRelationship);
        }

        // TO DO:  No real reason other than to just return an ID
        public EGMSPermissionRM GetEGMSPermissionRM(string permission)
        {
            return JsonConvert.DeserializeObject<EGMSPermissionRM>(permission);
        }

        public RoleEGMSPermissionRM GetRoleEGMSPermissionRM(string roleEGMSPermission)
        {
            return JsonConvert.DeserializeObject<RoleEGMSPermissionRM>(roleEGMSPermission);
        }

        public CertificationRM GetCertificationRM(string certification)
        {
            return JsonConvert.DeserializeObject<CertificationRM>(certification);
        }

        public RoleRM GetRoleRM(string role)
        {
            return JsonConvert.DeserializeObject<RoleRM>(role);
        }

        public CustomerRM GetCustomerRM(string customer)
        {
            return JsonConvert.DeserializeObject<CustomerRM>(customer);
        }

        public OperatingContextRM GetOperatingContextRM(string operatingContext)
        {
            return JsonConvert.DeserializeObject<OperatingContextRM>(operatingContext);
        }
    }
}

