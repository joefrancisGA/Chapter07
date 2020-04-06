using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace EGMS.BusinessAssociates.Data.EF
{
    public partial class BusinessAssociatesContext : DbContext
    {
        public BusinessAssociatesContext()
        {
        }

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
        //public virtual DbSet<AssociateTypes> AssociateTypes { get; set; }
        public virtual DbSet<AssociateUser> AssociateUsers { get; set; }
        public virtual DbSet<Associate> Associates { get; set; }
        //public virtual DbSet<BalancingLevelTypes> BalancingLevelTypes { get; set; }
        //public virtual DbSet<CertificationStatuses> CertificationStatuses { get; set; }
        public virtual DbSet<Certification> Certifications { get; set; }
        public virtual DbSet<ContactConfiguration> ContactConfigurations { get; set; }
        //public virtual DbSet<ContactTypes> ContactTypes { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        //public virtual DbSet<CountryCodes> CountryCodes { get; set; }
        public virtual DbSet<CustomerAlternateFuel> CustomerAlternateFuels { get; set; }
        //public virtual DbSet<CustomerTypes> CustomerTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        //public virtual DbSet<DeliveryTypes> DeliveryTypes { get; set; }
        //public virtual DbSet<EgmslinkTypes> EgmslinkTypes { get; set; }
        public virtual DbSet<EGMSPermission> Egmspermissions { get; set; }
        public virtual DbSet<EMail> Emails { get; set; }
        //public virtual DbSet<GroupType> GroupTypes { get; set; }
        //public virtual DbSet<IdmslinkTypes> IdmslinkTypes { get; set; }
        //public virtual DbSet<LossTierTypes> LossTierTypes { get; set; }
        //public virtual DbSet<NominationLevelTypes> NominationLevelTypes { get; set; }
        public virtual DbSet<OperatingContextCustomer> OperatingContextCustomers { get; set; }
        //public virtual DbSet<OperatingContextTypes> OperatingContextTypes { get; set; }
        public virtual DbSet<OperatingContext> OperatingContexts { get; set; }
        //public virtual DbSet<PhoneTypes> PhoneTypes { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<PredecessorBusinessAssociate> PredecessorBusinessAssociates { get; set; }
        //public virtual DbSet<ProviderTypes> ProviderTypes { get; set; }
        //public virtual DbSet<RoleEGMSPermission> RoleEgmspermissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        //public virtual DbSet<StateCodes> StateCodes { get; set; }
        //public virtual DbSet<StatusCodes> StatusCodes { get; set; }
        public virtual DbSet<UserContactDisplayRules> UserContactDisplayRules { get; set; }
        public virtual DbSet<UserOperatingContext> UserOperatingContexts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost\\egms;Database=BusinessAssociates;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<AccountStatus>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.AccountStatusDescription)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.AlternateFuelTypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<AddressTypes>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.AddressTypeDescription)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.AddressTypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                //entity.Property(e => e.AddressType).HasColumnName("AddressTypeID");

                entity.Property(e => e.Attention)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                //entity.HasOne(d => d.AddressType)
                //    .WithMany(p => p.Addresses)
                //    .HasForeignKey(d => d.AddressTypeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Addresses_AddressTypes");

                //entity.HasOne(d => d.StateCode)
                //    .WithMany(p => p.Addresses)
                //    .HasForeignKey(d => d.StateCodeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Addresses_StateCodes");
            });

            modelBuilder.Entity<AgentRelationship>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AgentId).HasColumnName("AgentID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.PrincipalId).HasColumnName("PrincipalID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                //entity.HasOne(d => d.Agent)
                //    .WithMany(p => p.AgentRelationshipsAgent)
                //    .HasForeignKey(d => d.AgentId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_AgentRelationships_Agent");

                //entity.HasOne(d => d.Principal)
                //    .WithMany(p => p.AgentRelationshipsPrincipal)
                //    .HasForeignKey(d => d.PrincipalId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_AgentRelationships_Principal");
            });

            //modelBuilder.Entity<AgentUser>(entity =>
            //{
            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.AgentId).HasColumnName("AgentID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.HasOne(d => d.Agent)
            //        .WithMany(p => p.AgentUsers)
            //        .HasForeignKey(d => d.AgentId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_AgentUser_Agent");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AgentUsers)
            //        .HasForeignKey(d => d.UserId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_AgentUser_User");
            //});

            //modelBuilder.Entity<AlternateFuelTypes>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.AlternateFuelTypeDescription)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.AlternateFuelTypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            modelBuilder.Entity<AssociateCustomer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ServiceEndDate).HasColumnType("datetime");

                entity.Property(e => e.ServiceStartDate).HasColumnType("datetime");

                //entity.HasOne(d => d.Associate)
                //    .WithMany(p => p.AssociateCustomers)
                //    .HasForeignKey(d => d.AssociateId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_AssociateCustomers_Associate");

                //entity.HasOne(d => d.Customer)
                //    .WithMany(p => p.AssociateCustomer)
                //    .HasForeignKey(d => d.CustomerId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_AssociateCustomers_Customer");
            });

            modelBuilder.Entity<AssociateOperatingContext>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                //entity.HasOne(d => d.Associate)
                //    .WithMany(p => p.AssociateOperatingContext)
                //    .HasForeignKey(d => d.AssociateId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_AssociateOperatingContexts_Associates");

                entity.HasOne(d => d.OperatingContext)
                    .WithMany(p => p.AssociateOperatingContexts)
                    .HasForeignKey(d => d.OperatingContextId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssociateOperatingContexts_OperatingContexts");
            });

            //modelBuilder.Entity<AssociateTypes>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.AssociateTypeDescription)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.AssociateTypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            modelBuilder.Entity<AssociateUser>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                //entity.HasOne(d => d.Associate)
                //    .WithMany(p => p.AssociateUsers)
                //    .HasForeignKey(d => d.AssociateId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_AssociateUsers_Associate");

                //entity.HasOne(d => d.User)
                //    .WithMany(p => p.AssociateUsers)
                //    .HasForeignKey(d => d.UserId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_AssociateUsers_User");
            });

            modelBuilder.Entity<Associate>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DUNSNumber).HasColumnName("DUNSNumber");

                entity.Property(e => e.LongName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                //entity.HasOne(d => d.AssociateType)
                //    .WithMany(p => p.Associates)
                //    .HasForeignKey(d => d.AssociateTypeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Associates_AssociateTypes");

                //entity.HasOne(d => d.StatusCode)
                //    .WithMany(p => p.Associates)
                //    .HasForeignKey(d => d.StatusCodeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Associates_StatusCodes");
            });

            //modelBuilder.Entity<BalancingLevelTypes>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.BalancingLevelTypeDescription)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.BalancingLevelTypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<CertificationStatuses>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.CertificationStatusDescription)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CertificationStatusName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            modelBuilder.Entity<Certification>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CertificationDateTime).HasColumnType("datetime");

                entity.Property(e => e.DecertificationDateTime).HasColumnType("datetime");

                //entity.HasOne(d => d.CertificationStatus)
                //    .WithMany(p => p.Certifications)
                //    .HasForeignKey(d => d.CertificationStatusId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Certifications_CertificationStatuses");
            });

            modelBuilder.Entity<ContactConfiguration>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                //entity.HasOne(d => d.Contact)
                //    .WithMany(p => p.ContactConfigurations)
                //    .HasForeignKey(d => d.ContactId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_ContactConfigurations_Contacts");

                //entity.HasOne(d => d.ContactType)
                //    .WithMany(p => p.ContactConfigurations)
                //    .HasForeignKey(d => d.ContactTypeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_ContactConfigurations_ContactTypes");

                //entity.HasOne(d => d.StatusCode)
                //    .WithMany(p => p.ContactConfigurations)
                //    .HasForeignKey(d => d.StatusCodeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_ContactConfigurations_StatusCodes");
            });

            //modelBuilder.Entity<ContactTypes>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.ContactTypeDescription)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ContactTypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            //modelBuilder.Entity<CountryCodes>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.CountryCodeDescription)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CountryCodeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            modelBuilder.Entity<CustomerAlternateFuel>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                //entity.HasOne(d => d.AlternateFuelType)
                //    .WithMany(p => p.CustomerAlternateFuels)
                //    .HasForeignKey(d => d.AlternateFuelTypeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_CustomerAlternateFuels_AlternateFuelTypes");

                //entity.HasOne(d => d.Customer)
                //    .WithMany(p => p.CustomerAlternateFuel)
                //    .HasForeignKey(d => d.CustomerId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_CustomerAlternateFuels_Customers");
            });

            //modelBuilder.Entity<CustomerTypes>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.CustomerTypeDescription)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.CustomerTypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DUNSNumber).HasColumnName("DUNSNumber");

                entity.Property(e => e.LDCId).HasColumnName("LDCId");

                entity.Property(e => e.LongName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MDQ).HasColumnName("MDQ");

                entity.Property(e => e.NAICSCode).HasColumnName("NAICSCode");

                entity.Property(e => e.ShippersLetterFromDate).HasColumnType("datetime");

                //entity.Property(e => e.ShortName)
                //    .IsRequired()
                //    .HasMaxLength(50)
                //    .IsUnicode(false);

                entity.Property(e => e.SICCode).HasColumnName("SICCode");

                entity.Property(e => e.SICCodePercentage).HasColumnName("SICCodePercentage");

                entity.Property(e => e.SS1).HasColumnName("SS1");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TurnOffDate).HasColumnType("datetime");

                entity.Property(e => e.TurnOnDate).HasColumnType("datetime");

                //entity.HasOne(d => d.BalancingLevel)
                //    .WithMany(p => p.Customers)
                //    .HasForeignKey(d => d.BalancingLevelId)
                //    .HasConstraintName("FK_Customers_BalancingLevelTypes");

                //entity.HasOne(d => d.CustomerType)
                //    .WithMany(p => p.Customers)
                //    .HasForeignKey(d => d.CustomerTypeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Customers_CustomerTypes");

                //entity.HasOne(d => d.DeliveryType)
                //    .WithMany(p => p.Customers)
                //    .HasForeignKey(d => d.DeliveryTypeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Customers_DeliveryTypes");

                //entity.HasOne(d => d.GroupType)
                //    .WithMany(p => p.Customers)
                //    .HasForeignKey(d => d.GroupTypeId)
                //    .HasConstraintName("FK_Customers_GroupTypes");

                //entity.HasOne(d => d.LossTierType)
                //    .WithMany(p => p.Customers)
                //    .HasForeignKey(d => d.LossTierTypeId)
                //    .HasConstraintName("FK_Customers_LossTierTypes");

                //entity.HasOne(d => d.NominationLevel)
                //    .WithMany(p => p.Customers)
                //    .HasForeignKey(d => d.NominationLevelId)
                //    .HasConstraintName("FK_Customers_NominationLevelTypes");

                //entity.HasOne(d => d.Shipper)
                //    .WithMany(p => p.Customers)
                //    .HasForeignKey(d => d.ShipperId)
                //    .HasConstraintName("FK_Customers_Shippers");

                //entity.HasOne(d => d.StatusCode)
                //    .WithMany(p => p.Customers)
                //    .HasForeignKey(d => d.StatusCodeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Customers_StatusCodes");
            });

            //modelBuilder.Entity<DeliveryTypes>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.DeliveryTypeDescription)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.DeliveryTypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<EgmslinkTypes>(entity =>
            //{
            //    entity.ToTable("EGMSLinkTypes");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.EgmslinkTypeDescription)
            //        .HasColumnName("EGMSLinkTypeDescription")
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.EgmslinkTypeName)
            //        .IsRequired()
            //        .HasColumnName("EGMSLinkTypeName")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            modelBuilder.Entity<EGMSPermission>(entity =>
            {
                entity.ToTable("EGMSPermissions");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PermissionDescription)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.PermissionName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EMail>(entity =>
            {
                entity.ToTable("EMails");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EMailAddress)
                    .IsRequired()
                    .HasColumnName("EMailAddress")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                //entity.HasOne(d => d.Contact)
                //    .WithMany(p => p.Emails)
                //    .HasForeignKey(d => d.ContactId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_EMails_Contacts");
            });

            //modelBuilder.Entity<GroupTypes>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.GroupTypeDescription)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.GroupTypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<IdmslinkTypes>(entity =>
            //{
            //    entity.ToTable("IDMSLinkTypes");

            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.IdmlinkTypeDescription)
            //        .HasColumnName("IDMLinkTypeDescription")
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.IdmslinkTypeName)
            //        .IsRequired()
            //        .HasColumnName("IDMSLinkTypeName")
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<LossTierTypes>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.LossTierDescription)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.LossTierName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<NominationLevelTypes>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.NominationLevelDescription)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.NominationLevelName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            modelBuilder.Entity<OperatingContextCustomer>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                //entity.HasOne(d => d.Customer)
                //    .WithMany(p => p.OperatingContextCustomers)
                //    .HasForeignKey(d => d.CustomerId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_OperatingContextCustomers_Customers");

                //entity.HasOne(d => d.OperatingContext)
                //    .WithMany(p => p.OperatingContextCustomers)
                //    .HasForeignKey(d => d.OperatingContextId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_OperatingContextCustomers_OperatingContexts");
            });

            //modelBuilder.Entity<OperatingContextTypes>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.OperatingContextTypeDescription)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.OperatingContextTypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            modelBuilder.Entity<OperatingContext>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActingBAType).HasColumnName("ActingBATypeId");

                entity.Property(e => e.PrimaryEmailId).HasColumnName("PrimaryEMailId");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                //entity.HasOne(d => d.ActingBAType)
                //    .WithMany(p => p.OperatingContexts)
                //    .HasForeignKey(d => d.ActingBatypeId)
                //    .HasConstraintName("FK_OperatingContexts_ActingBAType");

                //entity.HasOne(d => d.Certification)
                //    .WithMany(p => p.OperatingContexts)
                //    .HasForeignKey(d => d.CertificationId)
                //    .HasConstraintName("FK_OperatingContexts_Certifications");

                //entity.HasOne(d => d.OperatingContextType)
                //    .WithMany(p => p.OperatingContexts)
                //    .HasForeignKey(d => d.OperatingContextTypeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_OperatingContexts_OperatingContextTypes");

                //entity.HasOne(d => d.PrimaryAddress)
                //    .WithMany(p => p.OperatingContexts)
                //    .HasForeignKey(d => d.PrimaryAddressId)
                //    .HasConstraintName("FK_OperatingContexts_PrimaryAddress");

                //entity.HasOne(d => d.PrimaryEmail)
                //    .WithMany(p => p.OperatingContexts)
                //    .HasForeignKey(d => d.PrimaryEmailId)
                //    .HasConstraintName("FK_OperatingContexts_PrimaryEmail");

                //entity.HasOne(d => d.PrimaryPhone)
                //    .WithMany(p => p.OperatingContext)
                //    .HasForeignKey(d => d.PrimaryPhoneId)
                //    .HasConstraintName("FK_OperatingContexts_PrimaryPhone");

                //entity.HasOne(d => d.ProviderType)
                //    .WithMany(p => p.OperatingContexts)
                //    .HasForeignKey(d => d.ProviderTypeId)
                //    .HasConstraintName("FK_OperatingContexts_ProviderTypes");

                //entity.HasOne(d => d.Role)
                //    .WithMany(p => p.OperatingContexts)
                //    .HasForeignKey(d => d.RoleId)
                //    .HasConstraintName("FK_OperatingContexts_Roles");

                //entity.HasOne(d => d.StatusCode)
                //    .WithMany(p => p.OperatingContexts)
                //    .HasForeignKey(d => d.StatusCodeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_OperatingContexts_StatusCodes");

                //entity.HasOne(d => d.ThirdPartySupplier)
                //    .WithMany(p => p.OperatingContexts)
                //    .HasForeignKey(d => d.ThirdPartySupplierId)
                //    .HasConstraintName("FK_OperatingContexts_ThirdPartySupplier");
            });

            //modelBuilder.Entity<PhoneTypes>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.PhoneTypeDescription)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.PhoneTypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            modelBuilder.Entity<Phone>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                //entity.HasOne(d => d.Contact)
                //    .WithMany(p => p.Phones)
                //    .HasForeignKey(d => d.ContactId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Phones_Contacts");

                //entity.HasOne(d => d.PhoneType)
                //    .WithMany(p => p.Phones)
                //    .HasForeignKey(d => d.PhoneTypeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Phones_PhoneTypes");
            });

            modelBuilder.Entity<PredecessorBusinessAssociate>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                //entity.HasOne(d => d.Associate)
                //    .WithMany(p => p.PredecessorBusinessAssociatesAssociate)
                //    .HasForeignKey(d => d.AssociateId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_PredecessorBusinessAssociates_Associates");

                //entity.HasOne(d => d.PredecessorAssociate)
                //    .WithMany(p => p.PredecessorBusinessAssociatesPredecessorAssociate)
                //    .HasForeignKey(d => d.PredecessorAssociateId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_PredecessorBusinessAssociates_Customers");
            });

            //modelBuilder.Entity<ProviderTypes>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.ProviderTypeDescription)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.ProviderTypeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            //modelBuilder.Entity<RoleEgmspermissions>(entity =>
            //{
            //    entity.ToTable("RoleEGMSPermissions");

            //    entity.Property(e => e.Id).HasColumnName("ID");

            //    entity.Property(e => e.EgmspermissionId).HasColumnName("EGMSPermissionId");

            //    entity.HasOne(d => d.Egmspermission)
            //        .WithMany(p => p.RoleEgmspermissions)
            //        .HasForeignKey(d => d.EgmspermissionId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_RoleEGMSPermissions_EGMSPermissions");

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.RoleEgmspermissions)
            //        .HasForeignKey(d => d.RoleId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_RoleEGMSPermissions_Roles");
            //});

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.RoleDescription)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            //modelBuilder.Entity<StateCodes>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.CountryCodeId).HasColumnName("CountryCodeID");

            //    entity.Property(e => e.StateCodeDescription)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StateCodeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);

            //    entity.HasOne(d => d.CountryCode)
            //        .WithMany(p => p.StateCodes)
            //        .HasForeignKey(d => d.CountryCodeId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_StateCodes_CountryCodes");
            //});

            //modelBuilder.Entity<StatusCodes>(entity =>
            //{
            //    entity.Property(e => e.Id)
            //        .HasColumnName("ID")
            //        .ValueGeneratedNever();

            //    entity.Property(e => e.StatusCodeCodeDescription)
            //        .HasMaxLength(255)
            //        .IsUnicode(false);

            //    entity.Property(e => e.StatusCodeName)
            //        .IsRequired()
            //        .HasMaxLength(50)
            //        .IsUnicode(false);
            //});

            modelBuilder.Entity<UserContactDisplayRules>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EGMSAccountStatus).HasColumnName("EGMSAccountStatusId");

                entity.Property(e => e.EGMSConfigured).HasColumnName("EGMSConfigured");

                entity.Property(e => e.EGMSLinkType).HasColumnName("EGMSLinkTypeId");

                entity.Property(e => e.IDMSAccountExists).HasColumnName("IDMSAccountExists");

                //entity.Property(e => e.IdmsaccountStatusId).HasColumnName("IDMSAccountStatusId");

                //entity.Property(e => e.IdmslinkTypeId).HasColumnName("IDMSLinkTypeId");

                //entity.HasOne(d => d.EgmsaccountStatus)
                //    .WithMany(p => p.UserContactDisplayRulesEgmsaccountStatus)
                //    .HasForeignKey(d => d.EgmsaccountStatusId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_UserContactDisplayRules_EGMSAccountStatus");

                //entity.HasOne(d => d.EGMSLinkType)
                //    .WithMany(p => p.UserContactDisplayRules)
                //    .HasForeignKey(d => d.EgmslinkTypeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_UserContactDisplayRules_EGMSLinkTypes");

                //entity.HasOne(d => d.IDMSAccountStatus)
                //    .WithMany(p => p.UserContactDisplayRulesIdmsaccountStatus)
                //    .HasForeignKey(d => d.IdmsaccountStatusId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_UserContactDisplayRules_IDMSAccountStatus");

                //entity.HasOne(d => d.IdmslinkType)
                //    .WithMany(p => p.UserContactDisplayRules)
                //    .HasForeignKey(d => d.IdmslinkTypeId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_UserContactDisplayRules_IDMSLinkTypes");
            });

            modelBuilder.Entity<UserOperatingContext>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                //entity.HasOne(d => d.Principal)
                //    .WithMany(p => p.UserOperatingContexts)
                //    .HasForeignKey(d => d.PrincipalId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_UserOperatingContexts_Principal");

                //entity.HasOne(d => d.Role)
                //    .WithMany(p => p.UserOperatingContexts)
                //    .HasForeignKey(d => d.RoleId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_UserOperatingContexts_Roles");

                //entity.HasOne(d => d.User)
                //    .WithMany(p => p.UserOperatingContexts)
                //    .HasForeignKey(d => d.UserId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_UserOperatingContexts_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                //entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.DeactivationDate).HasColumnType("datetime");

                entity.Property(e => e.DepartmentCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HasEGMSAccess).HasColumnName("HasEGMSAccess");

                entity.Property(e => e.IDMSSID)
                    .IsRequired()
                    .HasColumnName("IMDMSID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                //entity.HasOne(d => d.Contact)
                //    .WithMany(p => p.User)
                //    .HasForeignKey(d => d.ContactId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Users_Contacts");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
