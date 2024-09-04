using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Entities
{
    public class Consulta : Entity
    {
        public Consulta()
        {
            
        }

        public Consulta(
            Guid psicologoId,
            Guid pacienteId,
            Guid agendaId,
            Horario horario
            )
            
        {
            PsicologoId = psicologoId;
            PacienteId = pacienteId;
            AgendaId = agendaId;
            Horario = horario;
        }

            [ForeignKey("PacienteId")]
            public Guid PacienteId { get; set; }
            
            
            [ForeignKey("PsicologoId")]
            public Guid PsicologoId { get; set; }
            
            
            [ForeignKey("AgendaId")]
            public Guid AgendaId { get; set; }
            
            
            public Horario Horario { get; set; }
            public string? Observacoes { get; set; }
            public bool Realizada { get; set; } = false;
            public bool Cancelada { get; set; } = false;
            public bool Remarcada { get; set; } = false;
            public bool Confirmada { get; set; } = false;
            public bool Paga { get; set; } = false;
            public bool PacienteFaltou { get; set; } = false;

            public ICollection<Lembrete> Lembretes { get; set; }

            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
            
            
            
            //Propriedades de navegação
            
            public Psicologo Psicologo { get; set; }
            public Paciente Paciente { get; set; }
            public Agenda Agenda { get; set; }
    }
}