using SistemaDeTarefasDL.API.Models;

namespace SistemaDeTarefasDL.API.Routes;

public static class TarefaRoute
{
    public static void TarefaRoutes(this WebApplication app)
    {
        app.MapGet("tarefa", () => 
            new TarefaModel(
                "Correr", 
            "Correr no parque por 30 minutos", 
            DateTime.Now.AddDays(7)
            )
        );
    }
}