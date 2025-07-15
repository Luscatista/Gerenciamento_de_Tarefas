using Gerenciamento_de_Tarefas.DTOs;
using Gerenciamento_de_Tarefas.Interfaces;
using Gerenciamento_de_Tarefas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciamento_de_Tarefas.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TarefaController : ControllerBase
{
    private readonly ITarefaRepository _tarefaRepository;
    public TarefaController(ITarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }

    [HttpGet]
    public IActionResult ListarTodos()
    {
        return Ok(_tarefaRepository.ListarTodos());
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var tarefa = _tarefaRepository.BuscarPorId(id);
        if (tarefa == null)
        {
            return NotFound("Tarefa não encontrada.");
        }

        return Ok(tarefa);
    }

    [HttpPost]
    public IActionResult Cadastrar(TarefaDto tarefaDto)
    {
        List<Tarefa> listaTarefas = _tarefaRepository.ListarTodos();
        foreach (var item in listaTarefas)
        {
            if (item.Titulo == tarefaDto.Titulo)
            {
                return BadRequest("Título já cadastrado.");
            }
        }
        _tarefaRepository.Criar(tarefaDto);

        return Ok(tarefaDto);
    }

    [HttpPut("{id}")]
    public IActionResult Editar(int id, TarefaDto tarefaDto)
    {
        try
        {
            var tarefaEditada = _tarefaRepository.Atualizar(id, tarefaDto);
            if (tarefaEditada == null)
            {
                return BadRequest("Tarefa não encontrada.");
            }
            return Ok(tarefaEditada);
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
            var tarefa = _tarefaRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound("Tarefa não encontrada.");
        }
    }
}
