namespace SistemaDeTarefasDL.API.Models;

public class TarefaModel
{
    public TarefaModel(string titulo, string? descricao = null, DateTime? dataConclusao = null)
    {
        Id = Guid.NewGuid();
        Titulo = titulo;
        Descricao = descricao;
        DataCriacao = DateTime.Now;
        DataConclusao = dataConclusao;
    }
    public Guid Id { get; set; }
    public string Titulo { get; set; }
    public string? Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataConclusao { get; set; }
}