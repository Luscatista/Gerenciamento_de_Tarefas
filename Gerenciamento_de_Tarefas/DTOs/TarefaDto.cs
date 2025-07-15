using Gerenciamento_de_Tarefas.Models;

namespace Gerenciamento_de_Tarefas.DTOs;

public class TarefaDto
{
    public string Titulo { get; set; }
    public string? Descricao { get; set; }
    public string? Imagem { get; set; }
    public DateTime DataCriacao { get; set; }
    public int UsuarioId { get; set; }
    public string NomeCategoria { get; set; }
}
