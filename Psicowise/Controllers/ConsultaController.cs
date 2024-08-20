using Microsoft.AspNetCore.Mvc;
using Psicowise.Domain.Commands;
using Psicowise.Domain.Commands.ConsultaCommand;
using Psicowise.Domain.Handlers;

namespace Psicowise.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsultaController : ControllerBase
{
    private readonly ConsultaHandler _consultaHandler;
    
    public ConsultaController(ConsultaHandler consultaHandler)
    {
        _consultaHandler = consultaHandler;
    }
    
    [Route("createConsulta")]
    [HttpPost]
    public async Task<IActionResult> CreateConsulta([FromBody] CreateConsultaCommand command)
    {
        var consulta = await _consultaHandler.Handle(command);
        return Ok(consulta);
    }
        
    [Route("updateConsulta")]
    [HttpPut]
    public async Task<IActionResult> UpdateAgenda([FromBody] UpdateConsultaCommand command)
    {
        var consulta = await _consultaHandler.Handle(command);
        return Ok(consulta);
    }
        
    [Route("removeConsulta")]
    [HttpDelete]
    public async Task<IActionResult> RemoveAgenda([FromHeader] Guid id)
    {
        var command = new RemoveConsultaCommand(id);
        var consulta = await _consultaHandler.Handle(command);
        return Ok(consulta);
    }
}