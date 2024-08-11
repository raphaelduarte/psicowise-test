using Psicowise.Domain.Entities;

namespace Psicowise.Domain.Repositories;

public interface IPsicologoRepository
{
    Task<Psicologo> Create(Psicologo psicologo);
    Task<Psicologo> Update(Psicologo psicologo);
    Task Remove(Psicologo? psicologo);
}