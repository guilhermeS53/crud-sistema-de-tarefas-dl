using Microsoft.EntityFrameworkCore;
using SistemaDeTarefasDL.API.Models;

namespace SistemaDeTarefasDL.API.Data;

public class AppDbContext : DbContext
{
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<TarefaModel> Tarefas { get; set; }
}