namespace Gerenciamento_de_Tarefas.Models;

public class Categoria
{
    public int CategoriaId { get; set; }
    public string? NomeCategoria { get; set; }
    public Usuario? Usuario { get; set; }
    public int? UsuarioId { get; set; }
    public List<TarefaEmCategoria> TarefasEmCategoria { get; set; } = new();
}
