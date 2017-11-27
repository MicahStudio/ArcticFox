using ArcticFox.Audiing;
using ArcticFox.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            Console.WriteLine(options.ToString());
        }
    }
}
