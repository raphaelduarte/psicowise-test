using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Psicowise.Domain.Commands.AgendaCommand;
using Psicowise.Domain.Handlers;

namespace Psicowise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly AgendaHandler _agendaHandler;

        public AgendaController(
            AgendaHandler agendaHandler
            )
        {
            _agendaHandler = agendaHandler;
        }
        
        [Route("createAgenda")]
        [HttpPost]
        public async Task<IActionResult> CreateAgenda([FromBody] CreateAgendaCommand command)
        {
            var agenda = await _agendaHandler.Handle(command);
            return Ok(agenda);
        }
        
        [Route("updateAgenda")]
        [HttpPut]
        public async Task<IActionResult> UpdateAgenda([FromBody] UpdateAgendaCommand command)
        {
            var agenda = await _agendaHandler.Handle(command);
            return Ok(agenda);
        }
        
        [Route("removeAgenda")]
        [HttpDelete]
        public async Task<IActionResult> RemoveAgenda([FromBody] RemoveAgendaCommand command)
        {
            var agenda = await _agendaHandler.Handle(command);
            return Ok(agenda);
        }
    }
}
