using Psicowise.Domain.Entities;

namespace Psicowise.Domain.Repositories;

public interface IPsicologoRepository
{
    Task<Psicologo> GetByEmail(string email);
    Task<Psicologo> GetById(Guid id);
    Task<Psicologo> Create(Psicologo psicologo);
    Task<Psicologo> Update(Psicologo psicologo);
    string Remove(Psicologo psicologo);
}