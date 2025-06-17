using Gerenciamento_de_Tarefas.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GerenciadorTarefasContext>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
