using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ArcticFox.Configuration
{
    internal static class Cfg
    {
        public static bool EnableSwagger { set; get; } = true;
        public static Info SwaggerInfo { set; get; } = new Info { Title = "WebApi", Version = "v1", Description = "Description" };
        public static Type DbContextType { set; get; }
        public static List<string> BlackList { set; get; } = new List<string>();
        public static List<string> WhiteList { set; get; } = new List<string>();
        public static DbContextOptions dbContextOptions { set; get; }
    }
}
