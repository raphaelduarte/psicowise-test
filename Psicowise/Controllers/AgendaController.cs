using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Psicowise.Domain.Commands;
using Psicowise.Domain.Commands.AgendaCommand;
using Psicowise.Domain.Handlers;
using Psicowise.Domain.Queries.Contracts;

namespace Psicowise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly AgendaHandler _agendaHandler;
        private readonly IAgendaQuery _agendaQuery;

        public AgendaController(
            AgendaHandler agendaHandler,
            IAgendaQuery agendaQuery
            )
        {
            _agendaHandler = agendaHandler;
            _agendaQuery = agendaQuery;
        }
        
        [Route("createAgenda")]
        [HttpPost]
        public async Task<IActionResult> CreateAgenda(
            [FromBody] CreateAgendaCommand command
            )
        {
            var agenda = await _agendaHandler.Handle(command);
            return Ok(agenda);
        }
        
        [Route("updateAgenda")]
        [HttpPut]
        public async Task<IActionResult> UpdateAgenda(
            [FromBody] UpdateAgendaCommand command
            )
        {
            var agenda = await _agendaHandler.Handle(command);
            return Ok(agenda);
        }
        
        [Route("removeAgenda")]
        [HttpDelete]
        public async Task<IActionResult> RemoveAgenda(
            [FromHeader] Guid id
            )
        {
            var command = new RemoveAgendaCommand(id);
            var agenda = await _agendaHandler.Handle(command);
            return Ok(agenda);
        }

        [Route("verificarDisponibilidadeDeHorarioNaAgenda")]
        [HttpGet]
        public async Task<IActionResult> DisponibilidadeNaAgenda(
            [FromHeader] 
            Guid psicologoId, 
            DateTime horaEDiaDisponivel
        )

        {
            var disponivel = _agendaQuery.VerificarDisponibilidade(psicologoId, horaEDiaDisponivel);
            return Ok(disponivel);
        }
    }
}
