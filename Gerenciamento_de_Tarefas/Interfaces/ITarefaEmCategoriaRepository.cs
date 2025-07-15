using Gerenciamento_de_Tarefas.Models;

namespace Gerenciamento_de_Tarefas.Interfaces;

public interface ITarefaEmCategoriaRepository 
{
    List<TarefaEmCategoria> ListarTodos();
    TarefaEmCategoria? BuscarPorId(int id);
    TarefaEmCategoria? Criar(TarefaEmCategoria tarefaEmCategoria);
    TarefaEmCategoria? Atualizar(int id, TarefaEmCategoria tarefaEmCategoria);
    TarefaEmCategoria? Deletar(int id);
}
