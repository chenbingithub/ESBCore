using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Abp.AspNetCore;
using Abp.Castle.Logging.Log4Net;
using Abp.Hangfire;
using Castle.Facilities.Logging;
using ESBCore.Configuration;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ESBCore.WebApi
{
    public class Startup
    {
      private IConfiguration Configuration { get; }
      public Startup(IHostingEnvironment env)
      {
        Configuration = env.GetAppConfiguration();
      }

    

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddHangfire(x => {
                var connectionString = Configuration.GetConnectionString("hangfire.redis");
                x.UseRedisStorage(connectionString);
            });
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
          services.AddSwaggerGen(options =>
          {
            options.SwaggerDoc("v1", new Info { Title = "API", Version = "v1" });
            options.DocInclusionPredicate((docName, description) => true);

            // Define the BearerAuth scheme that's in use
            options.AddSecurityDefinition("bearerAuth", new ApiKeyScheme()
            {
              Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
              Name = "Authorization",
              In = "header",
              Type = "apiKey"
            });
          });

      // Configure Abp and Dependency Injection
      return services.AddAbp<ESBCoreWebApiModule>(
                // Configure Log4Net logging
                options => options.IocManager.IocContainer.AddFacility<LoggingFacility>(
                    f => f.UseAbpLog4Net().WithConfig("log4net.config")
                )
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
         

          app.UseAbp(options => { options.UseAbpRequestLocalization = false; }); // Initializes ABP framework.
          app.UseAbpRequestLocalization();
          app.UseHangfireServer();
            app.UseHangfireDashboard();
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new AbpHangfireAuthorizationFilter() }
            });
            app.UseMvc(routes =>
            {
              routes.MapRoute(
                name: "defaultWithArea",
                template: "{area}/{controller=Home}/{action=Index}/{id?}");

              routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
            });
          // Enable middleware to serve generated Swagger as a JSON endpoint
          app.UseSwagger();
          // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
          app.UseSwaggerUI(options =>
          {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");

            options.IndexStream = () => Assembly.GetExecutingAssembly()
              .GetManifestResourceStream("ESBCore.WebApi.wwwroot.swagger.ui.index.html");
          }); // URL: /swagger
    }
    }
}
