using Microsoft.EntityFrameworkCore;
using Psicowise.Domain.Commands.LembretesCommand;
using Psicowise.Domain.ObjetosDeValor;
using Psicowise.Domain.Repositories;
using Psicowise.Infrastructure.Contexts;

namespace Psicowise.Infrastructure.Repositories.Domain;

public class LembreteRepository : ILembreteRepository
{
    private readonly DataContext _context;

    public LembreteRepository(DataContext context)
    {
        _context = context;
    }


    public async Task<Lembrete> Create(CreateLembreteCommand lembreteCommand)
    {
        try
        {
            var lembrete = new Lembrete
            {
                PsicologoId = lembreteCommand.PsicologoId,
                PacienteId = lembreteCommand.PacienteId,
                ConsultaId = lembreteCommand.ConsultaId,
                Mensagem = lembreteCommand.Mensagem,
                DataDeDisparo = DateTime.Now.ToUniversalTime(),
                IsDisparado = false
            };

            _context.Add(lembrete);
            await _context.SaveChangesAsync();

            return lembrete;
        }
        catch (Exception e)
        {
            throw new Exception("Um erro ocorreu ao criar um lembrete", e);
        }

    }

    public async Task<Lembrete> Update(UpdateLembreteCommand lembreteCommand)
    {
        var lembreteModel = _context.Lembretes
            .FirstOrDefault(lembrete => lembrete.Id == lembreteCommand.Id);

        if (lembreteModel == null)
        {
            throw new Exception("Entidade não encontrada");
        }

        if (lembreteCommand.Mensagem != null)
        {
            lembreteModel.Mensagem = lembreteCommand.Mensagem;
        }

        if (lembreteCommand.PacienteId != null)
        {
            lembreteModel.PacienteId = lembreteCommand.PacienteId;
        }

        if (lembreteCommand.ConsultaId != null)
        {
            lembreteModel.ConsultaId = lembreteCommand.ConsultaId;
        }

        if (lembreteCommand.DataDeDisparo != null)
        {
            lembreteModel.DataDeDisparo = lembreteCommand.DataDeDisparo;
        }

        if (lembreteCommand.IsDisparado != null)
        {
            lembreteModel.IsDisparado = lembreteCommand.IsDisparado;
        }

        _context.Entry(lembreteModel).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return lembreteModel;
    }

    public async Task Remove(RemoveLembreteCommand? lembreteCommand)
    {
        var lembreteModel = _context.Lembretes
            .FirstOrDefault(lembrete => lembrete.Id == lembreteCommand.LembreteId);

        if (lembreteModel == null)
        {
            throw new Exception("Entidade não encontrada");
        }

        _context.Remove(lembreteModel);
        _context.SaveChanges();
    }
}