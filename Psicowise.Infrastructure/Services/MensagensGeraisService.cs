﻿using Hangfire;
using Psicowise.Domain.Commands;
using Psicowise.Domain.Commands.MensagensCommand;
using Psicowise.Domain.Services;

namespace Psicowise.Infrastructure.Services;

public class MensagensGeraisService : IMensagensGeraisService
{
    public async Task<GenericCommandResult> AgendarMensagemAsync(CreateMensagemCommand command)
    {
        try
        {
            var jobId = BackgroundJob.Schedule(() => AgendarMensagemAsync(command), command.DataHoraEnvio);

            return new GenericCommandResult(true, "Mensagem agendada com sucesso", jobId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<GenericCommandResult> AtualizarMensagemAsync(UpdateMensagemCommand command)
    {
        try
        {
            BackgroundJob.Delete(command.ToString());

            var jobId = BackgroundJob.Schedule(() => AtualizarMensagemAsync(command), command.DataHoraEnvio);

            return new GenericCommandResult(true, "Mensagem atualizada com sucesso", jobId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<GenericCommandResult> RemoverMensagemAsync(RemoveMensagemCommand command)
    {
        try
        {
            BackgroundJob.Delete(command.MensagemId.ToString());

            return new GenericCommandResult(true, "Mensagem removida com sucesso", command.MensagemId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}