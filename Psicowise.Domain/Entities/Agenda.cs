using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Entities
{
    public class Agenda : Entity
    {
        public Agenda()
        {
            
        }

        public Agenda(Guid idAgenda, List<Horario> horarios)
        {

        }

        public Agenda(Psicologo psicologo)
        {
            Psicologo = psicologo;
        }
        
        public Agenda(
            Psicologo psicologo,
            ICollection<Horario> horarios
            )
        {
            Psicologo = psicologo;
            Horarios = horarios;
        }
        public Agenda(
            List<Horario> horarios,
            Psicologo psicologo,
            List<Paciente> pacientes
            )
        {
            Horarios = horarios;
            Psicologo = psicologo;
            Pacientes = pacientes;
        }
        public Guid Id { get; set; }
        public ICollection<Horario> Horarios { get; set; }
        public Psicologo Psicologo { get; set; }
        public ICollection<Paciente> Pacientes { get; set; }
    }
}