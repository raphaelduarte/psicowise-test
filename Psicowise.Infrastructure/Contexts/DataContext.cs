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
    public DbSet<Consulta> Consultas { get; set; }
    public DbSet<Lembrete> Lembretes { get; set; }
    public DbSet<Mensagem> Mensagens { get; set; }
    public DbSet<WhatsappInstance> WhatsappInstances { get; set; }

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

        entity.HasMany(e => e.Lembretes)
            .WithOne(p => p.Psicologo) // Adicione aqui a propriedade de navegação no Lembrete se existir
            .HasForeignKey(l => l.PsicologoId); // Ajuste para o nome correto da propriedade de chave estrangeira no Lembrete

        entity.HasMany(e => e.Mensagens)
            .WithOne(p => p.Psicologo) // Adicione aqui a propriedade de navegação na Mensagem se existir
            .HasForeignKey(m => m.PsicologoId); // Ajuste para o nome correto da propriedade de chave estrangeira na Mensagem

        entity.HasMany(e => e.WhatsappInstances)
            .WithOne(p => p.Psicologo) // Adicione aqui a propriedade de navegação na WhatsappInstance se existir
            .HasForeignKey(w => w.PsicologoId); // Ajuste para o nome correto da propriedade de chave estrangeira na WhatsappInstance
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
    
    modelBuilder.Entity<Consulta>(entity =>
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Horario)
            .HasConversion(
                v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
                v => JsonSerializer.Deserialize<Horario>(v, new JsonSerializerOptions())!);

        entity.Property(e => e.Observacoes)
            .HasMaxLength(255);

        entity.HasOne(consulta => consulta.Psicologo)
            .WithMany(p => p.Consultas)
            .HasForeignKey(c => c.PsicologoId);

        entity.HasOne(consulta => consulta.Paciente)
            .WithMany(p => p.Consultas)
            .HasForeignKey(c => c.PacienteId);

        entity.HasOne(consulta => consulta.Agenda)
            .WithMany(a => a.Consultas)
            .HasForeignKey(c => c.AgendaId);
    });

    modelBuilder.Entity<Lembrete>(entity =>
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Tipo)
            .IsRequired();

        entity.Property(e => e.Mensagem)
            .HasMaxLength(255);

        entity.Property(e => e.DataDeDisparo)
            .IsRequired();

        entity.Property(e => e.IsDisparado)
            .IsRequired();

        entity.HasOne(lembrete => lembrete.Psicologo)
            .WithMany(p => p.Lembretes)
            .HasForeignKey(l => l.PsicologoId);

        entity.HasOne(lembrete => lembrete.Paciente)
            .WithMany(p => p.Lembretes)
            .HasForeignKey(l => l.PacienteId);

        entity.HasOne(lembrete => lembrete.Consulta)
            .WithMany(c => c.Lembretes)
            .HasForeignKey(l => l.ConsultaId);
    });

    modelBuilder.Entity<Mensagem>(entity =>
    {
        entity.HasKey(e => e.Id);
         entity.HasOne(mensagem => mensagem.Psicologo)
            .WithMany(p => p.Mensagens)
            .HasForeignKey(m => m.PsicologoId);

        entity.HasOne(mensagem => mensagem.Paciente)
            .WithMany(p => p.Mensagens)
            .HasForeignKey(m => m.PacienteId);
    });

    modelBuilder.Entity<WhatsappInstance>(entity =>
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.PsicologoId)
            .IsRequired();

        entity.HasOne(instance => instance.Psicologo)
            .WithMany(p => p.WhatsappInstances)
            .HasForeignKey(instance => instance.PsicologoId);
    });

        base.OnModelCreating(modelBuilder);
    }
}