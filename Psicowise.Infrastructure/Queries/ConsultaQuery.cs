using Microsoft.EntityFrameworkCore;
using Psicowise.Domain.Dtos;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Queries.Contracts;
using Psicowise.Infrastructure.Contexts;

namespace Psicowise.Infrastructure.Queries;

public class ConsultaQuery : IConsultaQuery
{
    private readonly DataContext _context;

    public ConsultaQuery(DataContext context)
    {
        _context = context;
    }
    
    public async Task<Consulta?> GetConsultaById(Guid consultaId)
    {
        try
        {
            var consultaModel =  _context
                .Consultas
                .FirstOrDefault(consulta => consulta.Id == consultaId);

            if (consultaModel == null)
            {
                throw new Exception("Entidade não encontrada");
            }

            var consulta = new Consulta
            {
                Id = consultaModel.Id,
                PacienteId = consultaModel.PacienteId,
                PsicologoId = consultaModel.PsicologoId,
                Horario = consultaModel.Horario,
                Observacoes = consultaModel.Observacoes,
                Realizada = consultaModel.Realizada,
                Cancelada = consultaModel.Cancelada,
                Remarcada = consultaModel.Remarcada,
                Confirmada = consultaModel.Confirmada,
                Paga = consultaModel.Paga,
                PacienteFaltou = consultaModel.PacienteFaltou,
                CreatedAt = consultaModel.CreatedAt,
                UpdatedAt = consultaModel.UpdatedAt
            };

            return consulta;

        }
        catch (Exception ex)
        {
            throw new Exception("Um erro ocorreu enquanto atualizava uma consulta.", ex);
        }
    }

    public async Task<List<ConsultaDto>> GetAllConsultasDoPsicologo(Guid psicologoId)
    {
        var consultas = _context.Consultas.Select(c => new ConsultaDto
        {
            Id = c.Id,
            DataConsulta = c.Horario.InicioConsulta,
            Observacoes = c.Observacoes,
            Paciente = new PacienteDto
            {
                Id = c.Paciente.Id,
                NomeCompleto = $"{c.Paciente.Nome.Nome} {c.Paciente.Nome.Sobrenome}",
                Email = c.Paciente.Email
            }
        }).ToList();

        return consultas;
    }
}