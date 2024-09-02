using Microsoft.EntityFrameworkCore;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Queries.Contracts;
using Psicowise.Infrastructure.Contexts;

namespace Psicowise.Infrastructure.Queries;

public class TesteQuery : ITesteQuery
{
    private readonly DataContext _context;

    public TesteQuery(DataContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Psicologo>> GetAllPsicologos()
    {
        var psicologos = await _context.Psicologos.ToListAsync();

        return psicologos;
    }
}