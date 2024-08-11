using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Entities
{
    public class Psicologo : Entity
    {
        public Psicologo(Guid id)
        {
            Id = id;
        }

        public Psicologo()
        {
            Nome = new NomeCompleto("", "")!;
            Crp = string.Empty;
            Email = string.Empty;
            Pacientes = new List<Paciente>();
            Consultas = new List<Consulta>();
            Agendas = new List<Agenda>();
        }
        public Psicologo(
            Endereco? endereco
        )
        {
            Endereco = endereco;
        }
        
        public Psicologo(
            NomeCompleto nome,
            string crp,
            string email,
            Endereco? endereco
            )
        {
            Nome = nome;
            Crp = crp;
            Email = email;
            Endereco = endereco;
            
        }
        public Psicologo(
            NomeCompleto nome,
            string crp,
            string email,
            Endereco? endereco,
            List<Paciente?> pacientes
        )
        {
            Nome = nome;
            Crp = crp;
            Email = email;
            Endereco = endereco;
            Pacientes = pacientes;
            
            
        }
        public new Guid Id { get;  set; }
        public NomeCompleto Nome { get; set; }
        public string Crp { get; set; }
        public string Email { get; set; }
        public ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
        public Endereco? Endereco { get; set; }
        public ICollection<Agenda>? Agendas { get; set; }
        public ICollection<Consulta>? Consultas { get; set; }
    }
}