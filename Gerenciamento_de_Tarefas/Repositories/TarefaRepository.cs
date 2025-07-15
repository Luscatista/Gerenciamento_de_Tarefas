using Gerenciamento_de_Tarefas.Context;
using Gerenciamento_de_Tarefas.DTOs;
using Gerenciamento_de_Tarefas.Interfaces;
using Gerenciamento_de_Tarefas.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Gerenciamento_de_Tarefas.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly GerenciadorTarefasContext _context;
    private readonly ICategoriaRepository _categoriaRepository;

    public TarefaRepository(GerenciadorTarefasContext context, ICategoriaRepository categoriaRepository)
    {
        _context = context;
        _categoriaRepository = categoriaRepository;
    }
    public List<Tarefa> ListarTodos()
    {
        return _context.Tarefas.ToList();
    }
    public Tarefa? BuscarPorId(int id)
    {
        return _context.Tarefas.FirstOrDefault(t => t.TarefaId == id);
    }
    public TarefaDto? Criar(TarefaDto tarefaDto)
    {
        List<int> categoriaId = new List<int>(); 
        Categoria? categoria = _categoriaRepository.BuscarPorUsuarioNomeCategoria(tarefaDto.UsuarioId, tarefaDto.NomeCategoria);

        if(categoria == null)
        {
            Categoria categoriaNova = new Categoria
            {
                NomeCategoria = tarefaDto.NomeCategoria,
                UsuarioId = tarefaDto.UsuarioId
            };

            _categoriaRepository.Criar(categoriaNova);
            _context.SaveChanges();

            categoriaId.Add(categoriaNova.CategoriaId);
        } else
        {
            categoriaId.Add(categoria.CategoriaId);
        }

            Tarefa tarefa = new Tarefa
            {
                Titulo = tarefaDto.Titulo,
                Descricao = tarefaDto.Descricao,
                Imagem = tarefaDto.Imagem,
                DataCriacao = DateTime.Now,
                UsuarioId = tarefaDto.UsuarioId
            };

        _context.Tarefas.Add(tarefa);
        _context.SaveChanges();

        foreach (var item in categoriaId)
        {
            TarefaEmCategoria tCategoria = new TarefaEmCategoria
            {
                TarefaId = tarefa.TarefaId,
                CategoriaId = item
            };

            _context.Add(tCategoria);
            _context.SaveChanges();
        }

        return tarefaDto;
    }
    public TarefaDto? Atualizar(int id, TarefaDto tarefaDto)
    {
        var tarefaAtual = _context.Tarefas.FirstOrDefault(t => t.TarefaId == id);
        if (tarefaAtual == null) return null;

        tarefaAtual.Titulo = tarefaDto.Titulo;
        tarefaAtual.Descricao = tarefaDto.Descricao;
        tarefaAtual.Imagem = tarefaDto.Imagem;
        tarefaAtual.DataEdicao = DateTime.Now;
        tarefaAtual.UsuarioId = tarefaDto.UsuarioId;

        _context.SaveChanges();

        return tarefaDto;
    }
    public Tarefa? Deletar(int id)
    {
        var tarefa = _context.Tarefas.Find(id);
        if (tarefa == null)
        {
            throw new Exception();
        }
        _context.Tarefas.Remove(tarefa);
        _context.SaveChanges();

        return tarefa;
    }
}
