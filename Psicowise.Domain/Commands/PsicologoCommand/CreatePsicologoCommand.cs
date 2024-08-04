using Psicowise.Domain.Entities;
using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Commands;

public class CreatePsicologoCommand
{
    public CreatePsicologoCommand(
        NomeCompleto nome,
        string email,
        string crp,
        Endereco endereco
        )
    {
        Nome = nome;
        Email = email;
        Crp = crp;
        Endereco = endereco;
    }
    public NomeCompleto Nome { get; set; }
    public string Email { get; set; }
    public string Crp { get; set; }
    public Endereco Endereco { get; set; }
}