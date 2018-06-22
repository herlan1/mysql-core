using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Processors.MySql;
using FluentMigrator.Runner.Processors.SqlServer;
using MysqlCore.Comum;
using MysqlCore.Dominio.Migracoes;
#pragma warning disable 612

namespace MysqlCore.Infra.Migracoes
{
    public class CoreMigrationRunner : ICoreMigrationRunner
    {

        public void MigrateUpAll()
        {
            var migration = ObterMigrationRunner();
            migration.MigrateUp();
        }

        public void MigrateDownAll()
        {
            var migration = ObterMigrationRunner();
            migration.MigrateDown(0);
        }

        public bool TherIsMigrationWithoutRun()
        {
            var migrationRunner = ObterMigrationRunner();

            var listMigrations = migrationRunner.MigrationLoader.LoadMigrations();

            migrationRunner.VersionLoader.LoadVersionInfo();

            return listMigrations.Last().Key != migrationRunner.VersionLoader.VersionInfo.Latest();
        }

        public MigrationRunner ObterMigrationRunner()
        {
            throw new NotImplementedException();
        }

        private MigrationRunner GetMigrationRunner()
        {

            var connectionString = Runtime.ConnectionString;

            var announcer = new TextWriterAnnouncer(s =>
            {
                System.Diagnostics.Debug.WriteLine(s);
                Console.WriteLine(s);
            });

            var assembly = Assembly.GetExecutingAssembly();

            var migrationContext = new RunnerContext(announcer)
            {
                NestedNamespaces = true,
                Namespace = "Negocio.Migrator",
                Connection = connectionString
            };


            var options = new MigrationOptions { PreviewOnly = false, Timeout = 60 };

            var factory =
                new SqlServer2014ProcessorFactory();

            var processor = factory.Create(connectionString, announcer, options);

            var runner = new MigrationRunner(Assembly, migrationContext, processor);

            return runner;

            //using (var processor = factory.Create(connectionString, announcer, options))
            //{
            //    var runner = new MigrationRunner(assembly, migrationContext, processor);
            //    runner.MigrateUp(true);
            //}

            //var announcer = new TextWriterAnnouncer(Console.WriteLine);

            //var migrationContext = new RunnerContext(announcer)
            //{
            //    Namespace = Namespace,
            //    Timeout = int.MaxValue
            //};

            ////DbConnectionString.DbName = NomeDoBancoDoAddon;

            //var options = new MigrationOptions { PreviewOnly = false, Timeout = 60 };

            //var factory =
            //    DbConnectionString.IsHana
            //        ? new MySql5ProcessorFactory() as IMigrationProcessorFactory
            //        : new SqlServer2008ProcessorFactory();

            //var processor = factory.Create(DbConnectionString.ConnectionStringDoAddon, announcer, options);

            //var runner = new MigrationRunner(Assembly, migrationContext, processor);

            //return runner;
        }

        protected string ConnectionStringName { get; }

        protected Assembly Assembly { get; }

        protected string Namespace { get; set; }

        public string Description { get; set; }

        //public IDbConnectionString DbConnectionString { get; set; }

        public class MigrationOptions : IMigrationProcessorOptions
        {
            public bool PreviewOnly { get; set; }
            public int? Timeout { get; set; }
            public string ProviderSwitches { get; protected set; }
        }
    }
}
