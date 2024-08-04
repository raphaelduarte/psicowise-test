using Psicowise.Domain.Commands.Interfaces;

namespace Psicowise.Domain.Handlers.Interfaces;

public interface IHandler<T>
{
    Task<ICommandResult> Handle(T command);
}