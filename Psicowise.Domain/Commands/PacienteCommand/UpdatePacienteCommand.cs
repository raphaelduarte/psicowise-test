using Psicowise.Domain.ObjetosDeValor;
using Psicowise.Domain.Entities;

namespace Psicowise.Domain.Commands;

public class UpdatePacienteCommand
{
    public UpdatePacienteCommand(
        Endereco? endereco,
        Telefone? telefone,
        Guid id
    )
    {
        Endereco = endereco;
        Telefone = telefone;
        UpdatedAt = DateTime.Now.ToUniversalTime();
    }
    public Guid Id { get; set; } 
    public Endereco? Endereco { get; set; }
    public Telefone? Telefone { get; set; }
    public string? Email { get;  set; }
    public DateTime DataNascimento { get;  set; }
    public string? Rg { get;  set; }
    public string? Sexo { get;  set; }
    public string? EstadoCivil { get;  set; }
    public string? Profissao { get;  set; }
    public string? Escolaridade { get;  set; }
    public string? Religiao { get;  set; }
    public string? NomePai { get;  set; }
    public string? NomeMae { get;  set; }
    public string? Convenio { get;  set; }
    public string? Plano { get;  set; }
    public string? NumeroCarteirinha { get;  set; }
    public string? ValidadeCarteirinha { get;  set; }
    public string? Observacoes { get;  set; }
    public string? MotivoConsulta { get;  set; }
    public string? HistoricoFamiliar { get;  set; }
    public string? HistoricoPessoal { get;  set; }
    public string? HistoricoProfissional { get;  set; }
    public string? HistoricoMedico { get;  set; }
    public string? Medicamentos { get;  set; }
    public string? Alergias { get;  set; }
    public string? Cirurgias { get;  set; }
    public string? Internacoes { get;  set; }
    public string? Tabagismo { get;  set; }
    public string? Alcoolismo { get;  set; }
    public string? Drogas { get;  set; }
    public string? AtividadeFisica { get;  set; }
    public string? Alimentacao { get;  set; }
    public string? Sono { get;  set; }
    public string? Relacionamentos { get;  set; }
    public string? Sexualidade { get;  set; }
    public string? Lazer { get;  set; }
    public string? Espiritualidade { get;  set; }
    public string? Queixas { get;  set; }
    public string? Objetivos { get;  set; }
    public string? Expectativas { get;  set; }
    public string? Diagnostico { get;  set; }
    public string? Prognostico { get;  set; }
    public string? PlanoTerapeutico { get;  set; }
    public string? Encaminhamentos { get;  set; }
    public string? ObservacoesConsulta { get;  set; }
    public bool Status { get;  set; } = true;
    public string? Cpf { get;  set; }
    public DateTime UpdatedAt { get; set; } = DateTime.Now.ToUniversalTime();
}