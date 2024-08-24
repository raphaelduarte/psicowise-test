using Microsoft.EntityFrameworkCore;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Repositories;
using Psicowise.Infrastructure.Contexts;

namespace Psicowise.Infrastructure.Repositories.Domain;

public class ConsultaRepository : IConsultaRepository
{
    private readonly DataContext _context;

    public ConsultaRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Consulta> Create(Consulta consulta)
    {
        var _consulta = new Consulta
        {
            Id = consulta.Id,
            PacienteId = consulta.PacienteId,
            PsicologoId = consulta.PsicologoId,
            AgendaId = consulta.AgendaId,
            Horario = consulta.Horario,
            Observacoes = consulta.Observacoes,
            Realizada = consulta.Realizada,
            Cancelada = consulta.Cancelada,
            Remarcada = consulta.Remarcada,
            Confirmada = consulta.Confirmada,
            Paga = consulta.Paga,
            PacienteFaltou = consulta.PacienteFaltou,
            CreatedAt = consulta.CreatedAt,
            UpdatedAt = consulta.UpdatedAt
        };

        _context.Add(_consulta);
        _context.SaveChanges();
        return await Task.FromResult(_consulta);
    }
    
    public Task<Consulta> Update(Consulta consulta)
    {
        _context.Entry(consulta).State = EntityState.Modified;
        _context.SaveChanges();
        return Task.FromResult(consulta);
    }
    

    public Task Remove(Consulta? consulta)
    {
        if (consulta != null)
        {
            _context.Consultas.Remove(consulta);
            _context.SaveChanges();
        }
        return Task.CompletedTask;
    }
}