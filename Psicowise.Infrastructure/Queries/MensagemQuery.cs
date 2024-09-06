using Microsoft.EntityFrameworkCore;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Queries.Contracts;
using Psicowise.Infrastructure.Contexts;

namespace Psicowise.Infrastructure.Queries;

public class MensagemQuery : IMensagemQuery
{
    private readonly DataContext _context;

    public MensagemQuery(DataContext context)
    {
        _context = context;
    }
    public async Task<Mensagem> GetMensagemById(Guid mensagemId)
    {
        try
        {
            var mensagemModel = await _context
                .Mensagens
                .FirstOrDefaultAsync(mensagem => mensagem.Id == mensagemId);

            if (mensagemModel == null)
            {
                throw new Exception("Entidade não encontrada");
            }

            return new Mensagem
            {
                Id = mensagemModel.Id,
                MensagemTexto = mensagemModel.MensagemTexto,
                PsicologoId = mensagemModel.PsicologoId,
                PacienteId = mensagemModel.PacienteId,
                DataDeEnvio = mensagemModel.DataDeEnvio,
                CreatedAt = DateTime.Now.ToUniversalTime()
            };
        }
        catch (Exception ex)
        {
            throw new Exception("Um erro ocorreu enquanto requisitava uma mensagem", ex);
        }
        ;
    }
}