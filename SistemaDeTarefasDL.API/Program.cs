using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SistemaDeTarefasDL.API.Data;
using SistemaDeTarefasDL.API.Routes;
using SistemaDeTarefasDL.API.Models;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, true));
});

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("TarefasDb"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    InicializarBancoDeDados(app.Services);
}

app.TarefaRoutes(); // Definem as rotas de: GET, POST, PUT, DELETE 

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();
app.Run();

void InicializarBancoDeDados(IServiceProvider services)
{
    using var scope = services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    context.Tarefas.Add(new TarefaModel("Aprender EF Core InMemory",
        "Estudo sobre bancos em memória",
        TarefaModel.StatusTarefa.Pendente));
    context.Tarefas.Add(new TarefaModel("Correr no Parque",
        "Correr por 30 minutos em Trindade",
        TarefaModel.StatusTarefa.EmAndamento));

    context.SaveChanges();

    Console.WriteLine("Banco de dados iniciando as tarefas abaixo: ");
    foreach (var tarefa in context.Tarefas.ToList())
    {
        Console.WriteLine($"Título: {tarefa.Titulo}, Status: {tarefa.Status}, Criado em: {tarefa.DataCriacao}");
    }
}
