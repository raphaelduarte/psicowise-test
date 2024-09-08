using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Psicowise.Domain.Entities;

public class WhatsappInstance : Entity 
{
    [ForeignKey("PsicologoId")]
    public Guid PsicologoId { get; set; }

    public string NomeDaInstancia { get; set; }
    public string Token { get; set; }
    public bool QrCode { get; set; }
    public string NumeroDoWhatsappEscaneado { get; set; }

    //Propriedades de navegação
    public Psicologo Psicologo { get; set; }
}