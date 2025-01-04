using SistemaDeTarefasDL.API.Routes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.TarefaRoutes();
// GET, POST, PUT, DELETE 

app.UseHttpsRedirection();
app.Run();