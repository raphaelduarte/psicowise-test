using System.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Psicowise.Domain.Commands;
using Psicowise.Domain.Commands.Interfaces;
using Psicowise.Domain.Handlers;
using Psicowise.Domain.Queries.Contracts;
using Psicowise.Domain.Repositories;
using Psicowise.Infrastructure.Contexts;
using Psicowise.Infrastructure.Queries;
using Psicowise.Infrastructure.Repositories.Domain;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(optionsBuilder => 
    optionsBuilder.UseNpgsql(
        connectionString,
        options => options.EnableRetryOnFailure(
            maxRetryCount: 3,
            maxRetryDelay: TimeSpan.FromMicroseconds(100),
            errorCodesToAdd: null))
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking),
    ServiceLifetime.Transient
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPsicologoRepository, PsicologoRepository>();
builder.Services.AddScoped<IAgendaRepository, AgendaRepository>();

builder.Services.AddScoped<IPsicologoQuery, PsicologoQuery>();
builder.Services.AddScoped<IAgendaQuery, AgendaQuery>();

builder.Services.AddTransient<PsicologoHandler, PsicologoHandler>();
builder.Services.AddTransient<AgendaHandler, AgendaHandler>();

// Configurar o DbContext
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure o pipeline de requisição HTTP
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; // Serve Swagger UI na raiz do app
    });
}

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();