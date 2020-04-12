using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.Data.EF
{
    public class BusinessAssociatesContext : DbContext
    {
        public BusinessAssociatesContext() { }
        public BusinessAssociatesContext(DbContextOptions<BusinessAssociatesContext> options) : base(options) { }

        public List<Associate> Associates { get; set; } = new List<Associate>();
        public List<AssociateOperatingContext> AssociateOperatingContexts { get; set; } = new List<AssociateOperatingContext>();
        public List<OperatingContext> OperatingContexts { get; set; } = new List<OperatingContext>();

        // Unhandled lists

        public List<IDMSAccountStatusLookup> IDMSAccountStatuses { get; set; } = new List<IDMSAccountStatusLookup>();
        public List<EGMSAccountStatusLookup> EGMSAccountStatuses { get; set; } = new List<EGMSAccountStatusLookup>();

        public List<AddressTypeLookup> AddressTypes { get; set; } = new List<AddressTypeLookup>();

        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<AgentRelationship> AgentRelationships { get; set; } = new List<AgentRelationship>();
        public List<AgentUser> AgentUsers { get; set; } = new List<AgentUser>();
        public List<AlternateFuelTypeLookup> AlternateFuelTypes { get; set; } = new List<AlternateFuelTypeLookup>();
        public List<AssociateCustomer> AssociateCustomers { get; set; } = new List<AssociateCustomer>();

        public List<AssociateTypeLookup> AssociateTypes { get; set; } = new List<AssociateTypeLookup>();
        public List<AssociateUser> AssociateUsers { get; set; } = new List<AssociateUser>();

        public List<BalancingLevelTypeLookup> BalancingLevelTypes { get; set; } = new List<BalancingLevelTypeLookup>();
        public List<CertificationStatusLookup> CertificationStatuses { get; set; } = new List<CertificationStatusLookup>();
        public List<Certification> Certifications { get; set; } = new List<Certification>();
        public List<ContactConfiguration> ContactConfigurations { get; set; } = new List<ContactConfiguration>();
        public List<ContactTypeLookup> ContactTypes { get; set; } = new List<ContactTypeLookup>();
        public List<Contact> Contacts { get; set; } = new List<Contact>();
        public List<CountryCodeLookup> CountryCodes { get; set; } = new List<CountryCodeLookup>();
        public List<CustomerAlternateFuel> CustomerAlternateFuels { get; set; } = new List<CustomerAlternateFuel>();
        public List<CustomerTypeLookup> CustomerTypes { get; set; } = new List<CustomerTypeLookup>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<DeliveryTypeLookup> DeliveryTypes { get; set; } = new List<DeliveryTypeLookup>();
        public List<EGMSLinkTypeLookup> EGMSLinkTypes { get; set; } = new List<EGMSLinkTypeLookup>();
        public List<EGMSPermission> EGMSPermissions { get; set; } = new List<EGMSPermission>();
        public List<EMail> Emails { get; set; } = new List<EMail>();
        public List<GroupTypeLookup> GroupTypes { get; set; } = new List<GroupTypeLookup>();
        public List<IDMSLinkTypeLookup> IDMSLinkTypes { get; set; } = new List<IDMSLinkTypeLookup>();
        public List<LossTierTypeLookup> LossTierTypes { get; set; } = new List<LossTierTypeLookup>();
        public List<NominationLevelTypeLookup> NominationLevelTypes { get; set; } = new List<NominationLevelTypeLookup>();
        public List<OperatingContextCustomer> OperatingContextCustomers { get; set; } = new List<OperatingContextCustomer>();
        public List<OperatingContextTypeLookup> OperatingContextTypes { get; set; } = new List<OperatingContextTypeLookup>();

        public List<PhoneTypeLookup> PhoneTypes { get; set; } = new List<PhoneTypeLookup>();
        public List<Phone> Phones { get; set; } = new List<Phone>();
        public List<Associate> PredecessorBusinessAssociates { get; set; } = new List<Associate>();
        public List<ProviderTypeLookup> ProviderTypes { get; set; } = new List<ProviderTypeLookup>();
        public List<RoleEGMSPermission> RoleEGMSPermissions { get; set; } = new List<RoleEGMSPermission>();
        public List<Role> Roles { get; set; } = new List<Role>();
        public List<StateCodeLookup> StateCodes { get; set; } = new List<StateCodeLookup>();
        public List<StatusCodeLookup> StatusCodes { get; set; } = new List<StatusCodeLookup>();
        public List<UserContactDisplayRule> UserContactDisplayRules { get; set; } = new List<UserContactDisplayRule>();
        public List<UserOperatingContext> UserOperatingContexts { get; set; } = new List<UserOperatingContext>();
        public List<User> Users { get; set; } = new List<User>();
    }
}
