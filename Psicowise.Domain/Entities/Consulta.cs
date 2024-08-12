using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Psicowise.Domain.Entities
{
    public class Consulta : Entity
    {
        public Consulta(
            Guid pacienteId,
            Guid psicologoId,
            DateTime inicio,
            DateTime fim,
            string observacoes,
            bool realizada,
            bool cancelada,
            bool remarcada,
            bool confirmada,
            bool paga,
            bool pacienteFaltou
        )
        {
            PacienteId = pacienteId;
            PsicologoId = psicologoId;
            Inicio = inicio;
            Fim = fim;
            Observacoes = observacoes;
            Realizada = realizada;
            Cancelada = cancelada;
            Remarcada = remarcada;
            Confirmada = confirmada;
            Paga = paga;
            PacienteFaltou = pacienteFaltou;
        }
        
            [ForeignKey("PacienteId")]
            public Guid PacienteId { get; set; }
            
            
            [ForeignKey("PsicologoId")]
            public Guid PsicologoId { get; set; }
            
            
            [ForeignKey("AgendaId")]
            public Guid AgendaId { get; set; }
            
            
            public DateTime Inicio { get; set; }
            public DateTime Fim { get; set; }
            public string Observacoes { get; set; }
            public bool Realizada { get; set; } = false;
            public bool Cancelada { get; set; } = false;
            public bool Remarcada { get; set; } = false;
            public bool Confirmada { get; set; } = false;
            public bool Paga { get; set; } = false;
            public bool PacienteFaltou { get; set; } = false;
            
            
            
            //Propriedades de navegação
            
            public Psicologo Psicologo { get; set; }
            public Paciente Paciente { get; set; }
            public Agenda Agenda { get; set; }
    }
}