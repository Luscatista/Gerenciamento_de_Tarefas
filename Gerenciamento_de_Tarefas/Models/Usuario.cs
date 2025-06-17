namespace Gerenciamento_de_Tarefas.Models;

public class Usuario
{
    public int UsuarioId { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public List<Tarefa> Tarefas { get; set; } = new();
    public List<Categoria> Categorias { get; set; } = new();

}
