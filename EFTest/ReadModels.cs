using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Query.ReadModels;
using Newtonsoft.Json;

namespace EFTest
{
    // TO DO:  Eliminate this class and create direct calls
    public class ReadModels
    {
        public static AssociateRM GetAssociateRM(string associate)
        {
            return JsonConvert.DeserializeObject<AssociateRM>(associate);
        }

        public static ContactRM GetContactRM(string contact)
        {
            return JsonConvert.DeserializeObject<ContactRM>(contact);
        }

        public static ContactConfigurationRM GetContactConfigurationRM(string contactConfiguration)
        {
            return JsonConvert.DeserializeObject<ContactConfigurationRM>(contactConfiguration);
        }

        public static UserRM GetUserRM(string user)
        {
            return JsonConvert.DeserializeObject<UserRM>(user);
        }

        public static EMailRM GetEMailRM(string email)
        {
            return JsonConvert.DeserializeObject<EMailRM>(email);
        }

        public static PhoneRM GetPhoneRM(string phone)
        {
            return JsonConvert.DeserializeObject<PhoneRM>(phone);
        }

        public static AddressRM GetAddressRM(string address)
        {
            return JsonConvert.DeserializeObject<AddressRM>(address);
        }

        public static AgentRelationshipRM GetAgentRelationshipRM(string agentRelationship)
        {
            return JsonConvert.DeserializeObject<AgentRelationshipRM>(agentRelationship);
        }

        // TO DO:  No real reason other than to just return an ID
        public static EGMSPermissionRM GetEGMSPermissionRM(string permission)
        {
            return JsonConvert.DeserializeObject<EGMSPermissionRM>(permission);
        }

        public static RoleEGMSPermissionRM GetRoleEGMSPermissionRM(string roleEGMSPermission)
        {
            return JsonConvert.DeserializeObject<RoleEGMSPermissionRM>(roleEGMSPermission);
        }

        public static CertificationRM GetCertificationRM(string certification)
        {
            return JsonConvert.DeserializeObject<CertificationRM>(certification);
        }

        public static RoleRM GetRoleRM(string role)
        {
            return JsonConvert.DeserializeObject<RoleRM>(role);
        }

        public static CustomerRM GetCustomerRM(string customer)
        {
            return JsonConvert.DeserializeObject<CustomerRM>(customer);
        }

        public static OperatingContextRM GetOperatingContextRM(string operatingContext)
        {
            return JsonConvert.DeserializeObject<OperatingContextRM>(operatingContext);
        }
    }
}

