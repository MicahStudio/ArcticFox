using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArcticFox.BlackLists
{
    internal class BlackListMiddleware
    {
        private readonly RequestDelegate _next;
        public BlackListMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);
        }
    }
}
