using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Text;
using Dapper;
using MysqlCore.Dominio.Cliente;

namespace MysqlCore.Infra.Cliente
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public List<Dominio.Cliente.Cliente> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Incluir(params Dominio.Cliente.Cliente[] clientes)
        {
            const string sql = "inset into cliente (CustomerName) Values (@CustomerName);";

            using (var connection = new SqlCeConnection(""))
            {
                connection.Open();

                var affectedRows = connection.Execute(sql, clientes);
            }
        }

        public void Atualizar(params Dominio.Cliente.Cliente[] clientes)
        {
            throw new NotImplementedException();
        }

        public void Remover(params Dominio.Cliente.Cliente[] clientes)
        {
            throw new NotImplementedException();
        }
    }
}
