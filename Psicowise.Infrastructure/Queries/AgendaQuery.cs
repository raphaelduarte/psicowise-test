using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Queries.Contracts;
using Psicowise.Infrastructure.Contexts;
using Psicowise.Infrastructure.Models;

namespace Psicowise.Infrastructure.Queries;

public class AgendaQuery : IAgendaQuery
{
    private readonly DataContext _context;

    public AgendaQuery(DataContext context)
    {
        _context = context;
    }
    public async Task<Agenda> GetAgendaById(Guid agendaId)
    {
        try
        {
            var agendaModel = _context
                .Agendas
                .FirstOrDefault(agenda => agenda.Id == agendaId);

            if (agendaModel == null)
            {
                throw new Exception("Entidade não encontrada");
            }

            return new Agenda
            {
                Id = agendaModel.Id,
                PsicologoId = agendaModel.PsicologoId,
                Pacientes = agendaModel.Pacientes,
                Horarios = agendaModel.Horarios
            };

        }
        catch (Exception ex)
        {
            throw new Exception("Um erro ocorreu enquanto atualizava uma agenda.", ex);
        }
    }

    public Task<bool> VerificarDisponibilidade(Guid psicologoId, DateTime horarioEDiaDesejado)
    {
        // Trazer todas as consultas do psicólogo e fazer a verificação em memória
        var consultas = _context.Consultas
            .Where(c => c.PsicologoId == psicologoId)
            .AsEnumerable() // Traz os dados para memória para a comparação de DateTime
            .Any(c => c.Horario.InicioConsulta <= horarioEDiaDesejado && c.Horario.FimConsulta >= horarioEDiaDesejado);

        if (consultas)
        {
            return Task.FromResult(false);
        }

        // Verifica se o horário desejado está disponível na agenda do psicólogo
        var horarioDisponivel = !_context.Agendas
            .Where(a => a.PsicologoId == psicologoId)
            .SelectMany(a => a.Horarios)
            .AsEnumerable() // Traz os dados para memória para a comparação de DateTime
            .Any(h => h.InicioConsulta <= horarioEDiaDesejado && h.FimConsulta >= horarioEDiaDesejado);

        return Task.FromResult(horarioDisponivel);
    }
}