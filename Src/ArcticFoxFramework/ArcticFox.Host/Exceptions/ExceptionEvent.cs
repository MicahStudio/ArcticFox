﻿using ArcticFox.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ArcticFox.Host.Exceptions
{
    public class ExceptionEvent : IExceptionInterceptor
    {
        private readonly RequestDelegate next;
        public ExceptionEvent(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                Console.WriteLine($"请求:{DateTime.Now}\t{context.Connection.RemoteIpAddress.ToString()}\t{context.Request.Path}");
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json; charset=utf-8";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new { Code = "00000000", Message = "发生错误" }));
                Console.WriteLine($"异常拦截:{ex.Message}");
            }
        }
    }
}
