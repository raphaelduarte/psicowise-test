using Psicowise.Domain.Entities;

namespace Psicowise.Domain.Commands.AgendaCommand;

public class RemoveAgendaCommand
{
    public RemoveAgendaCommand(Agenda agenda)
    {
        Agenda = agenda;
    }
    public Agenda Agenda { get; set; }
}