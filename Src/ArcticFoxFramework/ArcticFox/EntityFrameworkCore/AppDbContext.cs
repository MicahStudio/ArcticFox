using ArcticFox.Audiing;
using ArcticFox.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Extensions.DependencyModel;
using ArcticFox.Extensions;

namespace ArcticFox.EntityFrameworkCore
{
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// 审计日志
        /// </summary>
        public virtual DbSet<AuditingLog> AuditingLogs { set; get; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Cfg.dbContextOptions = options;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var entity in modelBuilder.Model.GetEntityTypes().Where(t => t.FindProperty("IsDeleted") != null))
            {
                modelBuilder.FilterDelete(entity.ClrType);
            }

        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnSaveFilter();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnSaveFilter();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        private void OnSaveFilter()
        {
            foreach (var entity in ChangeTracker.Entries().Where(t => t.Entity is AuditedEntity))
            {
                switch (entity.State)
                {
                    case EntityState.Deleted:
                        {
                            entity.State = EntityState.Modified;
                            entity.CurrentValues["IsDeleted"] = true;
                            entity.CurrentValues["DeletionTime"] = DateTime.Now;
                            break;
                        }
                }
            }
        }
    }
}
