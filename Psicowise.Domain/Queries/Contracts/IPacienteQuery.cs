using Psicowise.Domain.Entities;

namespace Psicowise.Domain.Queries.Contracts;

public interface IPacienteQuery
{
    Task<Paciente> GetPacienteById(Guid pacienteId);
    Task<List<Paciente>> GetPacientesByPsicologoId(Guid psicologoId);
}