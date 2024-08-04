using Psicowise.Domain.Commands;
using Psicowise.Domain.Commands.AgendaCommand;
using Psicowise.Domain.Commands.Interfaces;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Handlers.Interfaces;
using Psicowise.Domain.Queries.Contracts;
using Psicowise.Domain.Repositories;

namespace Psicowise.Domain.Handlers;

public class AgendaHandler : IHandler<CreateAgendaCommand>, IHandler<UpdateAgendaCommand>, IHandler<RemoveAgendaCommand>
{
    private readonly IAgendaRepository _repository;
    private readonly IAgendaQuery _query;

    public AgendaHandler(IAgendaRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<ICommandResult> Handle(CreateAgendaCommand command)
    {
        var agenda = new Agenda(
            command.Psicologo,
            command.Horarios
        );
        await _repository.Create(agenda);
        return new GenericCommandResult(true, "Agenda criada com sucesso", agenda);
    }
    
    public async Task<ICommandResult> Handle(UpdateAgendaCommand command)
    {
        var agendaContext = _query.GetAgendaById(command.IdAgenda);

        var agendaCommand = new Agenda(
            agendaContext.Psicologo,
            command.Horarios
        );
        await _repository.Update(agendaCommand);
        return new GenericCommandResult(true, "Agenda atualizada com sucesso", agendaCommand);
    }
    
    public async Task<ICommandResult> Handle(RemoveAgendaCommand command)
    {
        var agenda = _query.GetAgendaById(command.Agenda.Id);
        await _repository.Remove(agenda);
        return new GenericCommandResult(true, "Agenda deletada com sucesso", agenda);
    }
}