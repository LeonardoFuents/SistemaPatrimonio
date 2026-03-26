using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using SistemaPatrimonio.Applications.Services;
using SistemaPatrimonio.Contexts;
using SistemaPatrimonio.Interfaces;
using SistemaPatrimonio.Repositories;

var builder = WebApplication.CreateBuilder(args);

//carregando o .env

Env.Load();

//pegando a connection string 

string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

//conexao com banco

builder.Services.AddDbContext<GestaoPatrimoniosContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<AreaService>();

builder.Services.AddScoped<ILocalizacaoRepository, LocalizacaoRepository>();
builder.Services.AddScoped<LocalizacaoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
    
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


