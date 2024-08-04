using Psicowise.Domain.Entities;
using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Commands;

public class UpdatePsicologoCommand
{
    public UpdatePsicologoCommand(
        Guid id,
        Endereco? endereco,
        List<Paciente?> pacientes,
        List<Consulta?> consultas,
        List<Agenda?> agendas
    )
    {
        Id = id;
        Endereco = endereco;
    }
    public Guid Id { get; private set; }
    public Endereco? Endereco { get; private set; }
}