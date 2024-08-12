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
            command.Telefone,
            command.Endereco
        );
        await _repository.Create(psicologo);
        return new GenericCommandResult(true, "Psicologo criado com sucesso", psicologo);
    }

    public async Task<ICommandResult> Handle(UpdatePsicologoCommand command)
    {
        var psicologo = await _query.GetPsicologoById(command.Id);
        if (psicologo == null)
        {
            return new GenericCommandResult(false, "Psicólogo não encontrado", default);
        }

        // Atualize as propriedades do psicólogo aqui
        // psicologo.Nome = command.Nome;
        // psicologo.Crp = command.Crp;
        // psicologo.Email = command.Email;
        // ... outras propriedades ...

        await _repository.Update(psicologo);

        return new GenericCommandResult(true, "Psicologo atualizado com sucesso", psicologo);
    }

    public async Task<ICommandResult> Handle(RemovePsicologoCommand command)
    {
        var psicologo = await _query.GetPsicologoById(command.Id);
        if (psicologo == null)
        {
            return new GenericCommandResult(false, "Psicólogo não encontrado", default);
        }

        // Armazene as informações relevantes antes de remover
        var psicologoInfo = new
        {
            psicologo.Id,
            psicologo.Nome,
            psicologo.Crp
        };

        await _repository.Remove(psicologo);
        return new GenericCommandResult(true, "Psicólogo removido com sucesso", psicologoInfo);
    }
}