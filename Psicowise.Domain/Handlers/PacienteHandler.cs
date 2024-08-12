using Psicowise.Domain.Commands;
using Psicowise.Domain.Commands.Interfaces;
using Psicowise.Domain.Commands.PacienteCommand;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Queries.Contracts;
using Psicowise.Domain.Repositories;

namespace Psicowise.Domain.Handlers;

public class PacienteHandler
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
    
    public async Task<ICommandResult> Handle(CreatePacienteCommand command)
    {
        var paciente = new Paciente(
            command.PsicologoId,
            command.Nome,
            command.Email,
            command.Telefone,
            command.Endereco,
            command.DataNascimento,
            command.CreatedAt
        );
        await _pacienteRepository.Create(paciente);
        return new GenericCommandResult(true, "Paciente criado com sucesso", paciente);
    }
}