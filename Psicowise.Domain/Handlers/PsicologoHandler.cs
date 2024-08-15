using Psicowise.Domain.Commands;
using Psicowise.Domain.Commands.Interfaces;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Handlers.Interfaces;
using Psicowise.Domain.Queries;
using Psicowise.Domain.Queries.Contracts;
using Psicowise.Domain.Repositories;

namespace Psicowise.Domain.Handlers;

public class PsicologoHandler : 
    IHandler<CreatePsicologoCommand>, 
    IHandler<UpdatePsicologoCommand>, 
    IHandler<RemovePsicologoCommand>
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
        
        psicologo.CreatedAt = command.CreatedAt;
        
        await _repository.Create(psicologo);
        return new GenericCommandResult(true, "Psicologo criado com sucesso", psicologo);
    }
    public async Task<ICommandResult> Handle(UpdatePsicologoCommand command)
    {
        var psicologo = await _query.GetPsicologoById(command.Id);
        psicologo.UpdatedAt = DateTime.Now.ToUniversalTime();
        
        if (psicologo == null)
        {
            return new GenericCommandResult(false, "Psicólogo não encontrado", default);
        }

        if (command.Endereco != null)
        {
            if (command.Endereco.Logradouro != null)
            {
                psicologo.Endereco.Logradouro = command.Endereco.Logradouro;
            }
        
            if (command.Endereco.Numero != null)
            {
                psicologo.Endereco.Numero = command.Endereco.Numero;
            }
        
            if (command.Endereco.Bairro != null)
            {
                psicologo.Endereco.Bairro = command.Endereco.Bairro;
            }
        
            if (command.Endereco.Cidade != null)
            {
                psicologo.Endereco.Cidade = command.Endereco.Cidade;
            }
        
            if (command.Endereco.Estado != null)
            {
                psicologo.Endereco.Estado = command.Endereco.Estado;
            }
        
            if (command.Endereco.Cep != null)
            {
                psicologo.Endereco.Cep = command.Endereco.Cep;
            }
        }

        if (command.Telefone != null)
        {
            if (command.Telefone.Ddd != null)
            {
                psicologo.Telefone.Ddd = command.Telefone.Ddd;
            }
        
            if (command.Telefone.Numero != null)
            {
                psicologo.Telefone.Numero = command.Telefone.Numero;
            }
        }

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