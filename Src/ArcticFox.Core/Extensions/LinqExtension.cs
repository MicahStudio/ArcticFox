using ArcticFox.EntityFrameworkCore;
using System.Collections.Generic;
namespace System.Linq
{
    public static class LinqExtension
    {
        /// <summary>
        /// 分页方法
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="skipCount">跳过的条目</param>
        /// <param name="maxResultCount">取回的条目</param>
        /// <returns></returns>
        public static IEnumerable<TEntity> PageBy<TEntity>(this IEnumerable<TEntity> entity, int skipCount = 0, int maxResultCount = 10) where TEntity : IEntity, IAuditedEntity
        {
            return entity.Skip(skipCount).Take(maxResultCount);
        }
    }
}
