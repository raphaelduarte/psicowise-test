using System.ComponentModel.DataAnnotations.Schema;

namespace Psicowise.Domain.Entities;

public class Mensagem : Entity
{
    public string MensagemTexto { get; set; }

    [ForeignKey("PsicologoId")]
    public Guid PsicologoId { get; set; }


    [ForeignKey("PacienteId")]
    public Guid PacienteId { get; set; }


    public DateTime DataDeEnvio { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;


    //Propriedades de navegação
    public Psicologo Psicologo { get; set; }
    public Paciente Paciente { get; set; }
}