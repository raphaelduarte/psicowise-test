using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using System.Linq;
using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Entities
{
    public class Psicologo : Entity
    {
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
            Endereco? endereco,
            Telefone? telefone
            )
        {
            Telefone = telefone;
            Endereco = endereco;
        }
        
        public Psicologo(
            Telefone? telefone
        )
        {
            Telefone = telefone;
        }
        
        public Psicologo(
            NomeCompleto nome,
            string crp,
            string email,
            Telefone telefone,
            Endereco endereco
            )
        {
            Nome = nome;
            Crp = crp;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            
        }
        public Psicologo(
            NomeCompleto nome,
            string crp,
            string email,
            Telefone telefone,
            Endereco endereco,
            List<Paciente?> pacientes
        )
        {
            Nome = nome;
            Crp = crp;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            Pacientes = pacientes;
            
            
        } 
        public NomeCompleto Nome { get; set; }
        public string Crp { get; set; }
        public string Email { get; set; }
        public Telefone Telefone { get; set; }
        public ICollection<Paciente>? Pacientes { get; set; } = new List<Paciente>();
        public Endereco Endereco { get; set; }
        public ICollection<Agenda>? Agendas { get; set; } = new List<Agenda>();
        public ICollection<Consulta>? Consultas { get; set; } = new List<Consulta>();
        public ICollection<Lembrete>? Lembretes { get; set; } = new List<Lembrete>();
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}