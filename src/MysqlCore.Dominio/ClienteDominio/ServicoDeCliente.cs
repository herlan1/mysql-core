using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using MysqlCore.Dominio.Validadores;

namespace MysqlCore.Dominio.ClienteDominio
{
    public class ServicoDeCliente
    {
        private readonly IValidator<Cliente> _validadorDeCliente;
        private readonly IClienteRepositorio _clienteRepositorio;

        public ServicoDeCliente(
            IValidator<Cliente> validadorDeCliente,
            IClienteRepositorio clienteRepositorio)
        {
            _validadorDeCliente = validadorDeCliente;
            _clienteRepositorio = clienteRepositorio;
        }

        public Cliente Incluir(Cliente cliente)
        {
            _validadorDeCliente.ValideParaIncluir(cliente);

            var novoCliente = _clienteRepositorio.Incluir(cliente);

            return novoCliente;
        }
        
        public List<Cliente> ObterTodos()
        {
            var clientes = _clienteRepositorio.ObterTodos();

            return clientes;
        }

        public void Atualizar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Remover(Cliente cliente)
        {
            throw new NotImplementedException();
        }
    }
}
