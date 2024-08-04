using Psicowise.Domain.Entities;

namespace Psicowise.Domain.Repositories;

public interface IPsicologoRepository
{
    Task<Psicologo> Create(Psicologo psicologo);
    Task<Psicologo> Update(Psicologo psicologo);
    Task<Psicologo> Remove(Psicologo psicologo);
}