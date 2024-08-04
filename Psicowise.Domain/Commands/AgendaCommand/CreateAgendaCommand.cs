using Psicowise.Domain.Entities;
using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Commands.AgendaCommand;

public class CreateAgendaCommand
{
    public CreateAgendaCommand(
        Psicologo psicologo,
        List<Horario> horarios
        )
    {
        Psicologo = psicologo;
        Horarios = horarios;
    }
    public Psicologo Psicologo { get; private set; }
    public List<Horario> Horarios { get; private set; }
}