﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using EGMS.BusinessAssociates.Domain;
using EGMS.BusinessAssociates.Data.EF.TypeConfigurations;
using EGMS.BusinessAssociates.Domain.Enums;

namespace EGMS.Facilities.Data.EF
{
    public partial class AssociatesContext : DbContext
    {
        private static readonly Type[] EnumerationTypes =
        {
            typeof(AssociateType),
            typeof(Status),
        };

        public AssociatesContext()
        {

        }

        public AssociatesContext(DbContextOptions<AssociatesContext> options) : base (options)
        {
            
        }

        public virtual DbSet<Associate> Associates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AssociateTypeConfigurations.ConfigureTypes(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<EntityEntry> enumerationEntries = ChangeTracker.Entries()
                .Where(x => EnumerationTypes.Contains(x.Entity.GetType()));

            foreach (EntityEntry enumerationEntry in enumerationEntries)
            {
                enumerationEntry.State = EntityState.Unchanged;
            }


            int result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }

    }
}