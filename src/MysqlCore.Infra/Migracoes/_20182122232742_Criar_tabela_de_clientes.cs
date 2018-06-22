using FluentMigrator;

namespace MysqlCore.Infra.Migracoes
{
    [Migration(20182122232742, "Criação da tabela de clientes")]
    public class _20182122232742_Criar_tabela_de_clientes : ForwardOnlyMigration
    {
        internal static readonly string NomeDaTabela = "Cliente";

        public override void Up()
        {
            Create.Table(NomeDaTabela)
                .WithColumn("Id").AsInt32().PrimaryKey()
                .WithColumn("Nome").AsString(60).NotNullable()
                .WithColumn("Documento").AsString(20).NotNullable();
        }
    }
}
