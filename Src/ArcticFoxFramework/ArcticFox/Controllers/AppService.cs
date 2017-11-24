using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArcticFox.Controllers
{
    [Route("api/[controller]/[action]")]
    public abstract class AppService : Controller
    {
        /// <summary>
        /// 记录入参
        /// </summary>
        private IDictionary<string, object> ActionArguments { get; set; }
        /// <summary>
        /// 记录访问时间
        /// </summary>
        private DateTime ExecutionTime { set; get; }
        /// <summary>
        /// 方法执行中
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ExecutionTime = DateTime.Now;
            ActionArguments = context.ActionArguments;
            base.OnActionExecuting(context);
        }/// <summary>
         /// 方法执行后
         /// </summary>
         /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            //var auditing = new Core.Auditing.AuditingLog
            //{
            //    ServerName = context.ActionDescriptor.DisplayName,
            //    Duration = (DateTime.Now - ExecutionTime).TotalMilliseconds,
            //    Exception = JsonConvert.SerializeObject(context.Exception),
            //    IPAddress = context.HttpContext?.Connection?.RemoteIpAddress?.ToString(),
            //    ExecutionTime = ExecutionTime,
            //    Parameters = JsonConvert.SerializeObject(ActionArguments),
            //    Result = JsonConvert.SerializeObject(context.Result)
            //};
            //dbContext.AuditingLogs.Add(auditing);
            //dbContext.SaveChanges();
            //Console.WriteLine($"请求:{auditing}");
        }
    }
}
