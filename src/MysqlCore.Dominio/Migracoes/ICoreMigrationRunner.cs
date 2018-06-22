using FluentMigrator.Runner;

namespace MysqlCore.Dominio.Migracoes
{
    public interface ICoreMigrationRunner
    {
        void MigrateUpAll();
        void MigrateDownAll();
        bool TherIsMigrationWithoutRun();
        MigrationRunner ObterMigrationRunner();
        string Description { get; set; }
        string NomeDoBancoDoAddon { get; set; }
    }
}
