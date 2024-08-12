using Microsoft.EntityFrameworkCore;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Repositories;
using Psicowise.Infrastructure.Contexts;

namespace Psicowise.Infrastructure.Repositories.Domain;

public class PacienteRepository : IPacienteRepository
{
    private readonly DataContext _context;

    public PacienteRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<Paciente> Create(Paciente paciente)
    {
        var _paciente = new Paciente()
        {
            Nome = paciente.Nome,
            Email = paciente.Email,
            Endereco = paciente.Endereco,
            DataNascimento = paciente.DataNascimento,
            PsicologoId = paciente.PsicologoId,
            Cpf = paciente.Cpf,
            Rg = paciente.Rg,
            Sexo = paciente.Sexo,
            EstadoCivil = paciente.EstadoCivil,
            Profissao = paciente.Profissao,
            Escolaridade = paciente.Escolaridade,
            Religiao = paciente.Religiao,
            NomePai = paciente.NomePai,
            NomeMae = paciente.NomeMae,
            Convenio = paciente.Convenio,
            Plano = paciente.Plano,
            NumeroCarteirinha = paciente.NumeroCarteirinha,
            ValidadeCarteirinha = paciente.ValidadeCarteirinha,
            Observacoes = paciente.Observacoes,
            MotivoConsulta = paciente.MotivoConsulta,
            HistoricoFamiliar = paciente.HistoricoFamiliar,
            HistoricoPessoal = paciente.HistoricoPessoal,
            HistoricoProfissional = paciente.HistoricoProfissional,
            HistoricoMedico = paciente.HistoricoMedico,
            Medicamentos = paciente.Medicamentos,
            Alergias = paciente.Alergias,
            Cirurgias = paciente.Cirurgias,
            Internacoes = paciente.Internacoes,
            Tabagismo = paciente.Tabagismo,
            Alcoolismo = paciente.Alcoolismo,
            Drogas = paciente.Drogas,
            AtividadeFisica = paciente.AtividadeFisica,
            Alimentacao = paciente.Alimentacao,
            Sono = paciente.Sono,
            Relacionamentos = paciente.Relacionamentos,
            Sexualidade = paciente.Sexualidade,
            Lazer = paciente.Lazer,
            Espiritualidade = paciente.Espiritualidade,
            Queixas = paciente.Queixas,
            Objetivos = paciente.Objetivos,
            Expectativas = paciente.Expectativas,
            Diagnostico = paciente.Diagnostico,
            Prognostico = paciente.Prognostico,
            PlanoTerapeutico = paciente.PlanoTerapeutico,
            Encaminhamentos = paciente.Encaminhamentos,
            ObservacoesConsulta = paciente.ObservacoesConsulta,
            Status = paciente.Status
        };

        _context.Add(_paciente);
        _context.SaveChanges();
        return  await Task.FromResult(_paciente);;
    }

    public Task<Paciente> Update(Paciente paciente)
    {
        _context.Entry(paciente).State = EntityState.Modified;
        _context.SaveChanges();
        return Task.FromResult(paciente);
    }

    public async Task Remove(Paciente? paciente)
    {
        if (paciente != null)
        {
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
        }
    }
}