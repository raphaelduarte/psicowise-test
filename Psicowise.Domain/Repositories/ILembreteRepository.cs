using Psicowise.Domain.Commands.LembretesCommand;
using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Repositories;

public interface ILembreteRepository
{
    Task<Lembrete> Create(CreateLembreteCommand lembreteCommand);
    Task<Lembrete> Update(UpdateLembreteCommand lembreteCommand);
    Task Remove(RemoveLembreteCommand lembreteCommand);
}