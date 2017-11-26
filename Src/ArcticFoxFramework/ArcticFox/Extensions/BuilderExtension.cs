using ArcticFox.Configuration;
using ArcticFox.Interceptors;
using ArcticFox.Uow;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

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
                if (Cfg.BlackList.Contains(context.IpV4()))
                {
                    await context.Response.WriteAsync("黑名单");
                }
                else
                {
                    await next.Invoke();
                }
            });
            //TODO 如何注入Manager
            app.UseMiddleware(typeof(UnitOfWorkMiddleware));
        }
    }
}
