using Psicowise.Domain.Entities;

namespace Psicowise.Domain.Queries.Contracts;

public interface IAgendaQuery
{
    Task<Agenda> GetAgendaById(Guid agendaId);
    Task<bool> VerificarDisponibilidade(Guid psicologoId, DateTime horarioEDiaDesejado);
}