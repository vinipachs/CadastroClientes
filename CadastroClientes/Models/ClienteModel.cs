namespace CadastroClientes.Models
{
    public class ClienteModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Email { get; set; }
    }
}
