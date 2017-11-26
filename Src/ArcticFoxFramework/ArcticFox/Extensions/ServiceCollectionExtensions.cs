using ArcticFox.Attributes;
using ArcticFox.Configuration;
using ArcticFox.EntityFrameworkCore;
using ArcticFox.Repositories;
using ArcticFox.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArcticFox.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAFox(this IServiceCollection services, Action<AFoxConfiguration> actionSetup)
        {
            var options = new AFoxConfiguration();
            actionSetup.Invoke(options);
            services.AddSingleton(typeof(AppDbContext), Cfg.DbContextType);
            if (Cfg.EnableSwagger)
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc(Cfg.SwaggerInfo.Version, new Info { Title = Cfg.SwaggerInfo.Title, Version = Cfg.SwaggerInfo.Version });
                });
            }
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<UnitOfWorkManager>();
        }
    }
}
