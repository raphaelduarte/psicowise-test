using System.ComponentModel.DataAnnotations.Schema;
using Psicowise.Domain.Entities;

namespace Psicowise.Domain.ObjetosDeValor;

public class Lembrete : Entity
{
    public Lembrete()
    {
        
    }
    public Lembrete(Guid psicologoId, Guid pacienteId, Guid consultaId, DateTime dataDeDisparo, string mensagem)
    {
        PsicologoId = psicologoId;
        PacienteId = pacienteId;
        ConsultaId = consultaId;
        DataDeDisparo = dataDeDisparo;
        Mensagem = mensagem;
    }
    [ForeignKey("PsicologoId")]
    public Guid PsicologoId { get; set; }

    [ForeignKey("PacienteId")]
    public Guid PacienteId { get; set; }

    [ForeignKey("ConsultaId")]
    public Guid ConsultaId { get; set; }

    public ETipoLembrete Tipo { get; set; }
    public string Mensagem { get; set; }
    public DateTime DataDeDisparo { get; set; }
    public bool IsDisparado { get; set; }


    //Propriedades de navegação

    public Psicologo Psicologo { get; set; }
    public Paciente Paciente { get; set; }
    public Consulta Consulta { get; set; }
}