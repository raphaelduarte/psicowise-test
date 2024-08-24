using Microsoft.AspNetCore.Mvc;
using Psicowise.Domain.Commands;
using Psicowise.Domain.Commands.ConsultaCommand;
using Psicowise.Domain.Dtos;
using Psicowise.Domain.Entities;
using Psicowise.Domain.Handlers;
using Psicowise.Domain.Queries.Contracts;

namespace Psicowise.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConsultaController : ControllerBase
{
    private readonly ConsultaHandler _consultaHandler;
    private readonly IConsultaQuery _consultaQuery;
    
    public ConsultaController(
        ConsultaHandler consultaHandler,
        IConsultaQuery consultaQuery
        )
    {
        _consultaHandler = consultaHandler;
        _consultaQuery = consultaQuery;
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

    [Route("getAllConsultasDoPsicologo")]
    [HttpGet]
    public async Task<IActionResult> GetAllConsultasDoPsicologo(
        [FromHeader]
        Guid psicologoId
    )

    {
        var listaConsultasDoPsicologo = await _consultaQuery.GetAllConsultasDoPsicologo(psicologoId);

        return Ok(listaConsultasDoPsicologo);
    }
}