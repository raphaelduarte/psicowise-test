using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Commands.ConsultaCommand;

public class CreateConsultaCommand
{
    public CreateConsultaCommand(
        Guid psicologoId,
        Guid pacienteId,
        Horario horario
    )
    {
        PsicologoId = psicologoId;
        PacienteId = pacienteId;
        Horario = horario;
        CreatedAt = DateTime.Now.ToUniversalTime();
    }
    public Guid PsicologoId { get; private set; }
    public Guid PacienteId { get; private set; }
    public Horario Horario { get; private set; }
    public DateTime CreatedAt { get; private set; }
}