using Gerenciamento_de_Tarefas.DTOs;
using Gerenciamento_de_Tarefas.Models;

namespace Gerenciamento_de_Tarefas.Interfaces;

public interface ITarefaRepository
{
    List<Tarefa> ListarTodos();
    Tarefa? BuscarPorId(int id);
    TarefaDto? Criar(TarefaDto tarefaDto);
    TarefaDto? Atualizar(int id, TarefaDto tarefaDto);
    Tarefa? Deletar(int id);
}
