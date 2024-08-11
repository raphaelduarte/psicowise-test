using Microsoft.EntityFrameworkCore;
using Psicowise.Domain.Entities;
using Psicowise.Domain.ObjetosDeValor;
using System.Text.Json;

namespace Psicowise.Infrastructure.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Psicologo> Psicologos { get; set; }
    public DbSet<Agenda> Agendas { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    // Adicione outros DbSets conforme necessário

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Psicologo>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
                    v => JsonSerializer.Deserialize<NomeCompleto>(v, new JsonSerializerOptions())!);
            entity.Property(e => e.Crp)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.Endereco)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
                    v => JsonSerializer.Deserialize<Endereco>(v, new JsonSerializerOptions())!);
            
            // Configurações para coleções, se necessário
            entity.Property(e => e.Pacientes)
                .HasConversion(
                    v => JsonSerializer.Serialize(v.Select(p => p.Id).ToList(), new JsonSerializerOptions()),
                    v => JsonSerializer.Deserialize<List<Guid>>(v, new JsonSerializerOptions()).Select(id => new Paciente()).ToList() ?? new List<Paciente>());

            entity.Property(e => e.Consultas)
                .HasConversion(
                    v => JsonSerializer.Serialize(v.Select(c => c.Id).ToList(), new JsonSerializerOptions()),
                    v => JsonSerializer.Deserialize<List<Guid>>(v, new JsonSerializerOptions()).Select(id => new Consulta(id, Guid.Empty, DateTime.MinValue, DateTime.MinValue, "", false, false, false, false, false, false)).ToList() ?? new List<Consulta>());

            entity.Property(e => e.Agendas)
                .HasConversion(
                    v => JsonSerializer.Serialize(v.Select(a => a.Id).ToList(), new JsonSerializerOptions()),
                    v => JsonSerializer.Deserialize<List<Guid>>(v, new JsonSerializerOptions()).Select(id => new Agenda()).ToList() ?? new List<Agenda>());
        });

        modelBuilder.Entity<Agenda>(entity =>
        {
            entity.HasKey(e => e.Id);
            // Adicione outras configurações para Agenda, se necessário
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
                    v => JsonSerializer.Deserialize<NomeCompleto>(v, new JsonSerializerOptions())!);
            entity.Property(e => e.Endereco)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
                    v => JsonSerializer.Deserialize<Endereco>(v, new JsonSerializerOptions())!);
            // Adicione outras configurações para Paciente, se necessário
        });

        // Adicione configurações para outras entidades, se necessário

        base.OnModelCreating(modelBuilder);
    }
}