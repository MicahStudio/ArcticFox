using ArcticFox.Configuration;
using ArcticFox.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArcticFox.Factoys
{
    internal static class DbContextFactory
    {
        public static AppDbContext CreateDbContext()
        {
            return Activator.CreateInstance(Cfg.DbContextType, Cfg.dbContextOptions) as AppDbContext;
        }
    }
}
