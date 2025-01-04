using Microsoft.EntityFrameworkCore;
using SistemaDeTarefasDL.API.Data;
using SistemaDeTarefasDL.API.Models;

namespace SistemaDeTarefasDL.API.Routes;

public static class TarefaRoute
{
    public static void TarefaRoutes(this WebApplication app)
    {
        app.MapGet("/tarefas", async (AppDbContext context) =>
            await context.Tarefas.ToListAsync());
        
        app.MapGet("/tarefas/{id:guid}", async (Guid id, AppDbContext context) =>
            await context.Tarefas.FindAsync(id) is TarefaModel tarefa 
                ? Results.Ok(tarefa) 
                : Results.NotFound());
        
        app.MapPost("/tarefas", async (TarefaModel tarefa, AppDbContext context) =>
        {
            context.Tarefas.Add(tarefa);
            await context.SaveChangesAsync();
            return Results.Created($"/tarefas/{tarefa.Id}", tarefa);
        });
        
        app.MapPut("/tarefas/{id:guid}", async (Guid id, TarefaModel tarefaAtualizada, AppDbContext context) =>
        {
            var tarefa = await context.Tarefas.FindAsync(id);
            if (tarefa is null) return Results.NotFound();
            
            tarefa.Titulo = tarefaAtualizada.Titulo;
            tarefa.Descricao = tarefaAtualizada.Descricao;
            tarefa.Status = tarefaAtualizada.Status;
            
            await context.SaveChangesAsync();
            return Results.Ok(tarefa);
        });
        
        app.MapDelete("/tarefas/{id:guid}", async (Guid id, AppDbContext context) =>
        {
            var tarefa = await context.Tarefas.FindAsync(id);
            if (tarefa is null) return Results.NotFound();

            context.Tarefas.Remove(tarefa);
            await context.SaveChangesAsync();
            return Results.Ok(tarefa);
        });
    }
}