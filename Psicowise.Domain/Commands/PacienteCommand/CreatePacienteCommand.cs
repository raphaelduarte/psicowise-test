using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Commands.PacienteCommand;

public class CreatePacienteCommand
{
    public CreatePacienteCommand(
        Guid psicologoId,
        NomeCompleto nome,
        string email,
        string telefone
    )
    {
        PsicologoId = psicologoId;
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }
    public Guid PsicologoId { get;  set; }
    public NomeCompleto Nome { get;  set; }
    public string Email { get;  set; }
    public string Telefone { get;  set; }
}