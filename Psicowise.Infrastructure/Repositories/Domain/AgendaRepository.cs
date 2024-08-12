using Microsoft.EntityFrameworkCore;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Repositories;
using Psicowise.Infrastructure.Contexts;

namespace Psicowise.Infrastructure.Repositories.Domain;

public class AgendaRepository : IAgendaRepository
{
    private readonly DataContext _context;

    public AgendaRepository(DataContext context)
    {
        _context = context;
    }

    public Task<Agenda> Create(Agenda agenda)
    {
        _context.Add(agenda);
        _context.SaveChanges();
        return Task.FromResult(agenda);
    }

    public Task<Agenda> Update(Agenda agenda)
    {
        _context.Entry(agenda).State = EntityState.Modified;
        _context.SaveChanges();
        return Task.FromResult(agenda);
    }

    public Task<Agenda> Remove(Agenda agenda)
    {
        _context.Remove(agenda);
        _context.SaveChanges();
        return Task.FromResult(agenda);
    }
}