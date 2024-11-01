using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly ClienteRepository _repository;
    private readonly ClienteService _service;

    public ClientesController(ClienteRepository repository, ClienteService service)
    {
        _repository = repository;
        _service = service;
    }

    [HttpPost]
    public IActionResult InserirCliente(Cliente cliente)
    {
        if (!_service.ValidarCPF(cliente.CPF) || !_service.ValidarEmail(cliente.Email) || !_service.ValidarNome(cliente.Nome))
            return BadRequest("Dados inválidos.");

        _repository.Inserir(cliente);
        return CreatedAtAction(nameof(ObterCliente), new { id = cliente.Id }, cliente);
    }

    [HttpGet]
    public IActionResult ListarClientes() => Ok(_repository.Listar());

    [HttpGet("{id}")]
    public IActionResult ObterCliente(Guid id)
    {
        var cliente = _repository.ObterPorId(id);
        return cliente == null ? NotFound() : Ok(cliente);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarCliente(Guid id, Cliente clienteAtualizado)
    {
        var cliente = _repository.ObterPorId(id);
        if (cliente == null) return NotFound();

        if (!_service.ValidarCPF(clienteAtualizado.CPF) || !_service.ValidarEmail(clienteAtualizado.Email) || !_service.ValidarNome(clienteAtualizado.Nome))
            return BadRequest("Dados inválidos.");

        cliente.Nome = clienteAtualizado.Nome;
        cliente.CPF = clienteAtualizado.CPF;
        cliente.Email = clienteAtualizado.Email;
        _repository.Atualizar(cliente);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarCliente(Guid id)
    {
        var cliente = _repository.ObterPorId(id);
        if (cliente == null) return NotFound();

        _repository.Remover(id);
        return NoContent();
    }
}
