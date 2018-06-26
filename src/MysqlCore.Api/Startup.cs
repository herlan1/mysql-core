using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MysqlCore.Comum;
using MysqlCore.Dominio.Cliente;
using MysqlCore.Dominio.Migracoes;
using MysqlCore.Infra.Cliente;
using MysqlCore.Infra.Migracoes;

namespace MysqlCore.Api
{
    public class Startup
    {

        public IConfiguration Configuration { get; set; }

        private ICoreMigrationRunner _migrationRunner;

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

            services.AddTransient<ICoreMigrationRunner, CoreMigrationRunner>();
            services.AddTransient<IClienteRepositorio, ClienteRepositorio>();

            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory, ICoreMigrationRunner migrationRunner)
        {

            loggerFactory.AddConsole();

            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();

            _migrationRunner = migrationRunner;

            _migrationRunner.MigrateUpAll();

            Runtime.ConnectionString = Configuration.GetConnectionString("connection");
        }
    }
}
