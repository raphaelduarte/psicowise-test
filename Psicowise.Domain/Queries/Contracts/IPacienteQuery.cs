using Psicowise.Domain.Entities;
using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Queries.Contracts;

public interface IPacienteQuery
{
    Task<Paciente> GetPacienteById(Guid pacienteId);
    Task<List<Paciente>> GetPacientesByPsicologoId(Guid psicologoId);
    Task<Telefone> GetPacienteNumber(Guid pacienteId);
}