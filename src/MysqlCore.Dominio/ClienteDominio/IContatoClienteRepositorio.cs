using System.Collections.Generic;

namespace MysqlCore.Dominio.ClienteDominio
{
    public interface IContatoClienteRepositorio
    {
        List<ContatoCliente> ObterTodos();
        void Incluir(params ContatoCliente[] contatoClientes);
        void Atualizar(params ContatoCliente[] contatoClientes);
        void Remover(params ContatoCliente[] contatoClientes);
    }
}
