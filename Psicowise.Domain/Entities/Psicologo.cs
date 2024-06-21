using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Entities
{
    public class Psicologo
    {
        NomeCompleto Nome { get; set; }
        string Crp { get; set; }
        string Email { get; set; }
        List<Paciente> Pacientes { get; set; }
    }
}