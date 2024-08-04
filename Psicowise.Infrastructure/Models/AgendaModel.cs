using Psicowise.Domain.Entities;
using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Infrastructure.Models;

public class AgendaModel
{
    public Guid Id { get; set; }
    public ICollection<Paciente>? Pacientes { get; set; }
    public Psicologo Psicologo { get; set; }
    public ICollection<Horario>? Horarios { get; set; }
}