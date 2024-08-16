namespace Psicowise.Domain.Commands.ConsultaCommand;

public class RemoveConsultaCommand
{
    public RemoveConsultaCommand(Guid consultaId)
    {
        ConsultaId = consultaId;
    }
    public Guid ConsultaId { get; private set; }
}