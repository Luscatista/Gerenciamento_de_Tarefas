using Gerenciamento_de_Tarefas.Models;

namespace Gerenciamento_de_Tarefas.ViewModels;

public class TarefaViewModel
{
    public int TarefaId { get; set; }
    public string Titulo { get; set; }
    public string? Descricao { get; set; }
    public string? Imagem { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataEdicao { get; set; }
    public bool Arquivada { get; set; } = false;
    public int UsuarioId { get; set; }
    public List<int> listaCategoria { get; set; }
}
