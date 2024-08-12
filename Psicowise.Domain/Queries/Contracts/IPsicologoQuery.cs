using Psicowise.Domain.Entities;

namespace Psicowise.Domain.Queries.Contracts;

public interface IPsicologoQuery
{
    Task<Psicologo?> GetPsicologoById(Guid psicologoId);
}