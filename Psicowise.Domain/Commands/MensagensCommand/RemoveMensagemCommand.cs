namespace Psicowise.Domain.Commands.MensagensCommand;

public class RemoveMensagemCommand
{
    public RemoveMensagemCommand(Guid mensagemId)
    {
        Guid MensagemId = mensagemId;
    }

    public Guid MensagemId { get; set; }
}