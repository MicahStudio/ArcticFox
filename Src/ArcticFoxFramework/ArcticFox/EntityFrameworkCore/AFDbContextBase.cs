using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArcticFox.EntityFrameworkCore
{
    public class AFDbContextBase : DbContext
    {
        public AFDbContextBase(DbContextOptions options) : base(options)
        {
        }
    }
}
