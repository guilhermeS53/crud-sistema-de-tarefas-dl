namespace SistemaDeTarefasDL.API.Models;

public class TarefaModel
{
    public enum StatusTarefa
    {
        Pendente, // Inicializa como 0
        EmAndamento, // Inicializa como 1
        Concluido // Inicializa como 2
    }
    public TarefaModel(string titulo, string? descricao = null, StatusTarefa Status = StatusTarefa.Pendente)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        Descricao = descricao;
        DataCriacao = DateTime.Now;
        Status = Status;
    }
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public StatusTarefa Status { get; set; }
}