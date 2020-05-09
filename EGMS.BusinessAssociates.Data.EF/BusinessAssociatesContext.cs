    using EGMS.BusinessAssociates.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
    using System.Linq.Expressions;
    using EGMS.BusinessAssociates.Domain.Enums;

    namespace EGMS.BusinessAssociates.Data.EF
{
    public class BusinessAssociatesContext : DbContext
    {
        public BusinessAssociatesContext() { }
        public BusinessAssociatesContext(DbContextOptions<BusinessAssociatesContext> options) : base(options) { }

        // Entities
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Associate> Associates { get; set; } = new List<Associate>();
        public List<Contact> Contacts { get; set; } = new List<Contact>();
        public List<OperatingContext> OperatingContexts { get; set; } = new List<OperatingContext>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<EGMSPermission> EGMSPermissions { get; set; } = new List<EGMSPermission>();
        public List<EMail> EMails { get; set; } = new List<EMail>();
        public List<Phone> Phones { get; set; } = new List<Phone>();
        public List<Role> Roles { get; set; } = new List<Role>();
        public List<User> Users { get; set; } = new List<User>();


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
        public List<CustomerAlternateFuel> CustomerAlternateFuels { get; set; } = new List<CustomerAlternateFuel>();
        public List<CustomerEMail> CustomerEMails { get; set; } = new List<CustomerEMail>();
        public List<CustomerPhone> CustomerPhones { get; set; } = new List<CustomerPhone>();
        public List<CustomerOperatingContext> CustomerOperatingContexts { get; set; } =
            new List<CustomerOperatingContext>();
        public DbSet<RoleEGMSPermission> RoleEGMSPermissions { get; set; }
        public List<OperatingContextCustomer> OperatingContextCustomers { get; set; } = new List<OperatingContextCustomer>();
        public List<OperatingContextRole> OperatingContextRoles { get; set; } = new List<OperatingContextRole>();


        // UnhandledLists
        // TO DO:  The first release should include support for the first three lists
        public List<AgentUser> AgentUsers { get; set; } = new List<AgentUser>();
        public DbSet<Certification> Certifications { get; set; }
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            //modelBuilder.Entity<IDMSAccountStatusLookup>(entity =>
            //{
            //    // ValueGeneratedNever is presumed for lookup tables
            //    entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
            //    entity.OwnsOne(x => x.Desc, cb => { cb.Property(e => e.Value).HasColumnName("IDMSAccountStatusDescription"); });
            //    entity.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("IDMSAccountStatusName"); });
            //});

            //modelBuilder.Entity<EGMSAccountStatusLookup>(entity =>
            //{
            //    // ValueGeneratedNever is presumed for lookup tables
            //    entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
            //    entity.OwnsOne(x => x.Desc, cb => { cb.Property(e => e.Value).HasColumnName("EGMSAccountStatusDescription"); });
            //    entity.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("EGMSAccountStatusName"); });
            //});

