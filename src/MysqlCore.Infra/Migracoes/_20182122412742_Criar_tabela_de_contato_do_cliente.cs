using FluentMigrator;

namespace MysqlCore.Infra.Migracoes
{
    [Migration(20182122412742, "Criação da tabela de contato do cliente")]
    public class _20182122412742_Criar_tabela_de_contato_do_cliente : ForwardOnlyMigration
    {
        internal static readonly string NomeDaTabela = "ContatoDoCliente";

        public override void Up()
        {
            Create.Table(NomeDaTabela)
                .WithColumn("Id").AsInt32().PrimaryKey()
                .WithColumn("IdDoCliente").AsInt32()
                .ForeignKey(_20182122232742_Criar_tabela_de_clientes.NomeDaTabela, "Id")
                .WithColumn("Telefone").AsString(20).Nullable()
                .WithColumn("Email").AsString(80).Nullable();
        }
    }
}
