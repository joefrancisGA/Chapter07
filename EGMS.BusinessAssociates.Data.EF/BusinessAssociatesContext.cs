using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace EGMS.BusinessAssociates.Data.EF
{
    public class BusinessAssociatesContext : DbContext
    {
        public BusinessAssociatesContext() { }

        public BusinessAssociatesContext(DbContextOptions<BusinessAssociatesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountStatusLookup> AccountStatuses { get; set; }
        public virtual DbSet<AddressTypeLookup> AddressTypes { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AgentRelationship> AgentRelationships { get; set; }
        public virtual DbSet<AgentUser> AgentUsers { get; set; }
        public virtual DbSet<AlternateFuelTypeLookup> AlternateFuelTypes { get; set; }
        public virtual DbSet<AssociateCustomer> AssociateCustomers { get; set; }
        public virtual DbSet<AssociateOperatingContext> AssociateOperatingContexts { get; set; }
        public virtual DbSet<AssociateTypeLookup> AssociateTypes { get; set; }
        public virtual DbSet<AssociateUser> AssociateUsers { get; set; }
        public virtual DbSet<Associate> Associates { get; set; }
        public virtual DbSet<BalancingLevelTypeLookup> BalancingLevelTypes { get; set; }
        public virtual DbSet<CertificationStatusLookup> CertificationStatuses { get; set; }
        public virtual DbSet<Certification> Certifications { get; set; }
        public virtual DbSet<ContactConfiguration> ContactConfigurations { get; set; }
        public virtual DbSet<ContactTypeLookup> ContactTypes { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<CountryCodeLookup> CountryCodes { get; set; }
        public virtual DbSet<CustomerAlternateFuel> CustomerAlternateFuels { get; set; }
        public virtual DbSet<CustomerTypeLookup> CustomerTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DeliveryTypeLookup> DeliveryTypes { get; set; }
        public virtual DbSet<EGMSLinkTypeLookup> EGMSLinkTypes { get; set; }
        public virtual DbSet<EGMSPermission> EGMSPermissions { get; set; }
        public virtual DbSet<EMail> Emails { get; set; }
        public virtual DbSet<GroupTypeLookup> GroupTypes { get; set; }
        public virtual DbSet<IDMSLinkTypeLookup> IDMSLinkTypes { get; set; }
        public virtual DbSet<LossTierTypeLookup> LossTierTypes { get; set; }
        public virtual DbSet<NominationLevelTypeLookup> NominationLevelTypes { get; set; }
        public virtual DbSet<OperatingContextCustomer> OperatingContextCustomers { get; set; }
        public virtual DbSet<OperatingContextTypeLookup> OperatingContextTypes { get; set; }
        public virtual DbSet<OperatingContext> OperatingContexts { get; set; }
        public virtual DbSet<PhoneTypeLookup> PhoneTypes { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<PredecessorBusinessAssociate> PredecessorBusinessAssociates { get; set; }
        public virtual DbSet<ProviderTypeLookup> ProviderTypes { get; set; }
        public virtual DbSet<RoleEGMSPermission> RoleEGMSPermissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<StateCodeLookup> StateCodes { get; set; }
        public virtual DbSet<StatusCodeLookup> StatusCodes { get; set; }
        public virtual DbSet<UserContactDisplayRule> UserContactDisplayRules { get; set; }
        public virtual DbSet<UserOperatingContext> UserOperatingContexts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountStatusLookup>(entity =>
            {
                // ValueGeneratedNever is presumed for lookup tables
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();

                // It is not clear why we would need IsUnicode set to false.  Shouldn't that be the default?
                entity.Property(e => e.Desc).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<AddressTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Address1).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Address2).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Address3).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Address4).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.AddressType).HasColumnName("AddressTypeID");
                entity.Property(e => e.Attention).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.City).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Comments).HasMaxLength(2000).IsUnicode(false);
                entity.Property(e => e.EndDate).HasColumnType("datetime");
                entity.Property(e => e.PostalCode).HasMaxLength(10).IsUnicode(false);
                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.HasOne(d => d.AddressType).WithMany(p => p.Addresses).HasForeignKey(d => d.AddressType)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Addresses_AddressTypes");
                entity.HasOne(d => d.StateCode).WithMany(p => p.Addresses).HasForeignKey(d => d.StateCode)
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
                entity.Property(e => e.UserId).HasColumnName("UserID");
                entity.HasOne(d => d.Agent).WithMany(p => p.AgentUsers).HasForeignKey(d => d.AgentId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AgentUser_Agent");
                entity.HasOne(d => d.User).WithMany(p => p.AgentUsers).HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AgentUser_User");
            });

            modelBuilder.Entity<AlternateFuelTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
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
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AssociateOperatingContexts_Associates");
                entity.HasOne(d => d.OperatingContext).WithMany(p => p.AssociateOperatingContexts).HasForeignKey(d => d.OperatingContextId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AssociateOperatingContexts_OperatingContexts");
            });

            modelBuilder.Entity<AssociateTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<AssociateUser>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.HasOne(d => d.Associate).WithMany(p => p.AssociateUsers).HasForeignKey(d => d.AssociateId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AssociateUsers_Associate");
                entity.HasOne(d => d.User).WithMany(p => p.AssociateUsers).HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_AssociateUsers_User");
            });

            modelBuilder.Entity<Associate>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.DUNSNumber).HasColumnName("DUNSNumber");
                entity.Property(e => e.LongName).IsRequired().HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.ShortName).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.HasOne(d => d.AssociateType).WithMany(p => p.Associates).HasForeignKey(d => d.AssociateType)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Associates_AssociateTypes");
                entity.HasOne(d => d.Status).WithMany(p => p.Associates).HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Associates_StatusCodes");
            });

            modelBuilder.Entity<BalancingLevelTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<CertificationStatusLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<Certification>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.CertificationDateTime).HasColumnType("datetime");
                entity.Property(e => e.DecertificationDateTime).HasColumnType("datetime");
                entity.HasOne(d => d.CertificationStatus).WithMany(p => p.Certifications).HasForeignKey(d => d.CertificationStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Certifications_CertificationStatuses");
            });

            modelBuilder.Entity<ContactConfiguration>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.EndDate).HasColumnType("datetime");
                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.HasOne(d => d.Contact).WithMany(p => p.ContactConfigurations).HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ContactConfigurations_Contacts");
                entity.HasOne(d => d.ContactType).WithMany(p => p.ContactConfigurations).HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ContactConfigurations_ContactTypes");
                entity.HasOne(d => d.Status).WithMany(p => p.ContactConfigurations).HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ContactConfigurations_StatusCodes");
            });

            modelBuilder.Entity<ContactTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<CountryCodeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<CustomerAlternateFuel>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.HasOne(d => d.AlternateFuel).WithMany(p => p.CustomerAlternateFuels).HasForeignKey(d => d.AlternateFuel)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CustomerAlternateFuels_AlternateFuelTypes");
                entity.HasOne(d => d.Customer).WithMany(p => p.CustomerAlternateFuels).HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_CustomerAlternateFuels_Customers");
            });

            modelBuilder.Entity<CustomerTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.AccountNumber).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.DUNSNumber).HasColumnName("DUNSNumber");
                entity.Property(e => e.LDCId).HasColumnName("LDCId");
                entity.Property(e => e.LongName).IsRequired().HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.MDQ).HasColumnName("MDQ");
                entity.Property(e => e.NAICSCode).HasColumnName("NAICSCode");
                entity.Property(e => e.ShippersLetterFromDate).HasColumnType("datetime");
                entity.Property(e => e.ShortName).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.SICCode).HasColumnName("SICCode");
                entity.Property(e => e.SICCodePercentage).HasColumnName("SICCodePercentage");
                entity.Property(e => e.SS1).HasColumnName("SS1");
                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.Property(e => e.TurnOffDate).HasColumnType("datetime");
                entity.Property(e => e.TurnOnDate).HasColumnType("datetime");
                entity.HasOne(d => d.BalancingLevel).WithMany(p => p.Customers).HasForeignKey(d => d.BalancingLevel)
                    .HasConstraintName("FK_Customers_BalancingLevelTypes");
                entity.HasOne(d => d.CustomerType).WithMany(p => p.Customers).HasForeignKey(d => d.CustomerType)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Customers_CustomerTypes");
                entity.HasOne(d => d.DeliveryType).WithMany(p => p.Customers).HasForeignKey(d => d.DeliveryType)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Customers_DeliveryTypes");
                entity.HasOne(d => d.GroupType).WithMany(p => p.Customers).HasForeignKey(d => d.GroupType)
                    .HasConstraintName("FK_Customers_GroupTypes");
                entity.HasOne(d => d.LossTier).WithMany(p => p.Customers).HasForeignKey(d => d.LossTier)
                    .HasConstraintName("FK_Customers_LossTierTypes");
                entity.HasOne(d => d.NominationLevel).WithMany(p => p.Customers).HasForeignKey(d => d.NominationLevel)
                    .HasConstraintName("FK_Customers_NominationLevelTypes");
                entity.HasOne(d => d.Shipper).WithMany(p => p.Customers).HasForeignKey(d => d.ShipperId)
                    .HasConstraintName("FK_Customers_Shippers");
                entity.HasOne(d => d.Status).WithMany(p => p.Customers).HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Customers_StatusCodes");
            });

            modelBuilder.Entity<DeliveryTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<EGMSLinkTypeLookup>(entity =>
            {
                entity.ToTable("EGMSLinkTypes");
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasColumnName("EGMSLinkTypeDescription").HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasColumnName("EGMSLinkTypeName").HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<EGMSPermission>(entity =>
            {
                entity.ToTable("EGMSPermissions");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.PermissionDescription).HasMaxLength(2000).IsUnicode(false);
                entity.Property(e => e.PermissionName).IsRequired().HasMaxLength(255).IsUnicode(false);
            });

            modelBuilder.Entity<EMail>(entity =>
            {
                entity.ToTable("EMails");
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.EMailAddress).IsRequired().HasColumnName("EMailAddress").HasMaxLength(255).IsUnicode(false);
                entity.HasOne(d => d.Contact).WithMany(p => p.Emails).HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EMails_Contacts");
            });

            modelBuilder.Entity<GroupTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<IDMSLinkTypeLookup>(entity =>
            {
                entity.ToTable("IDMSLinkTypes");
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasColumnName("IDMLinkTypeDescription").HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasColumnName("IDMSLinkTypeName").HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<LossTierTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<NominationLevelTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
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
                entity.Property(e => e.Desc).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<OperatingContext>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ActingBAType).HasColumnName("ActingBATypeId");
                entity.Property(e => e.PrimaryEmailId).HasColumnName("PrimaryEMailId");
                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.HasOne(d => d.ActingBAType).WithMany(p => p.OperatingContexts).HasForeignKey(d => d.ActingBAType)
                    .HasConstraintName("FK_OperatingContexts_ActingBAType");
                entity.HasOne(d => d.Certification).WithMany(p => p.OperatingContexts)
                    .HasForeignKey(d => d.CertificationId).HasConstraintName("FK_OperatingContexts_Certifications");
                entity.HasOne(d => d.OperatingContextType).WithMany(p => p.OperatingContexts).HasForeignKey(d => d.OperatingContextType)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_OperatingContexts_OperatingContextTypes");
                entity.HasOne(d => d.PrimaryAddress).WithMany(p => p.OperatingContexts).HasForeignKey(d => d.PrimaryAddressId)
                    .HasConstraintName("FK_OperatingContexts_PrimaryAddress");
                entity.HasOne(d => d.PrimaryEmail).WithMany(p => p.OperatingContexts).HasForeignKey(d => d.PrimaryEmailId)
                    .HasConstraintName("FK_OperatingContexts_PrimaryEmail");
                entity.HasOne(d => d.PrimaryPhone).WithMany(p => p.OperatingContext).HasForeignKey(d => d.PrimaryPhoneId)
                    .HasConstraintName("FK_OperatingContexts_PrimaryPhone");
                entity.HasOne(d => d.ProviderType).WithMany(p => p.OperatingContexts).HasForeignKey(d => d.ProviderType)
                    .HasConstraintName("FK_OperatingContexts_ProviderTypes");
                entity.HasOne(d => d.Role).WithMany(p => p.OperatingContexts).HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_OperatingContexts_Roles");
                entity.HasOne(d => d.Status).WithMany(p => p.OperatingContexts).HasForeignKey(d => d.Status)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_OperatingContexts_StatusCodes");
                entity.HasOne(d => d.ThirdPartySupplier).WithMany(p => p.OperatingContexts).HasForeignKey(d => d.ThirdPartySupplierId)
                    .HasConstraintName("FK_OperatingContexts_ThirdPartySupplier");
            });

            modelBuilder.Entity<PhoneTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Extension).IsRequired().HasMaxLength(10).IsUnicode(false);
                entity.HasOne(d => d.Contact).WithMany(p => p.Phones).HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Phones_Contacts");
                entity.HasOne(d => d.PhoneType).WithMany(p => p.Phones).HasForeignKey(d => d.PhoneType).OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Phones_PhoneTypes");
            });

            modelBuilder.Entity<PredecessorBusinessAssociate>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.HasOne(d => d.Associate).WithMany(p => p.PredecessorAssociates).HasForeignKey(d => d.AssociateId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_PredecessorBusinessAssociates_Associates");

                entity.HasOne(d => d.Associate).WithMany(p => p.PredecessorAssociates).HasForeignKey(d => d.PredecessorAssociateId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_PredecessorBusinessAssociates_Customers");
            });

            modelBuilder.Entity<ProviderTypeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            });

            modelBuilder.Entity<RoleEGMSPermission>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

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
                entity.Property(e => e.RoleDescription).IsRequired().HasMaxLength(2000).IsUnicode(false);
                entity.Property(e => e.RoleName).IsRequired().HasMaxLength(255).IsUnicode(false);
            });

            modelBuilder.Entity<StateCodeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.CountryCodeId).HasColumnName("CountryCodeID");
                entity.Property(e => e.Desc).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.HasOne(d => d.CountryCode).WithMany(p => p.StateCodes).HasForeignKey(d => d.CountryCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_StateCodes_CountryCodes");
            });

            modelBuilder.Entity<StatusCodeLookup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedNever();
                entity.Property(e => e.Desc).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserContactDisplayRule>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.EGMSAccountStatus).HasColumnName("EGMSAccountStatusId");
                entity.Property(e => e.EGMSConfigured).HasColumnName("EGMSConfigured");
                entity.Property(e => e.EGMSLinkType).HasColumnName("EGMSLinkTypeId");
                entity.Property(e => e.IDMSAccountExists).HasColumnName("IDMSAccountExists");
                entity.Property(e => e.IDMSAccountStatus).HasColumnName("IDMSAccountStatusId");
                entity.Property(e => e.IDMSLinkType).HasColumnName("IDMSLinkTypeId");
                entity.HasOne(d => d.EGMSAccountStatus).WithMany(p => p.UserContactDisplayRules).HasForeignKey(d => d.EGMSAccountStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UserContactDisplayRules_EGMSAccountStatus");
                entity.HasOne(d => d.EGMSLinkType).WithMany(p => p.UserContactDisplayRules).HasForeignKey(d => d.EGMSLinkType)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UserContactDisplayRules_EGMSLinkTypes");
                entity.HasOne(d => d.IDMSAccountStatus).WithMany(p => p.UserContactDisplayRules).HasForeignKey(d => d.IDMSAccountStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UserContactDisplayRules_IDMSAccountStatus");
                entity.HasOne(d => d.IDMSLinkType).WithMany(p => p.UserContactDisplayRules).HasForeignKey(d => d.IDMSLinkType)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UserContactDisplayRules_IDMSLinkTypes");
            });

            modelBuilder.Entity<UserOperatingContext>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.EndDate).HasColumnType("datetime");
                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.HasOne(d => d.Principal).WithMany(p => p.UserOperatingContexts).HasForeignKey(d => d.PrincipalId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UserOperatingContexts_Principal");
                entity.HasOne(d => d.Role).WithMany(p => p.UserOperatingContexts).HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UserOperatingContexts_Roles");
                entity.HasOne(d => d.User).WithMany(p => p.UserOperatingContexts).HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_UserOperatingContexts_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.ContactId).HasColumnName("ContactID");
                entity.Property(e => e.DeactivationDate).HasColumnType("datetime");
                entity.Property(e => e.DepartmentCode).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.HasEGMSAccess).HasColumnName("HasEGMSAccess");
                entity.Property(e => e.IDMSSID).IsRequired().HasColumnName("IMDMSID")
                    .HasMaxLength(50).IsUnicode(false);
                entity.HasOne(d => d.Contact).WithMany(p => p.Users).HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_Users_Contacts");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        private void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            throw new System.NotImplementedException();
        }
    }
}
