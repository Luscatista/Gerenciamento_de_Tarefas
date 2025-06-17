namespace Gerenciamento_de_Tarefas.Models;

public class Tarefa
{
    public int TarefaId { get; set; }
    public string Titulo { get; set; }
    public string? Descricao { get; set; }
    public string Imagem { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataEdicao { get; set; }
    public bool Arquivada { get; set; } = false;
    public Usuario? Usuario { get; set; }
    public int? UsuarioId { get; set; }
    public List<TarefaEmCategoria> TarefasEmCategorias { get; set; } = new();

}
