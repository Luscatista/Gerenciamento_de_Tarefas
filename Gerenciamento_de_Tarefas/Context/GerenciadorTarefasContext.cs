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

        modelBuilder.Entity<Tarefa>(
            entity =>
            {
                entity.HasKey(t => t.TarefaId);

                entity.Property(t => t.Titulo).HasMaxLength(100).IsRequired().IsUnicode(false);

                entity.HasIndex(t => t.Titulo).IsUnique();

                entity.Property(t => t.Descricao).HasMaxLength(100).IsRequired().IsUnicode(false);

                entity.Property(t => t.Imagem).HasMaxLength(100).IsRequired().IsUnicode(false);

                entity.Property(t => t.DataCriacao).IsRequired();

                entity.Property(t => t.DataEdicao);

                entity.Property(t => t.Arquivada).IsUnicode(false);

                entity.HasOne(u => u.Usuario).WithMany(t => t.Tarefas).HasForeignKey(u => u.UsuarioId).OnDelete(DeleteBehavior.Cascade);

            });

        modelBuilder.Entity<Categoria>(
            entity =>
            {
                entity.HasKey(c => c.CategoriaId);

                entity.Property(c => c.NomeCategoria).HasMaxLength(100).IsRequired().IsUnicode(false);

                entity.HasIndex(c => c.NomeCategoria).IsUnique();

                entity.HasOne(c => c.Usuario).WithMany(u => u.Categorias).HasForeignKey(c => c.UsuarioId).OnDelete(DeleteBehavior.Cascade);
            });

        modelBuilder.Entity<TarefaEmCategoria>(
            entity =>
            {
                entity.HasKey(c => c.TarefaEmCategoriaId);

                entity.HasOne(c => c.Tarefa).WithMany(u => u.TarefasEmCategorias).HasForeignKey(c => c.TarefaId);

                entity.HasOne(c => c.Categoria).WithMany(u => u.TarefasEmCategoria).HasForeignKey(c => c.CategoriaId);
            });
    }
}
