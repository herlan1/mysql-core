using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using MysqlCore.Comum;
using MysqlCore.Dominio.ClienteDominio;
using MySql.Data.MySqlClient;

namespace MysqlCore.Infra.ClienteInfra
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public List<Cliente> ObterTodos()
        {
            const string sql = "select * from cliente;";

            using (var connection = new MySqlConnection(Runtime.ConnectionString))
            {
                connection.Open();

                using (var multi = connection.QueryMultiple(sql))
                {
                    return multi.Read<Cliente>().ToList();
                }
            }
        }

        public Cliente Incluir(params Cliente[] clientes)
        {
            const string sql = "insert into cliente (Id, Nome, Documento) Values (@Id, @Nome, @Documento);";


            using (var connection = new MySqlConnection(Runtime.ConnectionString))
            {
                connection.Open();

                var affectedRows = connection.Execute(sql, clientes);
            }

            return new Cliente();
        }

        public void Atualizar(params Cliente[] clientes)
        {
            throw new NotImplementedException();
        }

        public void Remover(params Cliente[] clientes)
        {
            throw new NotImplementedException();
        }
    }
}
