using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Psicowise.Domain.Entities;
using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Infrastructure.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<Psicologo> Psicologos { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Consulta> Consultas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Agenda> Agenda { get; set; }
}