using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MysqlCore.Dominio.ClienteDominio;

namespace MysqlCore.Api.Controller
{

    public class ClienteController : BaseController
    {

        private readonly ServicoDeCliente _servicoCliente;

        public ClienteController(
            ServicoDeCliente servicoCliente)
        {

            _servicoCliente = servicoCliente;

        }

        [HttpPost]
        [Route("v1/cliente")]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody]Cliente cliente)
        {
            var clienter = _servicoCliente.Incluir(cliente);

            return await Response(clienter);
        }

        [HttpGet]
        [Route("v1/getcliente")]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(_servicoCliente.ObterTodos());
        }
    }
}
