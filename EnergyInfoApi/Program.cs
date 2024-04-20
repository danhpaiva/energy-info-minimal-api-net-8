using EnergyInfoApi.Context;
using EnergyInfoApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. ("ConfigureServices")
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
                                            options
                                            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

app.MapGet("/", () => "Lista de Localizações");

app.MapPost("/localizacoes", async (Localizacao localizacao, AppDbContext db)
    =>
{
    db.Localizacoes.Add(localizacao);
    await db.SaveChangesAsync();
    return Results.Created($"/localizacoes/{localizacao.LocalizacaoId}", localizacao);
});

app.MapGet("localizacoes", async (AppDbContext db) => await db.Localizacoes.ToListAsync());

app.MapGet("/categorias/{id:int}", async (int id, AppDbContext db)
    =>
{
    return await db.Localizacoes.FindAsync(id)
        is Localizacao localizacao
        ? Results.Ok(localizacao)
        : Results.NotFound();
});

// Configure the HTTP request pipeline. ("Configure")
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();