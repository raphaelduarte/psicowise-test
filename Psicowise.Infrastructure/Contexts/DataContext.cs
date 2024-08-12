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
        
        entity.Property(e => e.Telefone)
            .HasConversion(
                v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
                v => JsonSerializer.Deserialize<Telefone>(v, new JsonSerializerOptions())!);

        // Assumindo que você tem uma propriedade de navegação chamada Pacientes
        entity.HasMany(e => e.Pacientes)
            .WithOne(p =>p.Psicologo) // Adicione aqui a propriedade de navegação no Paciente se existir
            .HasForeignKey(p => p.PsicologoId); // Ajuste para o nome correto da propriedade de chave estrangeira no Paciente

        // Configuração para Consultas
        entity.HasMany(e => e.Consultas)
            .WithOne(p => p.Psicologo) // Adicione aqui a propriedade de navegação na Consulta se existir
            .HasForeignKey(c => c.PsicologoId); // Ajuste para o nome correto da propriedade de chave estrangeira na Consulta

        // Configuração para Agendas
        entity.HasMany(e => e.Agendas)
            .WithOne(p => p.Psicologo) // Adicione aqui a propriedade de navegação na Agenda se existir
            .HasForeignKey(a => a.PsicologoId); // Ajuste para o nome correto da propriedade de chave estrangeira na Agenda
    });

    modelBuilder.Entity<Agenda>(entity =>
    {
        entity.HasKey(e => e.Id);

        // Configuração para Consultas
        entity.HasMany(e => e.Consultas)
            .WithOne(c =>c.Agenda) // Adicione aqui a propriedade de navegação na Consulta se existir
            .HasForeignKey(c => c.AgendaId); // Ajuste para o nome correto da propriedade de chave estrangeira na Consulta
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
        
        entity.Property(e => e.Telefone)
            .HasConversion(
                v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
                v => JsonSerializer.Deserialize<Telefone>(v, new JsonSerializerOptions())!);

        entity.HasOne(paciente => paciente.Psicologo)
            .WithMany(p => p.Pacientes)
            .HasForeignKey(p => p.PsicologoId);
        
        // Configuração para Consultas
        entity.HasMany(e => e.Consultas)
            .WithOne(p => p.Paciente) // Adicione aqui a propriedade de navegação na Consulta se existir
            .HasForeignKey(c => c.PacienteId); // Ajuste para o nome correto da propriedade de chave estrangeira na Consulta
    });

    modelBuilder.Entity<Horario>(entity =>
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.InicioConsulta)
            .IsRequired();

        entity.Property(e => e.FimConsulta)
            .IsRequired();
    });

    base.OnModelCreating(modelBuilder);
    }
}