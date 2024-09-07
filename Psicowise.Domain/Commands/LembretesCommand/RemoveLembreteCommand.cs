namespace Psicowise.Domain.Commands.LembretesCommand;

public class RemoveLembreteCommand
{
    public RemoveLembreteCommand(Guid lembreteId)
    {
        LembreteId = lembreteId;
    }
    public Guid LembreteId { get; set; }
}