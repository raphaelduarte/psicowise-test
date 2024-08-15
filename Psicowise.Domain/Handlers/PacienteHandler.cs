using Psicowise.Domain.Commands;
using Psicowise.Domain.Commands.Interfaces;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Handlers.Interfaces;
using Psicowise.Domain.Queries.Contracts;
using Psicowise.Domain.Repositories;

namespace Psicowise.Domain.Handlers;

public class PacienteHandler : 
    IHandler<CreatePacienteCommand>, 
    IHandler<RemovePacienteCommand>
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IPacienteQuery _pacienteQuery;

    public PacienteHandler(
        IPacienteRepository pacienteRepository,
        IPacienteQuery pacienteQuery
        )
    {
        _pacienteRepository = pacienteRepository;
        _pacienteQuery = pacienteQuery;
    }
    
    //TODO: Implementar CreatePaciente e consertar o CreatedAt
    public async Task<ICommandResult> Handle(CreatePacienteCommand command)
    {
        var paciente = new Paciente(
            command.PsicologoId,
            command.Nome,
            command.Email,
            command.Telefone,
            command.Endereco,
            command.DataNascimento
        );
        
        paciente.CreatedAt = DateTime.Now.ToUniversalTime();
        
        await _pacienteRepository.Create(paciente);
        return new GenericCommandResult(true, "Paciente criado com sucesso", paciente);
    }

    public async Task<ICommandResult> Handle(RemovePacienteCommand command)
    {
        var paciente = _pacienteQuery.GetPacienteById(command.PacienteId).Result;
        if (paciente == null)
        {
            return new GenericCommandResult(false, "Paciente não encontrado", default);
        }
        
        await  _pacienteRepository.Remove(paciente);
        return new GenericCommandResult(true, "Paciente removido com sucesso", default);
    }
}