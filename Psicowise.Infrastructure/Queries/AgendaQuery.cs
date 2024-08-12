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
}