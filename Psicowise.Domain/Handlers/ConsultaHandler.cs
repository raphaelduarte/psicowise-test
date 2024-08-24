using Psicowise.Domain.Commands;
using Psicowise.Domain.Commands.ConsultaCommand;
using Psicowise.Domain.Commands.Interfaces;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Handlers.Interfaces;
using Psicowise.Domain.Queries.Contracts;
using Psicowise.Domain.Repositories;

namespace Psicowise.Domain.Handlers;

//TODO: Criar o GetConsultaById no Controller

public class ConsultaHandler:
    IHandler<CreateConsultaCommand>,
    IHandler<UpdateConsultaCommand>,
    IHandler<RemoveConsultaCommand>
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly IConsultaQuery _consultaQuery;
    private readonly IPacienteQuery _pacienteQuery;
    
    public ConsultaHandler(
        IConsultaRepository consultaRepository,
        IConsultaQuery consultaQuery,
        IPacienteQuery pacienteQuery
        )
    {
        _consultaRepository = consultaRepository;
        _consultaQuery = consultaQuery;
        _pacienteQuery = pacienteQuery;
    }
    
    public async Task<ICommandResult> Handle(CreateConsultaCommand command)
    {
        try
        {
            var consulta = new Consulta(
                command.PsicologoId,
                command.PacienteId,
                command.AgendaId,
                command.Horario
            );

            consulta.CreatedAt = command.CreatedAt;

            var pacienteExiste = _pacienteQuery.GetPacienteById(command.PacienteId).Result;

            if (pacienteExiste == null)
            {
                return new GenericCommandResult(false, "A consulta não pode ser criada, pois não é possível criar uma consulta sem paciente.", default);
            }

            await _consultaRepository.Create(consulta);
            return new GenericCommandResult(true, "Consulta criada com sucesso", consulta);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    

    public async Task<ICommandResult> Handle(UpdateConsultaCommand command)
    {
        var consulta = await _consultaQuery.GetConsultaById(command.Id);
        consulta.UpdatedAt = DateTime.Now.ToUniversalTime();
        
        if (consulta == null)
        {
            return new GenericCommandResult(false, "Consulta não encontrada", default);
        }

        if (command.Horario != null)
        {
            if (command.Horario.InicioConsulta != null)
            {
                consulta.Horario.InicioConsulta = command.Horario.InicioConsulta;
            }
        }

        if (command.PacienteId != null)
        {
            consulta.PacienteId = command.PacienteId.Value;
        }
        
        if (command.Observacoes != null)
        {
            consulta.Observacoes = command.Observacoes;
        }
        
        if (command.Realizada != null)
        {
            consulta.Realizada = command.Realizada;
        }
        
        if (command.Cancelada != null)
        {
            consulta.Cancelada = command.Cancelada;
        }
        
        if (command.Remarcada != null)
        {
            consulta.Remarcada = command.Remarcada;
        }
        
        if (command.Confirmada != null)
        {
            consulta.Confirmada = command.Confirmada;
        }
        
        if (command.Paga != null)
        {
            consulta.Paga = command.Paga;
        }
        
        if (command.PacienteFaltou != null)
        {
            consulta.PacienteFaltou = command.PacienteFaltou;
        }

        await _consultaRepository.Update(consulta);

        return new GenericCommandResult(true, "Consulta atualizadaa com sucesso", consulta);
    }
    
    
    

    public async Task<ICommandResult> Handle(RemoveConsultaCommand command)
    {
        var consulta = _consultaQuery.GetConsultaById(command.ConsultaId).Result;
        if (consulta == null)
        {
            return new GenericCommandResult(false, "Consulta não encontrada", default);
        }
        
        await  _consultaRepository.Remove(consulta);
        return new GenericCommandResult(true, "Consulta removida com sucesso", default);
    }
}