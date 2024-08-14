using Psicowise.Domain.Entities;
using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Commands;

public class CreatePsicologoCommand
{
    public CreatePsicologoCommand(
        NomeCompleto nome,
        string email,
        Telefone telefone,
        string crp,
        Endereco endereco
        )
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Crp = crp;
        Endereco = endereco;
        CreatedAt = DateTime.Now.ToUniversalTime();
    }
    public NomeCompleto Nome { get; set; }
    public string Email { get; set; }
    public Telefone Telefone { get; set; }
    public string Crp { get; set; }
    public Endereco Endereco { get; set; }
    public DateTime CreatedAt { get; set; }
}