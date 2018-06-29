using System.Collections.Generic;

namespace MysqlCore.Dominio.ClienteDominio
{
    public interface IClienteRepositorio
    {
        List<Cliente> ObterTodos();
        Cliente Incluir(params Cliente[] clientes);
        void Atualizar(params Cliente[] clientes);
        void Remover(params Cliente[] clientes);
    }
}
