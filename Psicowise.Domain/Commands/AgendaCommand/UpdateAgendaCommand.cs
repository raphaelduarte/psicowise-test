using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Commands.AgendaCommand;

public class UpdateAgendaCommand
{
    public UpdateAgendaCommand(
        Guid idAgenda,
        ICollection<Horario> horarios
        )
    {
        IdAgenda = idAgenda;
        Horarios = horarios;
    }
    public Guid IdAgenda { get; set; }
    public ICollection<Horario> Horarios { get; private set; }
}