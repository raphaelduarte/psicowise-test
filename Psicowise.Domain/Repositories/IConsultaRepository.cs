using Psicowise.Domain.Entities;

namespace Psicowise.Domain.Repositories;

public interface IConsultaRepository
{
    Task<Consulta> Create(Consulta consulta);
    Task<Consulta> Update(Consulta consulta);
    Task Remove(Consulta? consulta);
}