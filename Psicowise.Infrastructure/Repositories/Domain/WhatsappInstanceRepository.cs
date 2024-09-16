using Microsoft.EntityFrameworkCore;
using Psicowise.Domain.Commands.WhatsappInstanceCommand;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Repositories;
using Psicowise.Infrastructure.Contexts;

namespace Psicowise.Infrastructure.Repositories.Domain;

public class WhatsappInstanceRepository : IWhatsappInstanceRepository
{
    private readonly DataContext _context;

    public WhatsappInstanceRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<WhatsappInstance> Create(WhatsappInstance command)
    {
        _context.WhatsappInstances.Add(command);
        await _context.SaveChangesAsync();

        return command;
    }

    public async Task<WhatsappInstance> Update(UpdateWhatsappInstanceCommand command)
    {
        var instance = await _context.WhatsappInstances
            .FirstOrDefaultAsync(i => i.Id == command.Id);

        if (instance == null)
        {
            throw new Exception("Instância do WhatsApp não encontrada");
        }

        instance.NomeDaInstancia = command.NomeDaInstancia;
        _context.WhatsappInstances.Update(instance);
        await _context.SaveChangesAsync();

        return instance;
    }

    public async Task Remove(RemoveWhatsappInstanceCommand? command)
    {
        var instance = await _context.WhatsappInstances
            .FirstOrDefaultAsync(i => i.Id == command.Id);

        if (instance == null)
        {
            throw new Exception("Instância do WhatsApp não encontrada");
        }

        _context.WhatsappInstances.Remove(instance);
        await _context.SaveChangesAsync();
    }
}