            modelBuilder.Entity<AddressTypeLookup>(entity =>
            {
                entity.HasKey(e => e.Id);
                //entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(x => x.Desc).HasColumnName("AddressTypeDescription");
                entity.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("AddressTypeName"); });
            });

            modelBuilder.Entity<Address>(entity =>
            {
                //entity.HasKey(e => e.Id)

                entity.OwnsOne(x => x.Address1, cb => { cb.Property(e => e.Value).HasColumnName("Address1"); });
                entity.OwnsOne(x => x.Address2, cb => { cb.Property(e => e.Value).HasColumnName("Address2"); });
                entity.OwnsOne(x => x.Address3, cb => { cb.Property(e => e.Value).HasColumnName("Address3"); });
                entity.OwnsOne(x => x.Address4, cb => { cb.Property(e => e.Value).HasColumnName("Address4"); });
                entity.OwnsOne(x => x.Attention, cb => { cb.Property(e => e.Value).HasColumnName("Attention"); });
                entity.OwnsOne(x => x.City, cb => { cb.Property(e => e.Value).HasColumnName("City"); });
                entity.Property(x => x.Comments).HasColumnName("Comments");
                entity.OwnsOne(x => x.PostalCode, cb => { cb.Property(e => e.Value).HasColumnName("PostalCode"); });
                entity.Property(e => e.EndDate).HasColumnType("datetime");
                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.HasOne(d => d.AddressType).WithMany(p => p.Addresses).HasForeignKey(d => d.AddressTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Addresses_AddressTypes");
                entity.HasOne(d => d.StateCode).WithMany(p => p.Addresses).HasForeignKey(d => d.StateCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Addresses_StateCodes");
            });

            modelBuilder.Entity<AgentRelationship>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.AgentId).HasColumnName("AgentID");
                entity.Property(e => e.EndDate).HasColumnType("datetime");
                entity.Property(e => e.PrincipalId).HasColumnName("PrincipalID");
                entity.Property(e => e.StartDate).HasColumnType("datetime");

                // TO DO:  Fix this in the database
                //entity.HasOne(d => d.Agent)
                //    .WithMany(p => p AgentRelationshipsAgent)
                //    .HasForeignKey(d => d.AgentId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_AgentRelationships_Agent");

                //entity.HasOne(d => d.Principal)
                //    .WithMany(p => p.AgentRelationshipsPrincipal)
                //    .HasForeignKey(d => d.PrincipalId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_AgentRelationships_Principal");
            });

            modelBuilder.Entity<AgentUser>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.AgentId).HasColumnName("AgentID");
                //entity.OwnsOne(x => x.UserId, cb => { cb.Property(e => e.Value).HasColumnName("UserId"); });
                entity.Property(e => e.UserId).HasColumnName("UserID");
                entity.HasOne(d => d.Agent).WithMany(p => p.AgentUsers).HasForeignKey(d => d.AgentId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AgentUser_Agent");
                entity.HasOne(d => d.User).WithMany(p => p.AgentUsers).HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AgentUser_User");
            });

            modelBuilder.Entity<AlternateFuelTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasColumnName("AlternateFuelTypeDescription");
                entity.OwnsOne(e => e.Name, cb => { cb.Property(e => e.Value).HasColumnName("AlternateFuelTypeName"); });
            });

            modelBuilder.Entity<AssociateCustomer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ServiceEndDate).HasColumnType("datetime");
                entity.Property(e => e.ServiceStartDate).HasColumnType("datetime");
                entity.HasOne(d => d.Associate).WithMany(p => p.AssociateCustomers).HasForeignKey(d => d.AssociateId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AssociateCustomers_Associate");
                entity.HasOne(d => d.Customer).WithMany(p => p.AssociateCustomers).HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AssociateCustomers_Customer");
            });

            modelBuilder.Entity<AssociateOperatingContext>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.HasOne(d => d.Associate).WithMany(p => p.AssociateOperatingContexts).HasForeignKey(d => d.AssociateId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AssociateOperatingContexts_Associate");
                entity.HasOne(d => d.OperatingContext).WithMany(p => p.AssociateOperatingContexts).HasForeignKey(d => d.OperatingContextId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AssociateOperatingContexts_OperatingContexts");
            });

            //modelBuilder.Entity<AssociateTypeLookup>(entity =>
            //{
            //    entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
            //    entity.OwnsOne(x => x.Desc, cb => { cb.Property(e => e.Value).HasColumnName("AssociateTypeDescription"); });
            //    entity.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("AssociateTypeName"); });
            //});

            modelBuilder.Entity<AssociateUser>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.HasOne(d => d.Associate).WithMany(p => p.AssociateUsers).HasForeignKey(d => d.AssociateId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AssociateUsers_Associate");
                entity.HasOne(d => d.User).WithMany(p => p.AssociateUsers).HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AssociateUsers_User");
            });

            modelBuilder.Ignore<AssociateTypeLookup>();
            modelBuilder.Ignore<StatusCodeLookup>();

            modelBuilder.Entity<Associate>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.OwnsOne(x => x.DUNSNumber, cb => { cb.Property(e => e.Value).HasColumnName("DUNSNumber"); });
                entity.OwnsOne(x => x.LongName, cb => { cb.Property(e => e.Value).HasColumnName("LongName"); });
                entity.OwnsOne(x => x.ShortName, cb => { cb.Property(e => e.Value).HasColumnName("ShortName"); });

                //entity.OwnsOne(x => x.AssociateType,
                //    cb =>
                //    {
                //        cb.Property(e => e.Id).HasColumnName("ID");
                //        cb.Ignore(e => e.Name);
                //        cb.Ignore(e => e.Desc);
                //    });

                //entity.HasOne(d => d.AssociateType).WithMany(p => p.Associates).HasForeignKey(d => d.AssociateTypeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Associate_AssociateTypes");
                //entity.HasOne(d => d.Status).WithMany(p => p.Associates).HasForeignKey(d => d.StatusCodeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Associate_StatusCodes");
                //entity.HasOne(d => d.PredecessorBusinessAssociates).WithMany(p => p.Associates).HasForeignKey(d => d.StatusCodeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Associate_StatusCodes");
            });

            modelBuilder.Entity<BalancingLevelTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasColumnName("BalancingLevelTypeDescription");
                entity.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("BalancingLevelTypeName"); });
            });

            modelBuilder.Entity<CertificationStatusLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasColumnName("CertificationStatusDescription");
                entity.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("CertificationStatusName"); });
            });

            modelBuilder.Entity<Certification>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.CertificationDateTime).HasColumnType("datetime");
                entity.Property(e => e.DecertificationDateTime).HasColumnType("datetime");
                entity.HasOne(d => d.CertificationStatus).WithMany(p => p.Certifications).HasForeignKey(d => d.CertificationStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Certifications_CertificationStatuses");
            });

            modelBuilder.Entity<ContactConfiguration>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.EndDate).HasColumnType("datetime");
                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.OwnsOne(x => x.Priority, cb => { cb.Property(e => e.Value).HasColumnName("ContactPriority"); });
                entity.OwnsOne(x => x.FacilityId, cb => { cb.Property(e => e.Value).HasColumnName("FacilityId"); });
                entity.HasOne(d => d.Contact).WithMany(p => p.ContactConfigurations).HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ContactConfigurations_Contacts");
                entity.HasOne(d => d.ContactType).WithMany(p => p.ContactConfigurations).HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ContactConfigurations_ContactTypes");
                entity.HasOne(d => d.Status).WithMany(p => p.ContactConfigurations).HasForeignKey(d => d.StatusCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ContactConfigurations_StatusCodes");
            });

            modelBuilder.Entity<ContactTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasColumnName("ContactTypeDescription");
                entity.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("ContactTypeName"); });
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.OwnsOne(x => x.FirstName, cb => { cb.Property(e => e.Value).HasColumnName("FirstName"); });
                entity.OwnsOne(x => x.LastName, cb => { cb.Property(e => e.Value).HasColumnName("LastName"); });
                entity.OwnsOne(x => x.Title, cb => { cb.Property(e => e.Value).HasColumnName("Title"); });
            });

            modelBuilder.Entity<CountryCodeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasColumnName("CountryCodeDescription");
                entity.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("CountryCodeName"); });
            });


            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.OwnsOne(x => x.AccountNumber, cb => { cb.Property(e => e.Value).HasColumnName("AccountNumber"); });
                entity.OwnsOne(x => x.AlternateCustomerId, cb => { cb.Property(e => e.Value).HasColumnName("AlternateCustomerId"); });
                entity.OwnsOne(x => x.BasicPoolId, cb => { cb.Property(e => e.Value).HasColumnName("BasicPoolId"); });
                entity.OwnsOne(x => x.ContractTypeId, cb => { cb.Property(e => e.Value).HasColumnName("ContactTypeId"); });
                entity.OwnsOne(x => x.CurrentDemand, cb => { cb.Property(e => e.Value).HasColumnName("CurrentDemand"); });
                entity.OwnsOne(x => x.DailyInterruptible, cb => { cb.Property(e => e.Value).HasColumnName("DailyInterruptible"); });
                entity.OwnsOne(x => x.DeliveryLocation, cb => { cb.Property(e => e.Value).HasColumnName("DeliveryLocation"); });
                entity.OwnsOne(x => x.DeliveryPressure, cb => { cb.Property(e => e.Value).HasColumnName("DeliveryPressure"); });
                entity.OwnsOne(x => x.DUNSNumber, cb => { cb.Property(e => e.Value).HasColumnName("DUNSNumber"); });
                entity.OwnsOne(x => x.HourlyInterruptible, cb => { cb.Property(e => e.Value).HasColumnName("HourlyInterruptible"); });
                entity.OwnsOne(x => x.InterstateSpecifiedFirm, cb => { cb.Property(e => e.Value).HasColumnName("InterstateSpecifiedFirm"); });
                entity.OwnsOne(x => x.IntrastateSpecifiedFirm, cb => { cb.Property(e => e.Value).HasColumnName("IntrastateSpecifiedFirm"); });
                entity.OwnsOne(x => x.LDCId, cb => { cb.Property(e => e.Value).HasColumnName("LDCId"); });
                entity.OwnsOne(x => x.LongName, cb => { cb.Property(e => e.Value).HasColumnName("LongName"); });
                entity.OwnsOne(x => x.MaxDailyInterruptible, cb => { cb.Property(e => e.Value).HasColumnName("MaxDailyInterruptible"); });
                entity.OwnsOne(x => x.MaxHourlyInterruptible, cb => { cb.Property(e => e.Value).HasColumnName("MaxHourlyInterruptible"); });
                entity.OwnsOne(x => x.MaxHourlySpecifiedFirm, cb => { cb.Property(e => e.Value).HasColumnName("MaxHourlySpecifiedFirm"); });
                entity.OwnsOne(x => x.MDQ, cb => { cb.Property(e => e.Value).HasColumnName("MDQ"); });
                entity.OwnsOne(x => x.NAICSCode, cb => { cb.Property(e => e.Value).HasColumnName("NAICSCode"); });
                entity.OwnsOne(x => x.PreviousDemand, cb => { cb.Property(e => e.Value).HasColumnName("PreviousDemand"); });

                entity.Property(e => e.ShippersLetterFromDate).HasColumnType("datetime");
                entity.OwnsOne(x => x.ShortName, cb => { cb.Property(e => e.Value).HasColumnName("ShortName"); });
                entity.OwnsOne(x => x.SICCode, cb => { cb.Property(e => e.Value).HasColumnName("SICCode"); });
                entity.OwnsOne(x => x.SICCodePercentage, cb => { cb.Property(e => e.Value).HasColumnName("SICCodePercentage"); });
                entity.Property(e => e.SS1).HasColumnName("SS1");
                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.OwnsOne(x => x.TotalDailySpecifiedFirm, cb => { cb.Property(e => e.Value).HasColumnName("TotalDailySpecifiedFirm"); });
                entity.OwnsOne(x => x.TotalHourlySpecifiedFirm, cb => { cb.Property(e => e.Value).HasColumnName("TotalHourlySpecifiedFirm"); });

                entity.Property(e => e.TurnOffDate).HasColumnType("datetime");
                entity.Property(e => e.TurnOnDate).HasColumnType("datetime");

                entity.HasOne(d => d.BalancingLevel).WithMany(p => p.Customers).HasForeignKey(d => d.BalancingLevelId)
                    .HasConstraintName("FK_Customers_BalancingLevelTypes");
                entity.HasOne(d => d.CustomerType).WithMany(p => p.Customers).HasForeignKey(d => d.CustomerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Customers_CustomerTypes");
                entity.HasOne(d => d.DeliveryType).WithMany(p => p.Customers).HasForeignKey(d => d.DeliveryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Customers_DeliveryTypes");
                entity.HasOne(d => d.GroupType).WithMany(p => p.Customers).HasForeignKey(d => d.GroupTypeId)
                    .HasConstraintName("FK_Customers_GroupTypes");
                entity.HasOne(d => d.LossTier).WithMany(p => p.Customers).HasForeignKey(d => d.LossTierId)
                    .HasConstraintName("FK_Customers_LossTierTypes");
                entity.HasOne(d => d.NominationLevel).WithMany(p => p.Customers).HasForeignKey(d => d.NominationLevelId)
                    .HasConstraintName("FK_Customers_NominationLevelTypes");
                entity.HasOne(d => d.Shipper).WithMany(p => p.Customers).HasForeignKey(d => d.ShipperId)
                    .HasConstraintName("FK_Customers_Shippers");
                entity.HasOne(d => d.StatusCode).WithMany(p => p.Customers).HasForeignKey(d => d.StatusCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Customers_StatusCodes");
            });

            modelBuilder.Entity<CustomerAlternateFuel>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.HasOne(d => d.AlternateFuel).WithMany(p => p.CustomerAlternateFuels).HasForeignKey(d => d.AlternateFuelTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CustomerAlternateFuels_AlternateFuelTypes");
                entity.HasOne(d => d.Customer).WithMany(p => p.CustomerAlternateFuels).HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CustomerAlternateFuels_Customers");
            });

            modelBuilder.Entity<CustomerTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(x => x.Desc).HasColumnName("CustomerTypeDescription");
                entity.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("CustomerTypeName"); });
            });

            modelBuilder.Entity<DeliveryTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(x => x.Desc).HasColumnName("CustomerTypeDescription");
                entity.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("CustomerTypeName"); });
            });

            //modelBuilder.Entity<EGMSLinkTypeLookup>(entity =>
            //{
            //    entity.ToTable("EGMSLinkTypes");
            //    entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
            //    entity.OwnsOne(x => x.Desc, cb => { cb.Property(e => e.Value).HasColumnName("EGMSLinkTypeDescription"); });
            //    entity.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("EGMSLinkTypeName"); });
            //});

            modelBuilder.Entity<EGMSPermission>(entity =>
            {
                entity.ToTable("EGMSPermissions");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.OwnsOne(x => x.PermissionDescription, cb => { cb.Property(e => e.Value).HasColumnName("PermissionDescription"); });
                entity.OwnsOne(x => x.PermissionName, cb => { cb.Property(e => e.Value).HasColumnName("PermissionName"); });
            });

            modelBuilder.Entity<EMail>(entity =>
            {
                entity.ToTable("EMails");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.OwnsOne(x => x.EMailAddress, cb => { cb.Property(e => e.Value).HasColumnName("EMailAddress"); });
                entity.HasOne(d => d.Contact).WithMany(p => p.Emails).HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EMails_Contacts");
            });

            modelBuilder.Entity<GroupTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(x => x.Desc).HasColumnName("GroupTypeDescription");
                entity.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("GroupTypeName"); });
            });

            //modelBuilder.Entity<IDMSLinkTypeLookup>(entity =>
            //{
            //    entity.ToTable("IDMSLinkTypes");
            //    entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
            //    entity.OwnsOne(x => x.Desc, cb => { cb.Property(e => e.Value).HasColumnName("IDMLinkTypeDescription"); });
            //    entity.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("IDMSLinkTypeName"); });
            //});

            modelBuilder.Entity<LossTierTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(x => x.Desc).HasColumnName("LossTierDescription");
                entity.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("LossTierName"); });
            });

            modelBuilder.Entity<NominationLevelTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(x => x.Desc).HasColumnName("NominationLevelDescription");
                entity.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("NominationLevelName"); });
            });

            modelBuilder.Entity<OperatingContextCustomer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.HasOne(d => d.Customer).WithMany(p => p.OperatingContextCustomers).HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_OperatingContextCustomers_Customers");
                entity.HasOne(d => d.OperatingContext).WithMany(p => p.OperatingContextCustomers).HasForeignKey(d => d.OperatingContextId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_OperatingContextCustomers_OperatingContexts");
            });

            modelBuilder.Entity<OperatingContextTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(x => x.Desc).HasColumnName("OperatingContextTypeDescription");
                entity.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("OperatingContextTypeName"); });
            });

            modelBuilder.Entity<OperatingContext>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.PrimaryEmailId).HasColumnName("PrimaryEMailId");
                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.OwnsOne(x => x.FacilityId, cb => { cb.Property(e => e.Value).HasColumnName("FacilityId"); });

                entity.OwnsOne(x => x.ExternalBAType,
                    cb =>
                    {
                        cb.Property(e => e.Id).HasColumnName("ExternalBATypeId");
                        cb.Ignore(e => e.Name);
                        cb.Ignore(e => e.Desc);
                    });

                //entity.HasOne(d => d.ExternalBAType).WithMany(p1 => p1.OperatingContexts).HasForeignKey(d => d.ActingBATypeId)
                //    .HasConstraintName("FK_OperatingContexts_ActingBAType");
                entity.OwnsOne(x => x.CertificationId, cb => { cb.Property(e => e.Value).HasColumnName("CertificationId"); });
                entity.HasOne(d => d.OperatingContextType).WithMany(p3 => p3.OperatingContexts).HasForeignKey(d => d.OperatingContextTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_OperatingContexts_OperatingContextTypes");
                entity.HasOne(d => d.PrimaryAddress).WithMany(p4 => p4.OperatingContexts).HasForeignKey(d => d.PrimaryAddressId)
                    .HasConstraintName("FK_OperatingContexts_PrimaryAddress");
                entity.HasOne(d => d.PrimaryEmail).WithMany(p5 => p5.OperatingContexts).HasForeignKey(d => d.PrimaryEmailId)
                    .HasConstraintName("FK_OperatingContexts_PrimaryEmail");
                entity.HasOne(d => d.PrimaryPhone).WithMany(p6 => p6.OperatingContexts).HasForeignKey(d => d.PrimaryPhoneId)
                    .HasConstraintName("FK_OperatingContexts_PrimaryPhone");
                entity.HasOne(d => d.ProviderType).WithMany(p7 => p7.OperatingContexts).HasForeignKey(d => d.ProviderTypeId)
                    .HasConstraintName("FK_OperatingContexts_ProviderTypes");
                entity.HasOne(d => d.Role).WithMany(p8 => p8.OperatingContexts).HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_OperatingContexts_Roles");
                entity.HasOne(d => d.Status).WithMany(p9 => p9.OperatingContexts).HasForeignKey(d => d.StatusCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_OperatingContexts_StatusCodes");
                entity.HasOne(d => d.ThirdPartySupplier).WithMany(p10 => p10.OperatingContexts).HasForeignKey(d => d.ThirdPartySupplierId)
                    .HasConstraintName("FK_OperatingContexts_ThirdPartySupplier");
            });

            modelBuilder.Entity<PhoneTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(x => x.Desc).HasColumnName("PhoneTypeDescription");
                entity.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("PhoneTypeName"); });
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.OwnsOne(x => x.Extension, cb => { cb.Property(e => e.Value).HasColumnName("Extension"); });
                //entity.OwnsOne(x => x.UserId, cb => { cb.Property(e => e.Value).HasColumnName("UserId"); });
                entity.HasOne(d => d.Contact).WithMany(p => p.Phones).HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Phones_Contacts");
                entity.HasOne(d => d.PhoneType).WithMany(p => p.Phones).HasForeignKey(d => d.PhoneTypeId).OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Phones_PhoneTypes");
            });

            modelBuilder.Entity<ProviderTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasColumnName("ProviderTypeDescription");
                entity.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("ProviderTypeName"); });
            });

            modelBuilder.Entity<RoleEGMSPermission>(entity =>
            {
                entity.HasKey(e => e.Id);

                // TO DO:  Eliminate this in the database
                //entity.Property(e => e.EGMSPermissionId).HasColumnName("EGMSPermissionId");

                //entity.HasOne(d => d.Egmspermission)
                //    .WithMany(p => p.RoleEgmspermissions)
                //    .HasForeignKey(d => d.EgmspermissionId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_RoleEGMSPermissions_EGMSPermissions");

                entity.HasOne(d => d.Role).WithMany(p => p.RoleEGMSPermissions).HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_RoleEGMSPermissions_Roles");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.OwnsOne(x => x.RoleDescription, cb => { cb.Property(e => e.Value).HasColumnName("RoleDescription"); });
                entity.OwnsOne(x => x.RoleName, cb => { cb.Property(e => e.Value).HasColumnName("RoleName"); });
            });

            modelBuilder.Entity<StateCodeLookup>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Desc).HasColumnName("StateCodeDescription");
                entity.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("StateCodeName"); });
                entity.HasOne(d => d.CountryCode).WithMany(p => p.StateCodes).HasForeignKey(d => d.CountryCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_StateCodes_CountryCodes");
            });

            modelBuilder.Entity<StatusCodeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(x => x.Desc).HasColumnName("StatusCodeDescription");
                entity.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("StatusCodeName"); });
            });

            modelBuilder.Entity<UserContactDisplayRule>(entity =>
            {
                entity.HasKey(e => e.Id);

                var ownedEGMSAccountStatus = entity.OwnsOne(e => e.EGMSAccountStatus);
                ownedEGMSAccountStatus.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                ownedEGMSAccountStatus.Property(e => e.Desc).HasColumnName("AccountStatusDescription");
                ownedEGMSAccountStatus.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("AccountStatusName"); });

                var ownedIDMSAccountStatus = entity.OwnsOne(x => x.IDMSAccountStatus);
                ownedIDMSAccountStatus.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                ownedIDMSAccountStatus.Property(e => e.Desc).HasColumnName("AccountStatusDescription");
                ownedIDMSAccountStatus.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("AccountStatusName"); });

                entity.Property(e => e.EGMSConfigured).HasColumnName("EGMSConfigured");
                entity.Property(e => e.IDMSAccountExists).HasColumnName("IDMSAccountExists");
                //entity.OwnsOne(x => x.IDMSAccountStatus, cb => { cb.Property(e => e.AccountStatusId).HasColumnName("IDMSAccountStatus"); });

                var ownedEGMSLinkType = entity.OwnsOne(x => x.EGMSLinkType);
                ownedEGMSLinkType.ToTable("EGMSLinkTypes");
                ownedEGMSLinkType.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                ownedEGMSLinkType.Property(x => x.Desc).HasColumnName("EGMSLinkTypeDescription");
                ownedEGMSLinkType.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("EGMSLinkTypeName"); });

                var ownedIDMSLinkType = entity.OwnsOne(x => x.IDMSLinkType);
                ownedIDMSLinkType.ToTable("IDMSLinkTypes");
                ownedIDMSLinkType.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                ownedIDMSLinkType.Property(o => o.Desc).HasColumnName("IDMSLinkTypeDescription");
                ownedIDMSLinkType.OwnsOne(x => x.Name, cb => { cb.Property(e => e.Value).HasColumnName("IDMSLinkTypeName"); });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ContactId).HasColumnName("ContactID");
                entity.Property(e => e.DeactivationDate).HasColumnType("datetime");
                entity.Property(e => e.DepartmentCodeId).HasColumnName("DepartmentCodeID");
                entity.Property(e => e.HasEGMSAccess).HasColumnName("HasEGMSAccess");
                entity.OwnsOne(x => x.IDMSSID, cb => { cb.Property(e => e.Value).HasColumnName("IDMSSID"); });
                entity.HasOne(d => d.Contact).WithMany(p => p.Users).HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Users_Contacts");
            });
        }
    }
}
