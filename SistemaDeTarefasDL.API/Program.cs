using Microsoft.EntityFrameworkCore;
using SistemaDeTarefasDL.API.Data;
using SistemaDeTarefasDL.API.Routes;
using SistemaDeTarefasDL.API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("TarefasDb"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    InicializarBancoDeDados(app.Services);
}

app.TarefaRoutes(); // GET, POST, PUT, DELETE 

app.UseHttpsRedirection();
app.Run();

void InicializarBancoDeDados(IServiceProvider services)
{
    using var scope = services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    context.Tarefas.Add(new TarefaModel("Aprender EF Core InMemory", "Estudo sobre bancos em memória"));
    context.Tarefas.Add(new TarefaModel("Correr no Parque", "Correr por 30 minutos em Trindade", DateTime.Now.AddDays(4)));
    
    context.SaveChanges();

    Console.WriteLine("Banco de dados iniciando as tarefas abaixo: ");
    foreach (var tarefa in context.Tarefas.ToList())
    {
        Console.WriteLine($"Título: {tarefa.Titulo}, Criado em: {tarefa.DataCriacao}");
    }
}
