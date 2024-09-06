using Psicowise.Domain.Commands.MensagensCommand;
using Psicowise.Domain.Entities;

namespace Psicowise.Domain.Repositories;

public interface IMensagemRepository
{
    Task<Mensagem> Create(CreateMensagemCommand consulta);
    Task<Mensagem> Update(UpdateMensagemCommand consulta);
    Task Remove(RemoveMensagemCommand? consulta);
}