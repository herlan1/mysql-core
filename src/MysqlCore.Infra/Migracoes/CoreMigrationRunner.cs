using System;
using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using MysqlCore.Comum;
using MysqlCore.Dominio.Migracoes;

namespace MysqlCore.Infra.Migracoes
{
    public class CoreMigrationRunner : ICoreMigrationRunner
    {
        public void MigrateUpAll()
        {

            var assembly = Assembly.GetAssembly(typeof(CoreMigrationRunner));

            var serviceProvider = new ServiceCollection()
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .AddFluentMigratorCore()
                .ConfigureRunner(
                    builder => builder
                        .AddMySql5()
                        .WithGlobalConnectionString(Runtime.ConnectionString)
                        .WithMigrationsIn(assembly))
                .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {

                try
                {
                    var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                    runner.MigrateUp();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }
    }
}
