using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MysqlCore.Dominio.Cliente;

namespace MysqlCore.Api.Controller
{

    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(
            IClienteRepositorio clienteRepositorio)
        {

            _clienteRepositorio = clienteRepositorio;

        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
