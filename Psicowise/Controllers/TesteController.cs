using Microsoft.AspNetCore.Mvc;
using Psicowise.Domain.Handlers;
using Psicowise.Domain.Queries.Contracts;

namespace Psicowise.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TesteController : ControllerBase
{
    private readonly PsicologoHandler _psicologoHandler;
    private readonly IPsicologoQuery _psicologoQuery;
    private readonly ITesteQuery _testeQuery;

    public TesteController(
        PsicologoHandler psicologoHandler,
        IPsicologoQuery psicologoQuery,
        ITesteQuery testeQuery
        )
    {
        _psicologoHandler = psicologoHandler;
        _psicologoQuery = psicologoQuery;
        _testeQuery = testeQuery;
    }
    // GET

    [Route("getAllPsicologos")]
    [HttpGet]
    public async Task<IActionResult> GetAllPsicologos()
    {
        var psicologos = await _testeQuery.GetAllPsicologos();
        return Ok(psicologos);
    }
}