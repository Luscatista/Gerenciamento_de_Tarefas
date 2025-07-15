using Gerenciamento_de_Tarefas.Interfaces;
using Gerenciamento_de_Tarefas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciamento_de_Tarefas.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;
    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpGet]
    public IActionResult ListarTodos()
    {
        return Ok(_usuarioRepository.ListarTodos());
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(int id)
    {
        var usuario = _usuarioRepository.BuscarPorId(id);
        if (usuario == null)
        {
            return NotFound("Usuário não encontrado.");
        }

        return Ok(usuario);
    }

    [HttpPost]
    public IActionResult Cadastrar(Usuario usuario)
    {
        List<Usuario> listaUsuario = _usuarioRepository.ListarTodos();
        foreach (var item in listaUsuario)
        {
            if (item.Email == usuario.Email)
            {
                return BadRequest("E-mail já cadastrado.");
            }
        }
        _usuarioRepository.Criar(usuario);

        return Ok(usuario);
    }

    [HttpPut("{id}")]
    public IActionResult Editar(int id, Usuario usuario)
    {
        try
        {
            var usuarioEditado = _usuarioRepository.Atualizar(id, usuario);
            if (usuarioEditado == null)
            {
                return BadRequest("Usuario não encontrado.");
            }
            return Ok(usuarioEditado);
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
            var usuario = _usuarioRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound("Usuário não encontrado.");
        }
    }
}
