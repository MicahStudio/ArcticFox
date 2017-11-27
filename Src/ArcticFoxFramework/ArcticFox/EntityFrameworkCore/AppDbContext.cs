using ArcticFox.Audiing;
using ArcticFox.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

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
            foreach (var entity in ChangeTracker.Entries())
            {
                switch (entity.State)
                {
                    case EntityState.Deleted:
                        {
                            entity.State = EntityState.Modified;
                            entity.CurrentValues["IsDeleted"] = true;
                            break;
                        }
                }
            }
        }
    }
}
