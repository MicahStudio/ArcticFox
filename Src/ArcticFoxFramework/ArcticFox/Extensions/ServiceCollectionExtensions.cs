using ArcticFox.Configuration;
using ArcticFox.EntityFrameworkCore;
using ArcticFox.Repositories;
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
        public static void AddAFox(this IServiceCollection services, Type dbContextType, bool EnableSwagger = true)
        {
            services.AddScoped(typeof(AFDbContextBase), dbContextType);
            if (EnableSwagger)
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "ArcticFox Web Api", Version = "v1" });
                });
            }
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        }
    }
}
