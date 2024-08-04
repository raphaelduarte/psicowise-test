using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Handlers;
using Psicowise.Domain.ObjetosDeValor;
using Psicowise.Infrastructure.Models;

namespace Psicowise.Infrastructure.Contexts;

public class DataContext : DbContext
{
    // protected readonly IConfiguration Configuration;
    // public DataContext(IConfiguration configuration)
    // {
    //     Configuration = configuration;
    // }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
    // }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Server=easypanel.hetzner.odontowise.net.br;Port=123;Database=psicowise;User Id=postgres;Password=Joaquim12@");
    }

    public DbSet<PsicologoModel> Psicologos { get; set; }
    public DbSet<AgendaModel> Agendas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PsicologoModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome)
                    .HasConversion(
                        v => v.ToString(),
                        v => new NomeCompleto(v, v));
                entity.Property(e => e.Crp)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(e => e.Endereco)
                    .HasConversion(
                        v => v != null ? JsonSerializer.Serialize(v, new JsonSerializerOptions()) : null,
                        v => v != null ? JsonSerializer.Deserialize<Endereco>(v, new JsonSerializerOptions()) : null);

                // Converter List<Guid>? para string e vice-versa

                //entity.Property(e => e.Pacientes)
                //    .HasConversion(
                //        v => v != null ? string.Join(',', v) : null,
                //        v => v != null ? v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Guid.Parse).ToList() : new List<Guid>());
                //entity.Property(e => e.Consultas)
                //    .HasConversion(
                //        v => v != null ? string.Join(',', v) : null,
                //        v => v != null ? v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Guid.Parse).ToList() : new List<Guid>());
                //entity.Property(e => e.Agendas)
                //    .HasConversion(
                //        v => v != null ? string.Join(',', v) : null,
                //        v => v != null ? v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(Guid.Parse).ToList() : new List<Guid>());
            });
    }
}