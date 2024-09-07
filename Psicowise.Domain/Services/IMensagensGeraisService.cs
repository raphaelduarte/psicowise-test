using Psicowise.Domain.Commands.MensagensCommand;
using Psicowise.Domain.Commands;

namespace Psicowise.Domain.Services;

public interface IMensagensGeraisService
{
    Task<GenericCommandResult> AgendarMensagemAsync(CreateMensagemCommand command);
    Task<GenericCommandResult> AtualizarMensagemAsync(UpdateMensagemCommand command);
    Task<GenericCommandResult> RemoverMensagemAsync(RemoveMensagemCommand command);
}