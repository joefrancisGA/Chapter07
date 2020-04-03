using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EGMS.BusinessAssociates.Data.EF.TypeConfigurations;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Domain.Enums;
using EGMS.BusinessAssociates.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EGMS.BusinessAssociates.Data.EF
{
    public class AssociatesContext : DbContext
    {
        private static readonly Type[] EnumerationTypes =
        {
            typeof(AssociateType),
            typeof(Status)
        };

        public AssociatesContext()
        {

        }

        public AssociatesContext(DbContextOptions<AssociatesContext> options) : base (options)
        {
            
        }

        public DbSet<AssociateOperatingContext> AssociateOperatingContexts { get; set; }
        public DbSet<Associate> Associates { get; set; }
        public DbSet<OperatingContext> OperatingContexts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                AssociateTypeConfigurations.ConfigureTypes(modelBuilder);
                modelBuilder.Entity<AssociateOperatingContext>()
                    .HasKey(aoc => new {aoc.AssociateId, aoc.OperatingContextId});

                modelBuilder.Entity<AssociateOperatingContext>()
                    .HasOne(aoc => aoc.Associate)
                    .WithMany(aoc => aoc.AssociateOperatingContexts)
                    .HasForeignKey(aoc => aoc.AssociateId);

                modelBuilder.Entity<AgentRelationship>()
                    .HasOne(ar => ar.Principal)
                    .WithMany(ar => ar.AgentRelationships)
                    .HasForeignKey(ar => ar.PrincipalId);

                modelBuilder.Entity<AssociateOperatingContext>()
                    .HasOne(aoc => aoc.OperatingContext)
                    .WithMany(aoc => aoc.AssociateOperatingContexts)
                    .HasForeignKey(aoc => aoc.OperatingContextId);

                modelBuilder.Entity<Associate>().Ignore(associate => associate.OperatingContexts);
                modelBuilder.Entity<Associate>().HasMany(associate => associate.AgentRelationships);
                modelBuilder.Entity<User>().Ignore(user => user.DepartmentCode);
                modelBuilder.Entity<Contact>().Ignore(contact => contact.FirstName);
                modelBuilder.Entity<Contact>().Ignore(contact => contact.LastName);
                modelBuilder.Entity<Contact>().Ignore(contact => contact.Title);
                modelBuilder.Entity<User>().Ignore(user => user.IDMSSID);

                modelBuilder.Entity<AgentRelationshipUser>()
                    .HasOne(ar => ar.AgentRelationship)
                    .WithMany(ar => ar.AgentRelationshipUserList)
                    .HasForeignKey(ar => ar.UserId);

                modelBuilder.Entity<AssociateId>().HasNoKey();
                modelBuilder.Entity<DepartmentCode>().HasNoKey();
                modelBuilder.Entity<FirstName>().HasNoKey();
                modelBuilder.Entity<IDMSSID>().HasNoKey();
                modelBuilder.Entity<LastName>().HasNoKey();
                modelBuilder.Entity<Title>().HasNoKey();
            }
            catch (Exception ex)
            {
                ex = ex;
                throw;
            }
        }


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<EntityEntry> enumerationEntries = ChangeTracker.Entries()
                .Where(x => EnumerationTypes.Contains(x.Entity.GetType()));

            foreach (EntityEntry enumerationEntry in enumerationEntries)
            {
                enumerationEntry.State = EntityState.Unchanged;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}