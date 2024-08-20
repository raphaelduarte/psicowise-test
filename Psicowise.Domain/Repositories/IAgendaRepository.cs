using Psicowise.Domain.Entities;

namespace Psicowise.Domain.Repositories;

public interface IAgendaRepository
{
    Task<Agenda> Create(Agenda agenda);
    Task<Agenda> Update(Agenda agenda);
    Task<Agenda> Remove(Agenda agenda);
    
}