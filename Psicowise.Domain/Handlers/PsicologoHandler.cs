using Psicowise.Domain.Commands;
using Psicowise.Domain.Commands.Interfaces;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Handlers.Interfaces;
using Psicowise.Domain.Queries;
using Psicowise.Domain.Queries.Contracts;
using Psicowise.Domain.Repositories;

namespace Psicowise.Domain.Handlers;

public class PsicologoHandler : IHandler<CreatePsicologoCommand>, IHandler<UpdatePsicologoCommand>, IHandler<RemovePsicologoCommand>
{
    private readonly IPsicologoRepository _repository;
    private readonly IPsicologoQuery _query;

    public PsicologoHandler(IPsicologoRepository repository, IPsicologoQuery query)
    {
        _repository = repository;
        _query = query;
    }

    public async Task<ICommandResult> Handle(CreatePsicologoCommand command)
    {
        var psicologo = new Psicologo(
            command.Nome,
            command.Crp,
            command.Email,
            command.Endereco
        );
        await _repository.Create(psicologo);
        return new GenericCommandResult(true, "Psicologo criado com sucesso", psicologo);
    }

    public async Task<ICommandResult> Handle(UpdatePsicologoCommand command)
    {
        var psicologo = _query.GetPsicologoById(command.Id);

        await _repository.Update(psicologo);

        return new GenericCommandResult(true, "Psicologo atualizado com sucesso", psicologo);
    }
    
    public async Task<ICommandResult> Handle(RemovePsicologoCommand command)
    {
        
        return new GenericCommandResult(true, "Psicologo deletado com sucesso", null);
    }
}