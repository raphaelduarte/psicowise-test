using Microsoft.EntityFrameworkCore;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Repositories;
using Psicowise.Infrastructure.Contexts;
using Psicowise.Infrastructure.Models;

namespace Psicowise.Infrastructure.Repositories.Domain;

public class PsicologoRepository : IPsicologoRepository
{
    private readonly DataContext _context;

    public PsicologoRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<Psicologo> Create(Psicologo psicologo)
    {
        var _psicologo = new Psicologo
        {
            Nome = psicologo.Nome,
            Crp = psicologo.Crp,
            Email = psicologo.Email,
            Endereco = psicologo.Endereco
        };

        _context.Add(psicologo);
        _context.SaveChanges();
        return  await Task.FromResult(_psicologo);
    }

    public Task<Psicologo> Update(Psicologo psicologo)
    {
        _context.Entry(psicologo).State = EntityState.Modified;
        _context.SaveChanges();
        return Task.FromResult(psicologo);
    }

    public async Task Remove(Psicologo? psicologo)
    {
        if (psicologo != null)
        {
            _context.Psicologos.Remove(psicologo);
            await _context.SaveChangesAsync();
        }
    }
}