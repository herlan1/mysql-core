namespace MysqlCore.Dominio.Cliente
{
    public class ContatoCliente
    {
        public int Id { get; set; }
        public int IdDoCliente { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}
