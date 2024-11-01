namespace CadastroClientes.Repositorios
{
    public class ClienteRepository
    {
        private readonly List<Cliente> _clientes = new List<Cliente>();

        public List<Cliente> Listar() => _clientes;
        public Cliente ObterPorId(Guid id) => _clientes.FirstOrDefault(c => c.Id == id);
        public void Inserir(Cliente cliente) => _clientes.Add(cliente);
        public void Atualizar(Cliente cliente);
        public void Remover(Guid id);
    }
}
