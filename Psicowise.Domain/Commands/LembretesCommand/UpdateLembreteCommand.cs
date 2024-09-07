using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Commands.LembretesCommand;

public class UpdateLembreteCommand
{
    public UpdateLembreteCommand(
        Guid id,
        Guid pacienteId,
        Guid consultaId,
        ETipoLembrete tipo,
        string mensagem,
        DateTime dataDeDisparo
    )
    {
        Id = id;
        PacienteId = pacienteId;
        ConsultaId = consultaId;
        Tipo = tipo;
        Mensagem = mensagem;
        DataDeDisparo = dataDeDisparo;
    }
    public Guid Id { get; set; }
    public Guid PacienteId { get; set; }
    public Guid ConsultaId { get; set; }
    public ETipoLembrete Tipo { get; set; }
    public string Mensagem { get; set; }
    public DateTime DataDeDisparo { get; set; }
    public bool IsDisparado { get; set; } = false;
}