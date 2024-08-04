using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Psicowise.Domain.ObjetosDeValor
{
    public class NomeCompleto
    {
        public NomeCompleto(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
    }
}