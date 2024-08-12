using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Psicowise.Domain.ObjetosDeValor;

namespace Psicowise.Domain.Entities
{
    public class Paciente : Entity
    {
        public Paciente()
        {
            Nome = new NomeCompleto("", "");
            Email = string.Empty;
            Telefone = string.Empty;
            Endereco = new Endereco("", "", "", "", "", "", "");
        }

        public Paciente(
            NomeCompleto nome,
            string email,
            string telefone,
            Endereco endereco,
            DateTime dataNascimento,
            Guid psicologoId
        )
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            DataNascimento = dataNascimento;
            PsicologoId = psicologoId;
        }

        public Paciente(
            NomeCompleto nome,
            string email,
            string telefone,
            Endereco endereco,
            DateTime dataNascimento,
            Guid psicologoId,
            string? cpf,
            string? rg,
            string? sexo,
            string? estadoCivil,
            string? profissao,
            string? escolaridade,
            string? religiao,
            string? nomePai,
            string? nomeMae,
            string? convenio,
            string? plano,
            string? numeroCarteirinha,
            string? validadeCarteirinha,
            string? observacoes,
            string? motivoConsulta,
            string? historicoFamiliar,
            string? historicoPessoal,
            string? historicoProfissional,
            string? historicoMedico,
            string? medicamentos,
            string? alergias,
            string? cirurgias,
            string? internacoes,
            string? tabagismo,
            string? alcoolismo,
            string? drogas,
            string? atividadeFisica,
            string? alimentacao,
            string? sono,
            string? relacionamentos,
            string? sexualidade,
            string? lazer,
            string? espiritualidade,
            string? queixas,
            string? objetivos,
            string? expectativas,
            string? diagnostico,
            string? prognostico,
            string? planoTerapeutico,
            string? encaminhamentos,
            string? observacoesConsulta,
            bool status
            )
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            DataNascimento = dataNascimento;
            PsicologoId = psicologoId;
            Cpf = cpf;
            Rg = rg;
            Sexo = sexo;
            EstadoCivil = estadoCivil;
            Profissao = profissao;
            Escolaridade = escolaridade;
            Religiao = religiao;
            NomePai = nomePai;
            NomeMae = nomeMae;
            Convenio = convenio;
            Plano = plano;
            NumeroCarteirinha = numeroCarteirinha;
            ValidadeCarteirinha = validadeCarteirinha;
            Observacoes = observacoes;
            MotivoConsulta = motivoConsulta;
            HistoricoFamiliar = historicoFamiliar;
            HistoricoPessoal = historicoPessoal;
            HistoricoProfissional = historicoProfissional;
            HistoricoMedico = historicoMedico;
            Medicamentos = medicamentos;
            Alergias = alergias;
            Cirurgias = cirurgias;
            Internacoes = internacoes;
            Tabagismo = tabagismo;
            Alcoolismo = alcoolismo;
            Drogas = drogas;
            AtividadeFisica = atividadeFisica;
            Alimentacao = alimentacao;
            Sono = sono;
            Relacionamentos = relacionamentos;
            Sexualidade = sexualidade;
            Lazer = lazer;
            Espiritualidade = espiritualidade;
            Queixas = queixas;
            Objetivos = objetivos;
            Expectativas = expectativas;
            Diagnostico = diagnostico;
            Prognostico = prognostico;
            PlanoTerapeutico = planoTerapeutico;
            Encaminhamentos = encaminhamentos;
            ObservacoesConsulta = observacoesConsulta;
            Status = status;

        }

        public Guid PacienteId { get;  set; }
        public NomeCompleto Nome  { get;  set; }
        public Guid PsicologoId { get;  set; }
        public ICollection<Consulta> Consultas { get;  set; }
        public string Email { get;  set; }
        public string Telefone { get;  set; }
        public Endereco Endereco { get;  set; }
        public DateTime DataNascimento { get;  set; }
        public string? Cpf { get;  set; }
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
    }
}