using Gerenciamento_de_Tarefas.Context;
using Gerenciamento_de_Tarefas.Interfaces;
using Gerenciamento_de_Tarefas.Models;

namespace Gerenciamento_de_Tarefas.Repositories;

public class TarefaEmCategoriaRepository : ITarefaEmCategoriaRepository
{
    private readonly GerenciadorTarefasContext _context;
    public TarefaEmCategoriaRepository(GerenciadorTarefasContext context)
    {
        _context = context;
    }
    public List<TarefaEmCategoria> ListarTodos()
    {
        return _context.TarefasEmCategoria.ToList();
    }
    public TarefaEmCategoria? BuscarPorId(int id)
    {
        return _context.TarefasEmCategoria.FirstOrDefault(t => t.TarefaEmCategoriaId == id);
    }
    public TarefaEmCategoria? Criar(TarefaEmCategoria tc)
    {
        _context.TarefasEmCategoria.Add(tc);
        _context.SaveChanges();
        return tc;
    }
    public TarefaEmCategoria? Atualizar(int id, TarefaEmCategoria tc)
    {
        var tCategoria = _context.TarefasEmCategoria.FirstOrDefault(t => t.TarefaEmCategoriaId == id);
        if (tCategoria == null) return null;

        tCategoria.TarefaId = tc.TarefaId;
        tCategoria.CategoriaId = tc.CategoriaId;
        _context.SaveChanges();

        return tCategoria;
    }
    public TarefaEmCategoria? Deletar(int id)
    {
        var tCategoria = _context.TarefasEmCategoria.Find(id);
        if(tCategoria == null)
        {
            throw new Exception();
        }
        _context.TarefasEmCategoria.Remove(tCategoria);
        _context.SaveChanges();

        return tCategoria;
    }
}
