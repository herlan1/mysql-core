using System.Collections.Generic;

namespace MysqlCore.Dominio.Cliente
{
    public interface IClienteRepositorio
    {
        List<Cliente> ObterTodos();
        void Incluir(params Cliente[] clientes);
        void Atualizar(params Cliente[] clientes);
        void Remover(params Cliente[] clientes);
    }
}
