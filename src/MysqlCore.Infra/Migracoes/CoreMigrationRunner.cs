using System;
using System.Linq;
using System.Reflection;
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors.MySql;
using MysqlCore.Comum;
using MysqlCore.Dominio.Migracoes;

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
            return GetMigrationRunner();
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
                Namespace = "MysqlCore",
                Connection = connectionString
            };

            var options = new MigrationOptions { PreviewOnly = false, Timeout = 60 };

            var factory = new MySql5ProcessorFactory();

            var processor = factory.Create(connectionString, announcer, options);

            var runner = new MigrationRunner(assembly, migrationContext, processor);

            return runner;
        }

        public class MigrationOptions : IMigrationProcessorOptions
        {
            public bool PreviewOnly { get; set; }
            public int? Timeout { get; set; }
            public string ProviderSwitches { get; protected set; }
        }
    }
}
