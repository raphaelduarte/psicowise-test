using Psicowise.Domain.Commands.WhatsappInstanceCommand;
using Psicowise.Domain.Entities;

namespace Psicowise.Domain.Repositories;

public interface IWhatsappInstanceRepository
{
    Task<WhatsappInstance> Create(WhatsappInstance wpInstance);
    Task<WhatsappInstance> Update(UpdateWhatsappInstanceCommand command);
    Task Remove(RemoveWhatsappInstanceCommand? command);
}