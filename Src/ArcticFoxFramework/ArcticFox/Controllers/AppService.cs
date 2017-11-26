using ArcticFox.Audiing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArcticFox.Controllers
{
    [Route("api/[controller]/[action]")]
    public abstract class AppService : Controller
    {
        /// <summary>
        /// 审计日志
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var auditing = new AuditingLog
            {
                ServerName = context.ActionDescriptor.DisplayName,
                IPAddress = context.HttpContext?.Connection?.RemoteIpAddress?.ToString(),
                ExecutionTime = DateTime.Now,
                Parameters = JsonConvert.SerializeObject(context.ActionArguments)
            };
            var result = await next();
            auditing.Result = JsonConvert.SerializeObject(result.Result);
            auditing.Duration = (DateTime.Now - auditing.ExecutionTime).TotalMilliseconds;
            auditing.Exception = JsonConvert.SerializeObject(result?.Exception);
            Console.WriteLine(JsonConvert.SerializeObject(result.Result));
        }
    }
}
