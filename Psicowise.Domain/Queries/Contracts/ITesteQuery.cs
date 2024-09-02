using Psicowise.Domain.Entities;

namespace Psicowise.Domain.Queries.Contracts;

public interface ITesteQuery
{
    Task<IEnumerable<Psicologo>> GetAllPsicologos();
}