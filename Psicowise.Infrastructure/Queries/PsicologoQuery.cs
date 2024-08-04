using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Psicowise.Domain.Commands;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Queries.Contracts;
using Psicowise.Infrastructure.Contexts;
using Psicowise.Infrastructure.Models;

namespace Psicowise.Infrastructure.Queries;

public class PsicologoQuery : IPsicologoQuery
{
    private readonly DataContext _context;

    public PsicologoQuery(DataContext context)
    {
        _context = context;
    }

    public Psicologo GetPsicologoById(Guid psicologoId)
    {
        try
        {
            var psicologoModel = _context
                .Psicologos
                .FirstOrDefault(psicologo => psicologo.Id == psicologoId);

            return new Psicologo
            {
                Id = psicologoModel.Id,
                Nome = psicologoModel.Nome,
                Email = psicologoModel.Email,
                Endereco = psicologoModel.Endereco,
                Crp = psicologoModel.Crp,
                Consultas = psicologoModel.Consultas,
                Pacientes = psicologoModel.Pacientes,
                Agendas = psicologoModel.Agendas
            };

        }
        catch (Exception ex)
        {
            throw new Exception("Um erro ocorreu enquanto atualizava um psicologo.", ex);
        }
    }
}