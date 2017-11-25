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
            services.AddScoped(typeof(AppDbContext), Cfg.DbContextType);
            if (Cfg.EnableSwagger)
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "ArcticFox Web Api", Version = "v1" });
                });
            }
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<UnitOfWorkManager>();
        }
    }
}
