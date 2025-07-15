using Gerenciamento_de_Tarefas.Models;

namespace Gerenciamento_de_Tarefas.Interfaces;

public interface IUsuarioRepository
{
    List<Usuario> ListarTodos();
    Usuario? BuscarPorId(int id);
    Usuario? Criar(Usuario usuario);
    Usuario? Atualizar(int id, Usuario usuario);
    Usuario? Deletar(int id);
}
