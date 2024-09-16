using Psicowise.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Psicowise.Domain.Commands.WhatsappInstanceCommand;

public class CreateWhatsappInstanceCommand
{
    public Guid PsicologoId { get; set; }
    public string NomeDaInstancia { get; set; }
}