using ArcticFox.Extensions;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArcticFox.Configuration
{
    public class AFoxConfiguration
    {
        /// <summary>
        /// 是否开启Swagger
        /// </summary>
        /// <param name="enabled"></param>
        public void Swagger(bool enabled = true, Info info = null)
        {
            Cfg.EnableSwagger = enabled;
            if (info != null)
                Cfg.SwaggerInfo = info;
        }
        /// <summary>
        /// 设置DbContext
        /// </summary>
        public void UseDbContext<TDbContext>() where TDbContext : DbContext
        {
            Cfg.DbContextType = typeof(TDbContext);
        }
        /// <summary>
        /// 设置黑名单，设置白名单后，黑名单则无效。
        /// </summary>
        /// <param name="Ips"></param>
        public void BlackList(List<string> Ips)
        {
            Cfg.BlackList = Ips;
        }
        /// <summary>
        /// 设置白名单，设置白名单后，黑名单则无效。
        /// </summary>
        /// <param name="Ips"></param>
        public void WhiteList(List<string> Ips)
        {
            Cfg.WhiteList = Ips;
        }
    }
}
