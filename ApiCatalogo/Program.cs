using ApiCatalogo.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Obtendo a string de conexão
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Incluindo o serviço no contexto
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();


// ---------------------------------------- ENDPOINTS ----------------------------------------
app.MapGet("/", () => $"Catálogo de Produtos - {DateTime.Now.Year}");






// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.Run();
