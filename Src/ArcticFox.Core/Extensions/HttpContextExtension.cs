using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.AspNetCore.Http
{
    public static class HttpContextExtension
    {
        public static string IpV4(this HttpContext httpContext)
        {
            return httpContext?.Connection?.RemoteIpAddress?.MapToIPv4().ToString();
        }
    }
}
