namespace Psicowise.Domain.Commands;

public class RemovePsicologoCommand
{
    public RemovePsicologoCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; private set; }
}