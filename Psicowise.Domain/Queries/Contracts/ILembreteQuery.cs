using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Queries.Contracts;

public interface ILembreteQuery
{
    Task<Lembrete> GetLembreteById(Guid lembreteId);
}