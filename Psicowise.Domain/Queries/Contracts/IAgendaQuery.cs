using Psicowise.Domain.Entities;

namespace Psicowise.Domain.Queries.Contracts;

public interface IAgendaQuery
{
    Agenda GetAgendaById(Guid agendaId);
}