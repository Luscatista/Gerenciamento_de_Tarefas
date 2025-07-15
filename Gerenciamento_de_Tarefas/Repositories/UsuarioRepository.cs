using Gerenciamento_de_Tarefas.Context;
using Gerenciamento_de_Tarefas.Interfaces;
using Gerenciamento_de_Tarefas.Models;
using Gerenciamento_de_Tarefas.Services;
using Microsoft.AspNetCore.Identity;

namespace Gerenciamento_de_Tarefas.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly GerenciadorTarefasContext _context;
    public UsuarioRepository(GerenciadorTarefasContext context)
    {
        _context = context;
    }
    public List<Usuario> ListarTodos()
    {
        return _context.Usuarios.ToList();
    }
    public Usuario? BuscarPorId(int id)
    {    
        return _context.Usuarios.FirstOrDefault(u => u.UsuarioId == id);
    }
    public Usuario? Criar(Usuario usuario)
    {
        var passwordService = new PasswordService();
        usuario.Senha = passwordService.HashPassword(usuario);

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();

        return usuario;
    }
    public Usuario? Atualizar(int id, Usuario usuario)
    {
        var usuarioAtual = _context.Usuarios.Find(id);
        if (usuarioAtual == null)return null;
        
        usuarioAtual.Nome = usuario.Nome; 
        usuarioAtual.Email = usuario.Email;
        usuarioAtual.Senha = usuario.Senha;

        var passwordService = new PasswordService();
        usuarioAtual.Senha = passwordService.HashPassword(usuarioAtual);

        _context.SaveChanges();

        return usuarioAtual;
    }
    public Usuario? Deletar(int id)
    {
        var usuario = _context.Usuarios.Find(id);
        if (usuario == null)
        {
            throw new Exception();
        }
                
        _context.Usuarios.Remove(usuario);
        _context.SaveChanges();

        return usuario;
    }
}