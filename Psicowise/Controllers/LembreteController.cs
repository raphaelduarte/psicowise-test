using Microsoft.AspNetCore.Mvc;
using Psicowise.Domain.Commands.LembretesCommand;
using Psicowise.Domain.Handlers;
using Psicowise.Domain.Queries.Contracts;

namespace Psicowise.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LembreteController : ControllerBase
{
    private readonly ILembreteQuery _lembreteQuery;
    private readonly LembreteHandler _lembreteHandler;

    public LembreteController(
        ILembreteQuery lembreteQuery,
        LembreteHandler lembreteHandler
        )
    {
        _lembreteQuery = lembreteQuery;
        _lembreteHandler = lembreteHandler;
    }

    [Route("createLembrete")]
    [HttpPost]
    public async Task<IActionResult> CreateLembrete(
        [FromBody] CreateLembreteCommand command
        )
    {
        var lembrete = await _lembreteHandler.Handle(command);
        return Ok(lembrete);
    }
}