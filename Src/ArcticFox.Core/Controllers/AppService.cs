using ArcticFox.Attributes;
using ArcticFox.Audiing;
using ArcticFox.EntityFrameworkCore;
using ArcticFox.Factoys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ArcticFox.Controllers
{
    [Route("api/[controller]/[action]")]
    public abstract class AppService : Controller
    {
        internal AppDbContext _dbContext { get; } = DbContextFactory.CreateDbContext();
        /// <summary>
        /// 审计日志
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var isauditing = true;
            var start = DateTime.Now;
            var filter = context.Filters.LastOrDefault(t => t.GetType().Equals(typeof(AuditingAttribute)));

            if (filter != null)
            {
                if (filter is AuditingAttribute)
                {
                    isauditing = (filter as AuditingAttribute).IsAuditing;
                }
            }
            //TODO UnitOfWork是否应该改在此处进行实现
            ActionExecutedContext result = await next();
            if (isauditing)
            {
                var auditing = new AuditingLog
                {
                    ServerName = context.ActionDescriptor.DisplayName,
                    IPAddress = context.HttpContext?.Connection?.RemoteIpAddress?.ToString(),
                    ExecutionTime = start,
                    Parameters = JsonConvert.SerializeObject(context.ActionArguments),
                    Result = JsonConvert.SerializeObject(result.Result),
                    Duration = (DateTime.Now - start).TotalMilliseconds,
                    Exception = JsonConvert.SerializeObject(result?.Exception)
                };
                await _dbContext.AuditingLogs.AddAsync(auditing);
                await _dbContext.SaveChangesAsync();
                Console.WriteLine(auditing.ToString());
            }

        }
        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
            base.Dispose(disposing);
        }
    }
}
