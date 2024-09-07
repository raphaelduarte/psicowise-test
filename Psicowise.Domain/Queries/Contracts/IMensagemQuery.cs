using Psicowise.Domain.Entities;

namespace Psicowise.Domain.Queries.Contracts;

public interface IMensagemQuery
{
    Task<Mensagem> GetMensagemById(Guid mensagemId);
}