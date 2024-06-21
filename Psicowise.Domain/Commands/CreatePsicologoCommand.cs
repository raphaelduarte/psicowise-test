using Psicowise.Domain.Entities;
using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Commands;

public class CreatePsicologoCommand
{
    public CreatePsicologoCommand(
        NomeCompleto nome,
        string email,
        string crp
        )
    {
        Nome = nome;
        Email = email;
        Crp = crp;
    }
    public NomeCompleto Nome { get; set; }
    public string Email { get; set; }
    public string Crp { get; set; }
    public List<Paciente?> Pacientes { get; set; }
}