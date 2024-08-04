using Psicowise.Domain.Entities;
using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Infrastructure.Models;

public class PsicologoModel
{
    public Guid Id { get; set; }
    public NomeCompleto Nome { get; set; }
    public string Crp { get; set; }
    public string Email { get; set; }
    public ICollection<Paciente>? Pacientes { get; set; }
    public Endereco? Endereco { get; set; }
    public ICollection<Consulta>? Consultas { get; set; }
    public ICollection<Agenda>? Agendas { get; set; }
}