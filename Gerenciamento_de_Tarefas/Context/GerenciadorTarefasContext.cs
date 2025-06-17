using Gerenciamento_de_Tarefas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Gerenciamento_de_Tarefas.Context;

public class GerenciadorTarefasContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<TarefaEmCategoria> TarefasEmCategoria { get; set; }

    private readonly IConfiguration _configuration;

    public GerenciadorTarefasContext(DbContextOptions<GerenciadorTarefasContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var con = _configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseSqlServer(con);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(
            entity =>
            {
                entity.HasKey(u => u.UsuarioId);
                entity.Property(u => u.Nome).HasMaxLength(100).IsRequired().IsUnicode(false);
                entity.Property(u => u.Email).HasMaxLength(120).IsRequired().IsUnicode(false);
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.Senha).HasMaxLength(255).IsRequired().IsUnicode(false);
            });
    }
}
