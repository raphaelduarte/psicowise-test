using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Commands;

public class CreatePacienteCommand
{
    public CreatePacienteCommand(
        Guid psicologoId,
        NomeCompleto nome,
        string email,
        Telefone telefone,
        Endereco endereco,
        DateTime dataNascimento
    )
    {
        PsicologoId = psicologoId;
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
        DataNascimento = dataNascimento;
        CreatedAt = DateTime.Now;
        
    }
    public Guid PsicologoId { get;  set; }
    public NomeCompleto Nome { get;  set; }
    public string Email { get;  set; }
    public Telefone Telefone { get;  set; }
    public Endereco Endereco { get;  set; }
    public DateTime DataNascimento { get;  set; }
    public DateTime CreatedAt { get;  set; } = DateTime.Now;
}