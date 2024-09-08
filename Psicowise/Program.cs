using System.Configuration;
using Hangfire;
using Hangfire.Console;
using Hangfire.Redis.StackExchange;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Psicowise.Domain.Commands;
using Psicowise.Domain.Commands.Interfaces;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Handlers;
using Psicowise.Domain.Queries.Contracts;
using Psicowise.Domain.Repositories;
using Psicowise.Domain.Services;
using Psicowise.Infrastructure.Contexts;
using Psicowise.Infrastructure.Queries;
using Psicowise.Infrastructure.Repositories.Domain;
using Psicowise.Infrastructure.Services;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(optionsBuilder => 
    optionsBuilder.UseNpgsql(
        connectionString,
        options => options.EnableRetryOnFailure(
            maxRetryCount: 3,
            maxRetryDelay: TimeSpan.FromMilliseconds(100),
            errorCodesToAdd: null)),
    ServiceLifetime.Scoped
);

builder.Services.AddHangfire(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("RedisConnectionString");
    var redis = ConnectionMultiplexer.Connect(connectionString);

    options.UseRedisStorage(redis, options: new RedisStorageOptions{Prefix = "HANG_FIRE"});
    options.UseConsole();
});

builder.Services.AddHangfireServer();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPsicologoRepository, PsicologoRepository>();
builder.Services.AddScoped<IAgendaRepository, AgendaRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();
builder.Services.AddScoped<ILembreteRepository, LembreteRepository>();

builder.Services.AddScoped<IPsicologoQuery, PsicologoQuery>();
builder.Services.AddScoped<IPacienteQuery, PacienteQuery>();
builder.Services.AddScoped<IAgendaQuery, AgendaQuery>();
builder.Services.AddScoped<IConsultaQuery, ConsultaQuery>();
builder.Services.AddScoped<ITesteQuery, TesteQuery>();
builder.Services.AddScoped<ILembreteQuery, LembreteQuery>();

builder.Services.AddTransient<PsicologoHandler, PsicologoHandler>();
builder.Services.AddTransient<AgendaHandler, AgendaHandler>();
builder.Services.AddTransient<PacienteHandler, PacienteHandler>();
builder.Services.AddTransient<ConsultaHandler, ConsultaHandler>();
builder.Services.AddTransient<LembreteHandler, LembreteHandler>();

builder.Services.AddScoped<IMensagensGeraisService, MensagensGeraisService>();
builder.Services.AddSingleton<IMonitorService, MonitorService>();

builder.Services.AddHostedService<MonitorService>();

// Configurar o DbContext
builder.Services.AddDbContext<DataContext>();

// Adicionar serviço CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure o pipeline de requisição HTTP
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Psicowise API V1");
        c.RoutePrefix = string.Empty; // Serve Swagger UI na raiz do app
    });
}

app.UseHangfireDashboard("/hangfire");

//app.UseHttpsRedirection();
app.UseAuthorization();

// Usar o middleware CORS
app.UseCors("AllowAll");

app.MapControllers();
app.Run();