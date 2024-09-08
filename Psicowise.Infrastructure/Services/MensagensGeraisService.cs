using Hangfire;
using Psicowise.Domain.Commands;
using Psicowise.Domain.Commands.MensagensCommand;
using Psicowise.Domain.Queries.Contracts;
using Psicowise.Domain.Services;

namespace Psicowise.Infrastructure.Services;

public class MensagensGeraisService : IMensagensGeraisService
{
    private readonly IWhatsappService _whatsappService;
    private readonly IPacienteQuery _pacienteQuery;
    private readonly IWhatsappServiceQuery _whatsappServiceQuery;

    public MensagensGeraisService(
        IWhatsappService whatsappService,
        IPacienteQuery pacienteQuery,
        IWhatsappServiceQuery whatsappServiceQuery
        )
    {
        _whatsappService = whatsappService;
        _pacienteQuery = pacienteQuery;
        _whatsappServiceQuery = whatsappServiceQuery;
    }

    public async Task<GenericCommandResult> AgendarMensagemAsync(CreateMensagemCommand command)
    {
        try
        {
            var instanceName = _whatsappServiceQuery
                .GetInstanceName(
                    command.PsicologoId
                    )
                .Result;

            var pacienteNumber = _pacienteQuery
                .GetPacienteNumber(
                    command.PacienteId
                    )
                .Result;


            var pacienteNumberFormated = $"+55{pacienteNumber.Ddd}{pacienteNumber.Numero}";

            var jobId = BackgroundJob.Schedule(
                () => 
                _whatsappService.SendTextMessage(
                    instanceName,
                    pacienteNumberFormated,
                    command.MensagemTexto
                ), command.DataHoraEnvio);


            return new GenericCommandResult(
                true, 
                "Mensagem agendada com sucesso", 
                jobId);
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

            var jobId = BackgroundJob.Schedule(() => 
                AtualizarMensagemAsync(command), command.DataHoraEnvio);

            return new GenericCommandResult(
                true, 
                "Mensagem atualizada com sucesso", 
                jobId);
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

            return new GenericCommandResult(
                true, 
                "Mensagem removida com sucesso", 
                command.MensagemId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}