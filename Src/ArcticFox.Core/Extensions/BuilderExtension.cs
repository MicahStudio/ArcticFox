using ArcticFox.Configuration;
using ArcticFox.EntityFrameworkCore;
using ArcticFox.Uow;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ArcticFox.Extensions
{
    public static class BuilderExtension
    {
        public static void AddAFox(this IApplicationBuilder app)
        {
            if (Cfg.EnableSwagger)
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint($"/swagger/{Cfg.SwaggerInfo.Version}/swagger.json", Cfg.SwaggerInfo.Description);
                });
            }
            app.Use(async (context, next) =>
            {
                if (Cfg.WhiteList.Count > 0)
                {
                    if (Cfg.WhiteList.Contains(context.IpV4()))
                    {
                        await next.Invoke();
                    }
                    else
                    {
                        await context.Response.WriteAsync("访问限制");
                    }
                }
                else if (Cfg.BlackList.Count > 0)
                {
                    if (Cfg.BlackList.Contains(context.IpV4()))
                    {
                        await context.Response.WriteAsync("黑名单");
                    }
                    else
                    {
                        await next.Invoke();
                    }
                }
                else
                {
                    await next.Invoke();
                }
            });
            //TODO 如何注入Manager
            app.UseMiddleware(typeof(UnitOfWorkMiddleware));
        }
        /// <summary>
        /// 自动对Ef迁移
        /// </summary>
        /// <param name="app"></param>
        /// <param name="dbContext"></param>
        public static void AutoMigration(this IApplicationBuilder app, AppDbContext dbContext)
        {
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                Console.WriteLine($"开始进行数据库迁移……");
                dbContext.Database.Migrate();
                Console.WriteLine("迁移完成");
            }
        }
    }
}
