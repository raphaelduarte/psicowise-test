using Psicowise.Domain.Entities;

namespace Psicowise.Domain.Queries.Contracts;

public interface IPsicologoQuery
{
    Psicologo GetPsicologoById(Guid psicologoId);
}