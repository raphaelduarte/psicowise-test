using Psicowise.Domain.Commands;
using Psicowise.Domain.Commands.Interfaces;
using Psicowise.Domain.Commands.LembretesCommand;
using Psicowise.Domain.Commands.MensagensCommand;
using Psicowise.Domain.Handlers.Interfaces;
using Psicowise.Domain.ObjetosDeValor;
using Psicowise.Domain.Queries.Contracts;
using Psicowise.Domain.Repositories;
using Psicowise.Domain.Services;

namespace Psicowise.Domain.Handlers;

public class LembreteHandler : 
    IHandler<CreateLembreteCommand>,
    IHandler<UpdateLembreteCommand>,
    IHandler<RemoveLembreteCommand>
{
    private readonly ILembreteRepository _lembreteRepository;
    private readonly ILembreteQuery _lembreteQuery;
    private readonly IWhatsappService _whatsappService;
    private readonly IMensagensGeraisService _mensagensGeraisService;

    public LembreteHandler(
        ILembreteRepository lembreteRepository,
        ILembreteQuery lembreteQuery,
        IWhatsappService whatsappService,
        IMensagensGeraisService mensagensGeraisService
        )
    {
        _lembreteRepository = lembreteRepository;
        _lembreteQuery = lembreteQuery;
        _whatsappService = whatsappService;
        _mensagensGeraisService = mensagensGeraisService;
    }

    public async Task<ICommandResult> Handle(CreateLembreteCommand command)
    {
        var lembrete = await _lembreteRepository.Create(command);

        if (lembrete.PacienteId == null)
        {
            return new GenericCommandResult(
                false,
                "Error ao criar lembrete",
                lembrete);
        }
        await _mensagensGeraisService.AgendarMensagemAsync(
            new CreateMensagemCommand
            (
                command.PsicologoId,
                command.PacienteId,
                command.Mensagem,
                command.DataDeDisparo
            )
        );

        return new GenericCommandResult(
            true,
            "Lembrete criado com sucesso", 
            lembrete
            );
    }

    public Task<ICommandResult> Handle(UpdateLembreteCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<ICommandResult> Handle(RemoveLembreteCommand command)
    {
        throw new NotImplementedException();
    }
}