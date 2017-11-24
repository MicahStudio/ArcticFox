using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArcticFox.Interceptors
{
    /// <summary>
    /// 必须实现RequestDelegate next参数的构造方法
    /// </summary>
    public interface IExceptionInterceptor
    {
        Task Invoke(HttpContext context);
    }
}
