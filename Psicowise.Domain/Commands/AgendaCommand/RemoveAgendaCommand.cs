using Psicowise.Domain.Entities;

namespace Psicowise.Domain.Commands.AgendaCommand;

public class RemoveAgendaCommand
{
    public RemoveAgendaCommand(Guid agendaId)
    {
        AgendaId = agendaId;
    }
    public Guid AgendaId { get; set; }
}