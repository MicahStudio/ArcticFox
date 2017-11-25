using ArcticFox.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArcticFox.Uow
{
    internal class UnitOfWorkManager
    {
        private readonly AppDbContext appDbContext;
        public UnitOfWorkManager(AppDbContext appDb)
        {
            appDbContext = appDb;
        }
        public IDbContextTransaction Begin()
        {
            return appDbContext.Database.BeginTransaction();
        }
    }
}
