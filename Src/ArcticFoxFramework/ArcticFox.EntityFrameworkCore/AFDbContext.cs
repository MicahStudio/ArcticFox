using ArcticFox.Core.Temp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArcticFox.EntityFrameworkCore
{
    public class AFDbContext : AppDbContext
    {
        public virtual DbSet<Temp> Temps { set; get; }
        public AFDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
