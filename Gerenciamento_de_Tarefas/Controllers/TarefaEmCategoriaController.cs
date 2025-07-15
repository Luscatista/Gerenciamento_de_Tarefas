using Gerenciamento_de_Tarefas.Interfaces;
using Gerenciamento_de_Tarefas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciamento_de_Tarefas.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TarefaEmCategoriaController : ControllerBase
{
    private readonly ITarefaEmCategoriaRepository _tarefaEmCategoriaRepository;
    public TarefaEmCategoriaController(ITarefaEmCategoriaRepository tarefaEmCategoriaRepository)
    {
        _tarefaEmCategoriaRepository = tarefaEmCategoriaRepository;
    }

    [HttpGet]
    public IActionResult ListarTodos()
    {
        return Ok(_tarefaEmCategoriaRepository.ListarTodos());
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var tCategoria = _tarefaEmCategoriaRepository.BuscarPorId(id);
        if (tCategoria == null)
        {
            return NotFound("Não encontrado.");
        }

        return Ok(tCategoria);
    }

    [HttpPost]
    public IActionResult Cadastrar(TarefaEmCategoria tCategoria)
    {
        _tarefaEmCategoriaRepository.Criar(tCategoria);

        return Ok(tCategoria);
    }

    [HttpPut("{id}")]
    public IActionResult Editar(int id, TarefaEmCategoria tCategoria)
    {
        try
        {
            var tCategoriaEditada = _tarefaEmCategoriaRepository.Atualizar(id, tCategoria);
            if (tCategoriaEditada == null)
            {
                return BadRequest("Não encontrado.");
            }
            return Ok(tCategoriaEditada);
        }
        catch (ArgumentException)
        {
            return NotFound("Dados inválidos.");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(int id)
    {
        try
        {
            var tCategoria = _tarefaEmCategoriaRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound("Não encontrado.");
        }
    }
}
