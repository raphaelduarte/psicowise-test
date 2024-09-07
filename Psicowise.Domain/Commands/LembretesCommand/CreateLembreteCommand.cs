using Psicowise.Domain.Entities;
using Psicowise.Domain.ObjetosDeValor;
using System.ComponentModel.DataAnnotations.Schema;

namespace Psicowise.Domain.Commands.LembretesCommand;

public class CreateLembreteCommand
{
    public Guid PsicologoId { get; set; }
    public Guid PacienteId { get; set; }
    public Guid ConsultaId { get; set; }

    public ETipoLembrete Tipo { get; set; }
    public string Mensagem { get; set; }
    public DateTime DataDeDisparo { get; set; }
    public bool IsDisparado { get; set; } = false;
}