using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ArcticFox.Extensions;
using ArcticFox.Host.Exceptions;
using ArcticFox.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ArcticFox.Interceptors;

namespace ArcticFox.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAFox(options =>
            {
                options.Swagger(info: new Swashbuckle.AspNetCore.Swagger.Info { Title = "Web api", Version = "v2", Description = "描述" });
                options.UseDbContext<AFDbContext>();
                options.BlackList(Configuration.GetSection("blacklist").Get<List<string>>());
            });
            services.AddCors();
            services.AddMvc();
            // Sqlserver的字符串配置，读取appsettings.json中的ConnectionStrings中的Default
            services.AddEntityFrameworkSqlServer().AddDbContextPool<AFDbContext>((serviceProvider, options) => options.UseSqlServer(Configuration.GetConnectionString("Default")).UseInternalServiceProvider(serviceProvider));
            // 缓存服务
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.AddAFox();
            app.UseMiddleware<ExceptionEvent>();
            app.UseMvc();
        }
    }
}
