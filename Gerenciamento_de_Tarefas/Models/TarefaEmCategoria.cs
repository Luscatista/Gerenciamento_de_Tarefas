namespace Gerenciamento_de_Tarefas.Models;

public class TarefaEmCategoria
{
    public int TarefaEmCategoriaId { get; set; }
    public Categoria? Categoria { get; set; }
    public int? CategoriaId { get; set; }
    public Tarefa? Tarefa { get; set; }
    public int? TarefaId { get; set; }
}
