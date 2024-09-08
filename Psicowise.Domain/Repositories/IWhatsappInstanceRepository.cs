using Psicowise.Domain.Commands.MensagensCommand;
using Psicowise.Domain.Commands.WhatsappInstanceCommand;
using Psicowise.Domain.Entities;

namespace Psicowise.Domain.Repositories;

public interface IWhatsappInstanceRepository
{
    Task<WhatsappInstance> Create(CreateWhatsappInstanceCommand command);
    Task<WhatsappInstance> Update(UpdateWhatsappInstanceCommand command);
    Task Remove(RemoveWhatsappInstanceCommand? command);
}