using Article.Model.Extentions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Permit.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Permit.Model.Context
{
    public class PermitDbContext : DbContext
    {
        public PermitDbContext() { }
        public PermitDbContext(DbContextOptions<PermitDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeleteEntity).IsAssignableFrom(entityType.ClrType))
                {
                    entityType.AddSoftDeleteQueryFilter();
                }
            }
        }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionsType { get; set; }
        public override int SaveChanges()
        {
            // Get the entries that are auditable
            var entries = ChangeTracker.Entries<IAuditEntity>();

            if (entries == null)
                return base.SaveChanges();

            var userId = Guid.NewGuid().ToString();
            var currentDate = DateTime.Now;

            var validStates = new HashSet<EntityState> { EntityState.Added, EntityState.Modified, EntityState.Deleted };
            var entriesFiltered = entries.Where(x => validStates.Contains(x.State));

            foreach (var entry in entriesFiltered)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = currentDate;
                        entry.Entity.CreatedBy = userId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = currentDate;
                        entry.Entity.UpdatedBy = userId;
                        break;
                    case EntityState.Deleted:
                        ((ISoftDeleteEntity)entry.Entity).IsDeleted = true;
                        entry.State = EntityState.Modified;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChanges();
        }
    }
}
