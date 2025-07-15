using Gerenciamento_de_Tarefas.Models;

namespace Gerenciamento_de_Tarefas.Interfaces;

public interface ICategoriaRepository
{
    Categoria? BuscarPorUsuarioNomeCategoria(int usuarioId, string nomeCategoria);
    List<Categoria> ListarTodos();
    Categoria? BuscarPorId(int id);
    Categoria? Criar(Categoria categoria);
    Categoria? Atualizar(int id, Categoria categoria);
    Categoria? Deletar(int id);
}
