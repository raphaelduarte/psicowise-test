using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Commands.ConsultaCommand;

public class UpdateConsultaCommand
{
    public UpdateConsultaCommand(
        Horario horario,
        Guid pacienteId,
        string? observacoes,
        bool realizada,
        bool cancelada,
        bool remarcada,
        bool confirmada,
        bool paga,
        bool pacienteFaltou
    )
    {
        PacienteId = pacienteId;
        Horario = horario;
        Observacoes = observacoes;
        Realizada = realizada;
        Cancelada = cancelada;
        Remarcada = remarcada;
        Confirmada = confirmada;
        Paga = paga;
        PacienteFaltou = pacienteFaltou;
        UpdatedAt = DateTime.Now.ToUniversalTime();
    }
    public Guid Id { get; set; }
    public Horario? Horario { get; set; }
    public Guid? PacienteId { get; set; }
    public string? Observacoes { get; set; }
    public bool Realizada { get; set; } = false;
    public bool Cancelada { get; set; } = false;
    public bool Remarcada { get; set; } = false;
    public bool Confirmada { get; set; } = false;
    public bool Paga { get; set; } = false;
    public bool PacienteFaltou { get; set; } = false;
    public DateTime UpdatedAt { get; set; } = DateTime.Now.ToUniversalTime();
}