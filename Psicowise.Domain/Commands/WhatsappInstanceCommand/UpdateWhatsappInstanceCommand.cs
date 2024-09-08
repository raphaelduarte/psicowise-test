using Psicowise.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Psicowise.Domain.Commands.WhatsappInstanceCommand;

public class UpdateWhatsappInstanceCommand
{
    public Guid Id { get; set; }
    public Guid PsicologoId { get; set; }

    public string NomeDaInstancia { get; set; }
    public string Token { get; set; }
    public bool QrCode { get; set; }
    public string NumeroDoWhatsappEscaneado { get; set; }
}