using System;
using System.Collections.Generic;
using System.Linq;
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
          if (env.IsDevelopment())
          {
            app.UseDeveloperExceptionPage();
          }
          else
          {
            app.UseHsts();
          }

          app.UseHttpsRedirection();
      app.UseAbp(options => { options.UseAbpRequestLocalization = false; }); // Initializes ABP framework.
            
            app.UseHangfireServer();
            app.UseHangfireDashboard();
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new AbpHangfireAuthorizationFilter() }
            });
            app.UseMvc();
        }
    }
}
