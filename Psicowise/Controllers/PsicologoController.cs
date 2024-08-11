using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Psicowise.Domain.Commands;
using Psicowise.Domain.Handlers;
using Psicowise.Domain.Queries;

namespace Psicowise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PsicologoController : ControllerBase
    {
        private readonly PsicologoHandler _psicologoHandler;

        public PsicologoController(
            PsicologoHandler psicologoHandler
        )
        {
            _psicologoHandler = psicologoHandler;
        }
        
        [Route("createPsicologo")]
        [HttpPost]
        public async Task<IActionResult> CreatePsicologo([FromBody] CreatePsicologoCommand command)
        {
            var psicologo = await _psicologoHandler.Handle(command);
            return Ok(psicologo);
        }
        
        [Route("updatePsicologo")]
        [HttpPut]
        public async Task<IActionResult> UpdatePsicologo([FromBody] UpdatePsicologoCommand command)
        {
            var psicologo = await _psicologoHandler.Handle(command);
            return Ok(psicologo);
        }
        
        [Route("removePsicologo")]
        [HttpDelete]
        public async Task<IActionResult> RemovePsicologo([FromBody] RemovePsicologoCommand command)
        {
            var psicologo = await _psicologoHandler.Handle(command);
            return Ok(psicologo);
        }
        
        [Route("getPsicologoById")]
        [HttpGet]
        public async Task<IActionResult> GetPsycologoById([FromBody] Guid id)
        {
            var psicologo = await GetPsycologoById(id);
            return Ok(psicologo);
        }
        
        [Route("getPacienteById")]
        [HttpGet]
        public async Task<IActionResult> GetPacienteById([FromBody] Guid id)
        {
            var paciente = await GetPacienteById(id);
            return Ok(paciente);
        }
        
        [Route("getListaPacienteById")]
        [HttpGet]
        public async Task<IActionResult> GetListaPacienteById([FromBody] Guid id)
        {
            var listaPaciente = await GetListaPacienteById(id);
            return Ok(listaPaciente);
        }
    }
}