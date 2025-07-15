using Gerenciamento_de_Tarefas.Interfaces;
using Gerenciamento_de_Tarefas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciamento_de_Tarefas.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaRepository _categoriaRepository;
    public CategoriaController(ICategoriaRepository categoriaRepository)
    {
        _categoriaRepository = categoriaRepository;
    }

    [HttpGet]
    public IActionResult ListarTodos()
    {
        return Ok(_categoriaRepository.ListarTodos());
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var categoria = _categoriaRepository.BuscarPorId(id);
        if (categoria == null)
        {
            return NotFound("Categoria não encontrada.");
        }

        return Ok(categoria);
    }

    [HttpPost]
    public IActionResult Cadastrar(Categoria categoria)
    {
        List<Categoria> listaCategoria = _categoriaRepository.ListarTodos();
        foreach (var item in listaCategoria)
        {
            if (item.NomeCategoria == categoria.NomeCategoria)
            {
                return BadRequest("Categoria já existe.");
            }
        }
        _categoriaRepository.Criar(categoria);

        return Ok(categoria);
    }

    [HttpPut("{id}")]
    public IActionResult Editar(int id, Categoria categoria)
    {
        try
        {
            var categoriaEditada = _categoriaRepository.Atualizar(id, categoria);
            if (categoriaEditada == null)
            {
                return BadRequest("Categoria não encontrada.");
            }
            return Ok(categoriaEditada);
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
            var categoria = _categoriaRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound("Categoria não encontrada.");
        }
    }
}
