using Psicowise.Domain.Commands;
using Psicowise.Domain.Commands.Interfaces;
using Psicowise.Domain.Commands.MensagensCommand;
using Psicowise.Domain.Commands.WhatsappInstanceCommand;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Handlers.Interfaces;
using Psicowise.Domain.Repositories;
using Psicowise.Domain.Services;

namespace Psicowise.Domain.Handlers;

public class WhatsappHandler : IHandler<CreateWhatsappInstanceCommand>
{
    private readonly IWhatsappService _whatsappService;
    private readonly IWhatsappInstanceRepository _whatsappInstanceRepository;

    public WhatsappHandler(
        IWhatsappService whatsappService,
        IWhatsappInstanceRepository whatsappInstanceRepository)
    {
        _whatsappService = whatsappService;
        _whatsappInstanceRepository = whatsappInstanceRepository;
    }

    public async Task<ICommandResult> Handle(CreateWhatsappInstanceCommand command)
    {
        try
        {
            var whatsappInstance = new WhatsappInstance
            {
                PsicologoId = command.PsicologoId,
                NomeDaInstancia = command.NomeDaInstancia,
                Token = Guid.NewGuid(),
                QrCode = true
            };

                var whatsappInstanceService = await _whatsappService
                .CriarInstanciaWhatsapp(
                    whatsappInstance.NomeDaInstancia,
                    whatsappInstance.Token.ToString(),
                    whatsappInstance.QrCode
                );

            var isWhatsappInstanceCreated = whatsappInstanceService.Success;

            if (isWhatsappInstanceCreated is false)
            {
                return  new GenericCommandResult(
                        false,
                        "Erro ao criar instância do Whatsapp no EvolutionAPI",
                        whatsappInstance
                );
            }

            var wpContext = await _whatsappInstanceRepository.Create(whatsappInstance);

            if(wpContext is null)
            {
                return new GenericCommandResult(
                    false,
                    "Erro ao salvar instância do Whatsapp no banco de dados",
                    wpContext
                );
            }

            return new GenericCommandResult(
                true,
                "Instância do Whatsapp criada com sucesso",
                whatsappInstance
            );

        }
        catch (Exception e)
        {
            return new GenericCommandResult(
                    false,
                    e.Message,
                    e
            );
        }
    }
}