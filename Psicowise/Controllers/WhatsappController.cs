using Microsoft.AspNetCore.Mvc;
using Psicowise.Domain.Commands.WhatsappInstanceCommand;
using Psicowise.Domain.Handlers;

namespace Psicowise.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Whatsapp : ControllerBase
{
    private readonly WhatsappHandler _whatsappHandler;

    public Whatsapp(WhatsappHandler whatsappHandler)
    {
        _whatsappHandler = whatsappHandler;
    }

    [Route("createWhatsappInstance")]
    [HttpPost]
    public async Task<IActionResult> CreateWhatsappInstance(
        [FromBody] CreateWhatsappInstanceCommand command
        )
    {
        var whatsappInstance = await _whatsappHandler.Handle(command);
        return Ok(whatsappInstance);
    }
}