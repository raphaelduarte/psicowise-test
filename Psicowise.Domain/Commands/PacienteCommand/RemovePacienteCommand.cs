namespace Psicowise.Domain.Commands;

public class RemovePacienteCommand
{
    public RemovePacienteCommand(Guid pacienteId)
    {
        PacienteId = pacienteId;
    }
    public Guid PacienteId { get; private set; }
}