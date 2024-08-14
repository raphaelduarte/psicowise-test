using Psicowise.Domain.Entities;
using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Commands;

public class UpdatePsicologoCommand
{
    public UpdatePsicologoCommand()
    {
        UpdatedAt = DateTime.Now.ToUniversalTime();
    }

    public UpdatePsicologoCommand(Guid id)
    {
        Id = id;
    }
    
    public UpdatePsicologoCommand(
        Endereco? endereco,
        Telefone? telefone
    )
    {
        Endereco = endereco;
        Telefone = telefone;
        UpdatedAt = DateTime.Now.ToUniversalTime();
    }
    public Guid Id { get; set; }
    public Endereco? Endereco { get; set; }
    public Telefone? Telefone { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.Now.ToUniversalTime();
}