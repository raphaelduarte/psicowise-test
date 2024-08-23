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
    
    public ConsultaHandler(
        IConsultaRepository consultaRepository,
        IConsultaQuery consultaQuery
        )
    {
        _consultaRepository = consultaRepository;
        _consultaQuery = consultaQuery;
    }
    
    public async Task<ICommandResult> Handle(CreateConsultaCommand command)
    {
        var consulta = new Consulta(
            command.PacienteId,
            command.PsicologoId,
            command.AgendaId,
            command.Horario
        );
        
        consulta.CreatedAt = command.CreatedAt;
        
        await _consultaRepository.Create(consulta);
        return new GenericCommandResult(true, "Consulta criada com sucesso", consulta);
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