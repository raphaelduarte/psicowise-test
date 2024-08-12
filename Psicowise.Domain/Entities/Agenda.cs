using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Entities
{
    public class Agenda : Entity
    {
        public Agenda()
        {
            Horarios = new List<Horario>();
            Consultas = new List<Consulta>();
            Pacientes = new List<Paciente>();
        }

        public Agenda(Guid idAgenda, List<Horario> horarios)
        {

        }

        public Agenda(Guid psicologoId)
        {
            PsicologoId = psicologoId;
        }
        
        public Agenda(
            Guid psicologoId,
            ICollection<Horario> horarios
            )
        {
            PsicologoId = psicologoId;
            Horarios = horarios;
        }
        public Agenda(
            List<Horario> horarios,
            Guid psicologoId,
            List<Paciente> pacientes
            )
        {
            Horarios = horarios;
            PsicologoId = psicologoId;
            Pacientes = pacientes;
        }
        public new Guid Id { get; set; }
        public ICollection<Horario> Horarios { get; set; }
        public ICollection<Consulta> Consultas { get; set; }
        
        [ForeignKey("PsicologoId")]
        public Guid PsicologoId { get; set; }
        public ICollection<Paciente> Pacientes { get; set; }
        
        
        
        //Propriedades de navegação
        
        public Psicologo Psicologo { get; set; }
    }
}