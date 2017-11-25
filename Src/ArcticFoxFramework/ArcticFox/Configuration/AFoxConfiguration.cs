using ArcticFox.Extensions;
using Microsoft.EntityFrameworkCore;
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
        public void Swagger(bool enabled = true)
        {
            Cfg.EnableSwagger = enabled;
        }
        /// <summary>
        /// 设置DbContext
        /// </summary>
        public void UseDbContext<TDbContext>() where TDbContext : DbContext
        {
            Cfg.DbContextType = typeof(TDbContext);
        }
        public void BlackList(List<string> Ips)
        {
            Cfg.BlackList = Ips;
        }
    }
}
