using Microsoft.EntityFrameworkCore;
using Psicowise.Domain.ObjetosDeValor;
using Psicowise.Domain.Queries.Contracts;
using Psicowise.Infrastructure.Contexts;

namespace Psicowise.Infrastructure.Queries;

public class LembreteQuery : ILembreteQuery
{
    private readonly DataContext _context;

    public LembreteQuery(DataContext context)
    {
        _context = context;
    }

    public async Task<Lembrete> GetLembreteById(Guid lembreteId)
    {
        try
        {
            var lembreteModel = await _context
                .Lembretes
                .FirstOrDefaultAsync(lembrete => lembrete.Id == lembreteId);

            if(lembreteModel == null)
            {
                throw new Exception("Entidade não encontrada");
            }

            return new Lembrete
            {
                Id = lembreteModel.Id,
                PsicologoId = lembreteModel.PsicologoId,
                PacienteId = lembreteModel.PacienteId,
                ConsultaId = lembreteModel.ConsultaId,
                Tipo = lembreteModel.Tipo,
                Mensagem = lembreteModel.Mensagem,
                DataDeDisparo = lembreteModel.DataDeDisparo,
                IsDisparado = lembreteModel.IsDisparado,
            };
        }
        catch (Exception e)
        {
            throw new Exception("Um erro ocorreu enquanto requisitava um lembrete", e);
        }
    }
}