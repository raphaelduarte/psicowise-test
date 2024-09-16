using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Psicowise.Domain.Queries.Contracts;
using Psicowise.Infrastructure.Contexts;

namespace Psicowise.Infrastructure.Queries;

public class WhatsappServiceQuery : IWhatsappServiceQuery
{
    private readonly DataContext _context;

    public WhatsappServiceQuery(DataContext context)
    {
        _context = context;
    }

    public async Task<string> GetInstanceName(Guid psicologoId)
    {
        try
        {
            var instanceName = await _context.WhatsappInstances
                .Where(instance => instance.PsicologoId == psicologoId)
                .Select(instance => instance.NomeDaInstancia)
                .FirstOrDefaultAsync();

            if (instanceName == null)
            {
                throw new Exception("Instância do WhatsApp não encontrada");
            }

            return instanceName;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("Error ao requisitar instância",e);
        }
    }

    public async Task<List<string>> GetAllInstanceByPsicologoId(Guid psicologoId)
    {
        try
        {
            var instanceNames = _context.WhatsappInstances
                .Where(instance => instance.PsicologoId == psicologoId)
                .Select(instance => instance.NomeDaInstancia)
                .ToListAsync().Result;

            return instanceNames;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("Error ao requisitar instância", e);
        }
    }
}