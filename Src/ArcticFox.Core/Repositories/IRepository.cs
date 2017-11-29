using ArcticFox.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArcticFox.Repositories
{
    /// <summary>
    /// 仓储接口
    /// </summary>
    public interface IRepository
    {

    }
    /// <summary>
    /// 仓储
    /// </summary>
    /// <typeparam name="TEntity">实体</typeparam>
    /// <typeparam name="TPKey">主键类型</typeparam>
    public interface IRepository<TEntity, TPKey> : IRepository where TEntity : class, IEntity<TPKey>, IAuditedEntity<TPKey>
    {
        /// <summary>
        /// 插入一条新纪录
        /// </summary>
        /// <param name="entity">要插入的实体</param>
        /// <returns></returns>
        TEntity Insert(TEntity entity);
        /// <summary>
        /// 异步插入一条新纪录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<TEntity> InsertAsync(TEntity entity);
        /// <summary>
        /// 插入多条记录
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        int AddRange(IEnumerable<TEntity> entitys);
        /// <summary>
        /// 异步插入多条记录
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        Task<int> AddRangeAsync(IEnumerable<TEntity> entitys);
        /// <summary>
        /// 通过主键获取实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TEntity Get(TPKey key);
        /// <summary>
        /// 异步通过主键获取实体
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<TEntity> GetAsync(TPKey key);
        /// <summary>
        /// 获取第一条记录
        /// </summary>
        /// <returns></returns>
        TEntity FirstOrDefault();
        /// <summary>
        /// 获取第一条记录
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity FirstOrDefault(Func<TEntity, bool> predicate);
        /// <summary>
        /// 异步获取第一条记录
        /// </summary>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync();
        /// <summary>
        /// 异步获取第一条记录
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 获取最后一条记录
        /// </summary>
        /// <returns></returns>
        TEntity LastOrDefault();
        /// <summary>
        /// 获取最后一条记录
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity LastOrDefault(Func<TEntity, bool> predicate);
        /// <summary>
        /// 异步获取最后一条记录
        /// </summary>
        /// <returns></returns>
        Task<TEntity> LastOrDefaultAsync();
        /// <summary>
        /// 异步获取最后一条记录
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> LastOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Where(Func<TEntity, bool> predicate);
        bool Delete(TEntity entity);
    }
}
