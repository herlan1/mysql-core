﻿using System.Collections.Generic;

namespace MysqlCore.Dominio.Cliente
{
    public interface IContatoClienteRepositorio
    {
        List<ContatoCliente> ObterTodos();
        void Incluir(params ContatoCliente[] contatoClientes);
        void Atualizar(params ContatoCliente[] contatoClientes);
        void Remover(params ContatoCliente[] contatoClientes);
    }
}
