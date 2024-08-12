using Psicowise.Domain.Entities;
using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Commands.AgendaCommand;

public class CreateAgendaCommand
{
    public CreateAgendaCommand(
        Guid psicologoId,
        List<Horario> horarios
        )
    {
        PsicologoId = psicologoId;
        Horarios = horarios;
    }
    public Guid PsicologoId { get; private set; }
    public List<Horario> Horarios { get; private set; }
}