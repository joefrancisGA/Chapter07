using EGMS.BusinessAssociates.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EGMS.BusinessAssociates.Data.EF
{
    public class BusinessAssociatesContext : DbContext
    {
        public BusinessAssociatesContext() { }
        public BusinessAssociatesContext(DbContextOptions<BusinessAssociatesContext> options) : base(options) { }

        // Entities
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Associate> Associates { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<OperatingContext> OperatingContexts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public List<EGMSPermission> EGMSPermissions { get; set; } = new List<EGMSPermission>();
        public DbSet<EMail> EMails { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }


        // Links
        public DbSet<AgentRelationship> AgentRelationships { get; set; }
        public List<AssociateContact> AssociateContacts { get; set; } = new List<AssociateContact>();
        public List<AssociateCustomer> AssociateCustomers { get; set; } = new List<AssociateCustomer>();
        public List<AssociateOperatingContext> AssociateOperatingContexts { get; set; } = new List<AssociateOperatingContext>();
        public List<AssociateUser> AssociateUsers { get; set; } = new List<AssociateUser>();
        public List<AssociateEMail> AssociateEMails { get; set; } = new List<AssociateEMail>();
        public List<AssociatePhone> AssociatePhones { get; set; } = new List<AssociatePhone>();
        public List<AssociateAddress> AssociateAddresses { get; set; } = new List<AssociateAddress>();
        public List<ContactAddress> ContactAddresses { get; set; } = new List<ContactAddress>();
        public List<ContactEMail> ContactEMails { get; set; } = new List<ContactEMail>();
        public List<ContactPhone> ContactPhones { get; set; } = new List<ContactPhone>();
        public List<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();
        public List<CustomerEMail> CustomerEMails { get; set; } = new List<CustomerEMail>();
        public List<CustomerPhone> CustomerPhones { get; set; } = new List<CustomerPhone>();
        public List<CustomerAlternateFuel> CustomerAlternateFuels { get; set; } = new List<CustomerAlternateFuel>();
        public List<RoleEGMSPermission> RoleEGMSPermissions { get; set; } = new List<RoleEGMSPermission>();
        public List<OperatingContextCustomer> OperatingContextCustomers { get; set; } = new List<OperatingContextCustomer>();


        // UnhandledLists
        // TO DO:  The first release should include support for the first three lists
        public List<AgentUser> AgentUsers { get; set; } = new List<AgentUser>();
        public List<Certification> Certifications { get; set; } = new List<Certification>();
        public DbSet<ContactConfiguration> ContactConfigurations { get; set; }

        // TO DO:  Not important until Lifecycle release
        public List<Associate> PredecessorBusinessAssociates { get; set; } = new List<Associate>();

        // TO DO:  Just seed this ahead of time
        public List<UserContactDisplayRule> UserContactDisplayRules { get; set; } = new List<UserContactDisplayRule>();



        // Enumerations

        //public List<AddressTypeLookup> AddressTypes { get; set; } = new List<AddressTypeLookup>();
        //public List<AlternateFuelTypeLookup> AlternateFuelTypes { get; set; } = new List<AlternateFuelTypeLookup>();
        //public List<AssociateTypeLookup> AssociateTypes { get; set; } = new List<AssociateTypeLookup>();
        //public List<BalancingLevelTypeLookup> BalancingLevelTypes { get; set; } = new List<BalancingLevelTypeLookup>();
        //public List<CertificationStatusLookup> CertificationStatuses { get; set; } = new List<CertificationStatusLookup>();
        //public List<ContactTypeLookup> ContactTypes { get; set; } = new List<ContactTypeLookup>();
        //public List<CountryCodeLookup> CountryCodes { get; set; } = new List<CountryCodeLookup>();
        //public List<CustomerTypeLookup> CustomerTypes { get; set; } = new List<CustomerTypeLookup>();
        //public List<DeliveryTypeLookup> DeliveryTypes { get; set; } = new List<DeliveryTypeLookup>();
        //public List<EGMSAccountStatusLookup> EGMSAccountStatuses { get; set; } = new List<EGMSAccountStatusLookup>();
        //public List<EGMSLinkTypeLookup> EGMSLinkTypes { get; set; } = new List<EGMSLinkTypeLookup>();
        //public List<GroupTypeLookup> GroupTypes { get; set; } = new List<GroupTypeLookup>();
        //public List<IDMSAccountStatusLookup> IDMSAccountStatuses { get; set; } = new List<IDMSAccountStatusLookup>();
        //public List<IDMSLinkTypeLookup> IDMSLinkTypes { get; set; } = new List<IDMSLinkTypeLookup>();
        //public List<LossTierTypeLookup> LossTierTypes { get; set; } = new List<LossTierTypeLookup>();
        //public List<NominationLevelTypeLookup> NominationLevelTypes { get; set; } = new List<NominationLevelTypeLookup>();
        //public List<OperatingContextTypeLookup> OperatingContextTypes { get; set; } = new List<OperatingContextTypeLookup>();
        //public List<PhoneTypeLookup> PhoneTypes { get; set; } = new List<PhoneTypeLookup>();
        //public List<ProviderTypeLookup> ProviderTypes { get; set; } = new List<ProviderTypeLookup>();
        //public List<StateCodeLookup> StateCodes { get; set; } = new List<StateCodeLookup>();
        //public List<StatusCodeLookup> StatusCodes { get; set; } = new List<StatusCodeLookup>();
    }
}
