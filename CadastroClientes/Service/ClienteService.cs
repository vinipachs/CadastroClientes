namespace CadastroClientes.Service
{
    public class ClienteService
    {
        public bool ValidarCPF(string cpf);
        public bool ValidarEmail(string email);
        public bool ValidarNome(string nome) => !string.IsNullOrWhiteSpace(nome);
    }
}
