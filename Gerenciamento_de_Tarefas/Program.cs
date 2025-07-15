using Gerenciamento_de_Tarefas.Context;
using Gerenciamento_de_Tarefas.Interfaces;
using Gerenciamento_de_Tarefas.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<GerenciadorTarefasContext>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<ITarefaEmCategoriaRepository, TarefaEmCategoriaRepository>();
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();


builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.MapControllers();

app.Run();
