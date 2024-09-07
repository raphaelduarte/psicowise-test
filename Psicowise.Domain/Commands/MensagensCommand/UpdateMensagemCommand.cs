namespace Psicowise.Domain.Commands.MensagensCommand;

public class UpdateMensagemCommand
{
    public UpdateMensagemCommand(
        Guid MensagemId,
        string mensagemTexto,
        DateTime dataHoraEnvio
    )
    {
        MensagemId = MensagemId;
        MensagemTexto = mensagemTexto;
        DataHoraEnvio = dataHoraEnvio;
    }
    public Guid MensagemId { get; set; }
    public string MensagemTexto { get; set; }
    public DateTime DataHoraEnvio { get; set; }
}