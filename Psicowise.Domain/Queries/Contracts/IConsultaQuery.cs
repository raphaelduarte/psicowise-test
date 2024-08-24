using Psicowise.Domain.Dtos;
using Psicowise.Domain.Entities;

namespace Psicowise.Domain.Queries.Contracts;

public interface IConsultaQuery
{
    Task<Consulta?> GetConsultaById(Guid consultaId);
    Task<List<ConsultaDto>> GetAllConsultasDoPsicologo(Guid psicologoId);
}