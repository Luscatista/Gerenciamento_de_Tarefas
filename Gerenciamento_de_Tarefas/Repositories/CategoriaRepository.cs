using Gerenciamento_de_Tarefas.Context;
using Gerenciamento_de_Tarefas.Interfaces;
using Gerenciamento_de_Tarefas.Models;

namespace Gerenciamento_de_Tarefas.Repositories;

public class CategoriaRepository : ICategoriaRepository
{
    private readonly GerenciadorTarefasContext _context;
    public CategoriaRepository(GerenciadorTarefasContext context)
    {
        _context = context;
    }
    public List<Categoria> ListarTodos()
    {
        return _context.Categorias.ToList();
    }
    public Categoria? BuscarPorId(int id)
    {
        return _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
    }
    public Categoria? BuscarPorUsuarioNomeCategoria(int usuarioId, string nomeCategoria)
    {
        return _context.Categorias.FirstOrDefault(c => c.UsuarioId == usuarioId && c.NomeCategoria == nomeCategoria);
    }
    public Categoria? Criar(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        _context.SaveChanges();

        return categoria;
    }
    public Categoria? Atualizar(int id, Categoria categoria)
    {
        var categoriaAtual = _context.Categorias.FirstOrDefault(c => c.CategoriaId == id);
        if (categoriaAtual == null) return null;
        
        categoriaAtual.NomeCategoria = categoria.NomeCategoria;
        categoriaAtual.UsuarioId = categoria.UsuarioId;
        _context.SaveChanges();

        return categoriaAtual;
    }
    public Categoria? Deletar(int id)
    {
        var categoria = _context.Categorias.Find(id);
        if (categoria == null)
        {
            throw new Exception();
        }

        _context.Categorias.Remove(categoria);
        _context.SaveChanges();

        return categoria;
    }
}
