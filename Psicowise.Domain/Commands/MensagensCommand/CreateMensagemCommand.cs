namespace Psicowise.Domain.Commands.MensagensCommand;

public class CreateMensagemCommand
{
    public CreateMensagemCommand(
        Guid psicologoId,
        Guid pacienteId,
        string mensagemTexto,
        DateTime dataHoraEnvio
    )
    {
        PsicologoId = psicologoId;
        PacienteId = pacienteId;
        MensagemTexto = mensagemTexto;
        DataHoraEnvio = dataHoraEnvio;
    }
    public Guid PsicologoId { get; private set; }
    public Guid PacienteId { get; private set; }
    public string MensagemTexto { get; private set; }
    public DateTime DataHoraEnvio { get; private set; }
}