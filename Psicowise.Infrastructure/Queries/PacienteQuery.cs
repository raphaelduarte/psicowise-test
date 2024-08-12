using Psicowise.Domain.Entities;
using Psicowise.Domain.Queries.Contracts;
using Psicowise.Infrastructure.Contexts;

namespace Psicowise.Infrastructure.Queries;

public class PacienteQuery : IPacienteQuery
{
    private readonly DataContext _context;

    public PacienteQuery(DataContext context)
    {
        _context = context;
    }
    
    public async Task<Paciente> GetPacienteById(Guid pacienteId)
    {
        try
        {
            var pacienteModel =  _context
                .Pacientes
                .FirstOrDefault(paciente => paciente.Id == pacienteId);

            if (pacienteModel == null)
            {
                throw new Exception("Entidade não encontrada");
            }

            var paciente = new Paciente
            {
                PacienteId = pacienteModel.Id,
                Nome = pacienteModel.Nome,
                Email = pacienteModel.Email,
                Endereco = pacienteModel.Endereco,
                Consultas = pacienteModel.Consultas,
                PsicologoId = pacienteModel.PsicologoId,
                Telefone = pacienteModel.Telefone,
                DataNascimento = pacienteModel.DataNascimento,
                Cpf = pacienteModel.Cpf,
                Rg = pacienteModel.Rg,
                Sexo = pacienteModel.Sexo,
                EstadoCivil = pacienteModel.EstadoCivil,
                Profissao = pacienteModel.Profissao,
                Escolaridade = pacienteModel.Escolaridade,
                Religiao = pacienteModel.Religiao,
                NomePai = pacienteModel.NomePai,
                NomeMae = pacienteModel.NomeMae,
                Convenio = pacienteModel.Convenio,
                Plano = pacienteModel.Plano,
                NumeroCarteirinha = pacienteModel.NumeroCarteirinha,
                ValidadeCarteirinha = pacienteModel.ValidadeCarteirinha,
                Observacoes = pacienteModel.Observacoes,
                MotivoConsulta = pacienteModel.MotivoConsulta,
                HistoricoFamiliar = pacienteModel.HistoricoFamiliar,
                HistoricoPessoal = pacienteModel.HistoricoPessoal,
                HistoricoProfissional = pacienteModel.HistoricoProfissional,
                HistoricoMedico = pacienteModel.HistoricoMedico,
                Medicamentos = pacienteModel.Medicamentos,
                Alergias = pacienteModel.Alergias,
                Cirurgias = pacienteModel.Cirurgias,
                Internacoes = pacienteModel.Internacoes,
                Tabagismo = pacienteModel.Tabagismo,
                Alcoolismo = pacienteModel.Alcoolismo,
                Drogas = pacienteModel.Drogas,
                AtividadeFisica = pacienteModel.AtividadeFisica,
                Alimentacao = pacienteModel.Alimentacao,
                Sono = pacienteModel.Sono,
                Relacionamentos = pacienteModel.Relacionamentos,
                Sexualidade = pacienteModel.Sexualidade,
                Lazer = pacienteModel.Lazer,
                Espiritualidade = pacienteModel.Espiritualidade,
                Queixas = pacienteModel.Queixas,
                Objetivos = pacienteModel.Objetivos,
                Expectativas = pacienteModel.Expectativas,
                Diagnostico = pacienteModel.Diagnostico,
                Prognostico = pacienteModel.Prognostico,
                PlanoTerapeutico = pacienteModel.PlanoTerapeutico,
                Encaminhamentos = pacienteModel.Encaminhamentos,
                ObservacoesConsulta = pacienteModel.ObservacoesConsulta,
                Status = pacienteModel.Status
            };
            return paciente;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<List<Paciente>> GetPacientesByPsicologoId(Guid psicologoId)
    {
        try
        {
            var pacientes = _context.Pacientes
                .Where(paciente => paciente.PsicologoId == psicologoId)
                .ToList();

            return pacientes;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}