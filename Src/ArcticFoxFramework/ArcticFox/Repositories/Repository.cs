using ArcticFox.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArcticFox.Repositories
{
    public class Repository<TEntity, TPKey> : IRepository<TEntity, TPKey> where TEntity : class, IEntity<TPKey>
    {
        private readonly AppDbContext dbContext;
        private DbSet<TEntity> Table => dbContext.Set<TEntity>();
        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int AddRange(IEnumerable<TEntity> entitys)
        {
            Table.AddRange(entitys);
            return dbContext.SaveChanges();
        }

        public async Task<int> AddRangeAsync(IEnumerable<TEntity> entitys)
        {
            await Table.AddRangeAsync(entitys);
            return await dbContext.SaveChangesAsync();
        }

        public TEntity FirstOrDefault()
        {
            return Table.FirstOrDefault();
        }

        public TEntity FirstOrDefault(Func<TEntity, bool> predicate)
        {
            return Table.FirstOrDefault(predicate);
        }

        public async Task<TEntity> FirstOrDefaultAsync()
        {
            return await Table.FirstOrDefaultAsync();
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.FirstOrDefaultAsync(predicate);
        }

        public TEntity Get(TPKey key)
        {
            return Table.Find(key);
        }

        public async Task<TEntity> GetAsync(TPKey key)
        {
            return await Table.FindAsync(key);
        }

        public TEntity Insert(TEntity entity)
        {
            Table.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            Table.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public TEntity LastOrDefault()
        {
            return Table.LastOrDefault();
        }

        public TEntity LastOrDefault(Func<TEntity, bool> predicate)
        {
            return Table.LastOrDefault(predicate);
        }

        public async Task<TEntity> LastOrDefaultAsync()
        {
            return await Table.LastOrDefaultAsync();
        }

        public async Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Table.LastOrDefaultAsync(predicate);
        }

        public IEnumerable<TEntity> Where(Func<TEntity, bool> predicate)
        {
            return Table.Where(predicate);
        }
    }
}
