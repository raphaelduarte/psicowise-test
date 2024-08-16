using Psicowise.Domain.Commands;
using Psicowise.Domain.Commands.Interfaces;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Handlers.Interfaces;
using Psicowise.Domain.Queries.Contracts;
using Psicowise.Domain.Repositories;

namespace Psicowise.Domain.Handlers;

public class PacienteHandler : 
    IHandler<CreatePacienteCommand>, 
    IHandler<RemovePacienteCommand>,
    IHandler<UpdatePacienteCommand>
{
    private readonly IPacienteRepository _pacienteRepository;
    private readonly IPacienteQuery _pacienteQuery;

    public PacienteHandler(
        IPacienteRepository pacienteRepository,
        IPacienteQuery pacienteQuery
        )
    {
        _pacienteRepository = pacienteRepository;
        _pacienteQuery = pacienteQuery;
    }
    
    //TODO: Implementar CreatePaciente e consertar o CreatedAt
    public async Task<ICommandResult> Handle(CreatePacienteCommand command)
    {
        var paciente = new Paciente(
            command.PsicologoId,
            command.Nome,
            command.Email,
            command.Telefone,
            command.Endereco,
            command.DataNascimento
        );
        
        paciente.CreatedAt = command.CreatedAt;
        
        await _pacienteRepository.Create(paciente);
        return new GenericCommandResult(true, "Paciente criado com sucesso", paciente);
    }

    public async Task<ICommandResult> Handle(RemovePacienteCommand command)
    {
        var paciente = _pacienteQuery.GetPacienteById(command.PacienteId).Result;
        if (paciente == null)
        {
            return new GenericCommandResult(false, "Paciente não encontrado", default);
        }
        
        await  _pacienteRepository.Remove(paciente);
        return new GenericCommandResult(true, "Paciente removido com sucesso", default);
    }
    
    public async Task<ICommandResult> Handle(UpdatePacienteCommand command)
    {
        var paciente = await _pacienteQuery.GetPacienteById(command.Id);
        paciente.UpdatedAt = DateTime.Now.ToUniversalTime();
        
        if (paciente == null)
        {
            return new GenericCommandResult(false, "Paciente não encontrado", default);
        }

        if (command.Endereco != null)
        {
            if (command.Endereco.Logradouro != null)
            {
                paciente.Endereco.Logradouro = command.Endereco.Logradouro;
            }
        
            if (command.Endereco.Numero != null)
            {
                paciente.Endereco.Numero = command.Endereco.Numero;
            }
        
            if (command.Endereco.Bairro != null)
            {
                paciente.Endereco.Bairro = command.Endereco.Bairro;
            }
        
            if (command.Endereco.Cidade != null)
            {
                paciente.Endereco.Cidade = command.Endereco.Cidade;
            }
        
            if (command.Endereco.Estado != null)
            {
                paciente.Endereco.Estado = command.Endereco.Estado;
            }
        
            if (command.Endereco.Cep != null)
            {
                paciente.Endereco.Cep = command.Endereco.Cep;
            }
        }

        if (command.Telefone != null)
        {
            if (command.Telefone.Ddd != null)
            {
                paciente.Telefone.Ddd = command.Telefone.Ddd;
            }
        
            if (command.Telefone.Numero != null)
            {
                paciente.Telefone.Numero = command.Telefone.Numero;
            }
        }
        
        if(command.Email != null)
        {
            paciente.Email = command.Email;
        }
        
        if(command.Alcoolismo != null)
        {
            paciente.Alcoolismo = command.Alcoolismo;
        }
        
        if(command.Alergias != null)
        {
            paciente.Alergias = command.Alergias;
        }
        
        if(command.AtividadeFisica != null)
        {
            paciente.AtividadeFisica = command.AtividadeFisica;
        }
        
        if(command.Cirurgias != null)
        {
            paciente.Cirurgias = command.Cirurgias;
        }
        
        if(command.Convenio != null)
        {
            paciente.Convenio = command.Convenio;
        }
        
        if(command.Diagnostico != null)
        {
            paciente.Diagnostico = command.Diagnostico;
        }
        
        if(command.Drogas != null)
        {
            paciente.Drogas = command.Drogas;
        }
        
        if(command.Escolaridade != null)
        {
            paciente.Escolaridade = command.Escolaridade;
        }
        
        if(command.EstadoCivil != null)
        {
            paciente.EstadoCivil = command.EstadoCivil;
        }
        
        if(command.Expectativas != null)
        {
            paciente.Expectativas = command.Expectativas;
        }
        
        if(command.HistoricoFamiliar != null)
        {
            paciente.HistoricoFamiliar = command.HistoricoFamiliar;
        }
        
        if(command.HistoricoMedico != null)
        {
            paciente.HistoricoMedico = command.HistoricoMedico;
        }
        
        if(command.HistoricoPessoal != null)
        {
            paciente.HistoricoPessoal = command.HistoricoPessoal;
        }
        
        if(command.HistoricoProfissional != null)
        {
            paciente.HistoricoProfissional = command.HistoricoProfissional;
        }
        
        if(command.Internacoes != null)
        {
            paciente.Internacoes = command.Internacoes;
        }
        
        if(command.Lazer != null)
        {
            paciente.Lazer = command.Lazer;
        }
        
        if(command.Medicamentos != null)
        {
            paciente.Medicamentos = command.Medicamentos;
        }
        
        if(command.MotivoConsulta != null)
        {
            paciente.MotivoConsulta = command.MotivoConsulta;
        }
        
        if(command.NomeMae != null)
        {
            paciente.NomeMae = command.NomeMae;
        }
        
        if(command.NomePai != null)
        {
            paciente.NomePai = command.NomePai;
        }
        
        if(command.NumeroCarteirinha != null)
        {
            paciente.NumeroCarteirinha = command.NumeroCarteirinha;
        }
        
        if(command.Objetivos != null)
        {
            paciente.Objetivos = command.Objetivos;
        }
        
        if(command.Observacoes != null)
        {
            paciente.Observacoes = command.Observacoes;
        }
        
        if(command.ObservacoesConsulta != null)
        {
            paciente.ObservacoesConsulta = command.ObservacoesConsulta;
        }
        
        if(command.Plano != null)
        {
            paciente.Plano = command.Plano;
        }
        
        if(command.PlanoTerapeutico != null)
        {
            paciente.PlanoTerapeutico = command.PlanoTerapeutico;
        }
        
        if(command.Profissao != null)
        {
            paciente.Profissao = command.Profissao;
        }
        
        if(command.Prognostico != null)
        {
            paciente.Prognostico = command.Prognostico;
        }
        
        if(command.Queixas != null)
        {
            paciente.Queixas = command.Queixas;
        }
        
        if(command.Relacionamentos != null)
        {
            paciente.Relacionamentos = command.Relacionamentos;
        }
        
        if(command.Religiao != null)
        {
            paciente.Religiao = command.Religiao;
        }
        
        if(command.Sexo != null)
        {
            paciente.Sexo = command.Sexo;
        }
        
        if(command.Sexualidade != null)
        {
            paciente.Sexualidade = command.Sexualidade;
        }
        
        if(command.Sono != null)
        {
            paciente.Sono = command.Sono;
        }
        
        if(command.Tabagismo != null)
        {
            paciente.Tabagismo = command.Tabagismo;
        }
        
        if(command.ValidadeCarteirinha != null)
        {
            paciente.ValidadeCarteirinha = command.ValidadeCarteirinha;
        }
        
        if(command.DataNascimento != null)
        {
            paciente.DataNascimento = command.DataNascimento;
        }
        
        if(command.Rg != null)
        {
            paciente.Rg = command.Rg;
        }
        
        if(command.Alimentacao != null)
        {
            paciente.Alimentacao = command.Alimentacao;
        }
        
        if(command.Espiritualidade != null)
        {
            paciente.Espiritualidade = command.Espiritualidade;
        }
        
        if(command.Encaminhamentos != null)
        {
            paciente.Encaminhamentos = command.Encaminhamentos;
        }
        
        if(command.Cpf != null)
        {
            paciente.Cpf = command.Cpf;
        }
        
        if(command.Status != null)
        {
            paciente.Status = command.Status;
        }

        await _pacienteRepository.Update(paciente);

        return new GenericCommandResult(true, "Psicologo atualizado com sucesso", paciente);
    }
}