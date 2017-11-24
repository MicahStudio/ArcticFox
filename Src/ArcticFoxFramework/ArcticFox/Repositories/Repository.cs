using ArcticFox.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArcticFox.Repositories
{
    public class Repository<TEntity, TPKey> : IRepository<TEntity, TPKey> where TEntity : class, IEntity<TPKey>
    {
        private readonly AFDbContextBase dbContext;
        public Repository(AFDbContextBase dbContext)
        {
            this.dbContext = dbContext;
        }
        public TEntity Insert(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
