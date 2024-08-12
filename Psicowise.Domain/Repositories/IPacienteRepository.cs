using Psicowise.Domain.Entities;

namespace Psicowise.Domain.Repositories;

public interface IPacienteRepository
{
    Task<Paciente> Create(Paciente paciente);
    Task<Paciente> Update(Paciente paciente);
    Task Remove(Paciente? paciente);
}