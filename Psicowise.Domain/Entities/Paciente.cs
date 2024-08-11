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
            Guid idPsicologo
        )
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
            DataNascimento = dataNascimento;
            IdPsicologo = idPsicologo;
        }

        public Paciente(
            NomeCompleto nome,
            string email,
            string telefone,
            Endereco endereco,
            DateTime dataNascimento,
            Guid idPsicologo,
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
            IdPsicologo = idPsicologo;
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

        public NomeCompleto Nome  { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public Endereco Endereco { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Guid IdPsicologo { get; private set; }
        public string? Cpf { get; private set; }
        public string? Rg { get; private set; }
        public string? Sexo { get; private set; }
        public string? EstadoCivil { get; private set; }
        public string? Profissao { get; private set; }
        public string? Escolaridade { get; private set; }
        public string? Religiao { get; private set; }
        public string? NomePai { get; private set; }
        public string? NomeMae { get; private set; }
        public string? Convenio { get; private set; }
        public string? Plano { get; private set; }
        public string? NumeroCarteirinha { get; private set; }
        public string? ValidadeCarteirinha { get; private set; }
        public string? Observacoes { get; private set; }
        public string? MotivoConsulta { get; private set; }
        public string? HistoricoFamiliar { get; private set; }
        public string? HistoricoPessoal { get; private set; }
        public string? HistoricoProfissional { get; private set; }
        public string? HistoricoMedico { get; private set; }
        public string? Medicamentos { get; private set; }
        public string? Alergias { get; private set; }
        public string? Cirurgias { get; private set; }
        public string? Internacoes { get; private set; }
        public string? Tabagismo { get; private set; }
        public string? Alcoolismo { get; private set; }
        public string? Drogas { get; private set; }
        public string? AtividadeFisica { get; private set; }
        public string? Alimentacao { get; private set; }
        public string? Sono { get; private set; }
        public string? Relacionamentos { get; private set; }
        public string? Sexualidade { get; private set; }
        public string? Lazer { get; private set; }
        public string? Espiritualidade { get; private set; }
        public string? Queixas { get; private set; }
        public string? Objetivos { get; private set; }
        public string? Expectativas { get; private set; }
        public string? Diagnostico { get; private set; }
        public string? Prognostico { get; private set; }
        public string? PlanoTerapeutico { get; private set; }
        public string? Encaminhamentos { get; private set; }
        public string? ObservacoesConsulta { get; private set; }
        public bool Status { get; private set; } = true;
    }
}