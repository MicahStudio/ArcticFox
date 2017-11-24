using ArcticFox.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArcticFox.Repositories
{
    public interface IRepository
    {

    }
    public interface IRepository<TEntity, TPKey> : IRepository where TEntity : class, IEntity<TPKey>
    {
        TEntity Insert(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);
    }
}
