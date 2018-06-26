using System.Collections.Generic;

namespace MysqlCore.Dominio.Cliente
{
    public class Cliente
    {
        public Cliente()
        {
            ContatosDoCliente = new List<ContatoCliente>();
        }

        public int Id { get; set; }
        public string Documento { get; set; }
        public List<ContatoCliente> ContatosDoCliente { get; set; }
    }
}
