using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MysqlCore.Comum;

namespace MysqlCore.Api
{
    public class Startup
    {

        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = configurationBuilder.Build();

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddCors();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();

            Runtime.ConnectionString = Configuration.GetConnectionString("connection");
        }
    }
}
