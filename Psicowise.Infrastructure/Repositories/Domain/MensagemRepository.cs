using Microsoft.EntityFrameworkCore;
using Psicowise.Domain.Commands.MensagensCommand;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Repositories;
using Psicowise.Infrastructure.Contexts;

namespace Psicowise.Infrastructure.Repositories.Domain;

public class MensagemRepository : IMensagemRepository
{
    private readonly DataContext _context;

    public MensagemRepository(DataContext context)
    {
        _context = context;
    }


    public async Task<Mensagem> Create(CreateMensagemCommand mensagemCommand)
    {

        var mensagem = new Mensagem
        {
            MensagemTexto = mensagemCommand.MensagemTexto,
            PsicologoId = mensagemCommand.PsicologoId,
            PacienteId = mensagemCommand.PacienteId,
            DataDeEnvio = DateTime.Now.ToUniversalTime()
        };

        _context.Add(mensagem);
        _context.SaveChanges();

        return mensagem;
    }

    public async Task<Mensagem> Update(UpdateMensagemCommand mensagem)
    {
        var mensagemModel = _context.Mensagens
            .FirstOrDefault(mensagem => mensagem.Id == mensagem.Id);

        if (mensagemModel == null)
        {
            throw new Exception("Entidade não encontrada");
        }

        mensagemModel.MensagemTexto = mensagem.MensagemTexto;

        _context.Entry(mensagemModel).State = EntityState.Modified;
        _context.SaveChanges();

        return mensagemModel;
    }

    public async Task Remove(RemoveMensagemCommand? mensagem)
    {
        var mensagemModel = _context.Mensagens
            .FirstOrDefault(mensagem => mensagem.Id == mensagem.Id);

        if (mensagemModel == null)
        {
            throw new Exception("Entidade não encontrada");
        }

        _context.Remove(mensagemModel);
        _context.SaveChanges();
    }
}