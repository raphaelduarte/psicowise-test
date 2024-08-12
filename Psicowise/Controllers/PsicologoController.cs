using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Psicowise.Domain.Commands;
using Psicowise.Domain.Commands;
using Psicowise.Domain.Handlers;
using Psicowise.Domain.Queries;
using Psicowise.Domain.Queries.Contracts;

namespace Psicowise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PsicologoController : ControllerBase
    {
        private readonly PsicologoHandler _psicologoHandler;
        private readonly IPsicologoQuery _psicologoQuery;
        private readonly IPacienteQuery _pacienteQuery;
        private readonly PacienteHandler _pacienteHandler;

        public PsicologoController(
            PsicologoHandler psicologoHandler,
            IPsicologoQuery psicologoQuery,
            IPacienteQuery pacienteQuery,
            PacienteHandler pacienteHandler
        )
        {
            _psicologoHandler = psicologoHandler;
            _psicologoQuery = psicologoQuery;
            _pacienteQuery = pacienteQuery;
            _pacienteHandler = pacienteHandler;
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
        public async Task<IActionResult> GetPsycologoById([FromHeader] Guid id)
        {
            var psicologo = await _psicologoQuery.GetPsicologoById(id);
            return Ok(psicologo);
        }
        
        [Route("getPacienteById")]
        [HttpGet]
        public async Task<IActionResult> GetPacienteById([FromHeader] Guid id)
        {
            var paciente = await _pacienteQuery.GetPacienteById(id);
            return Ok(paciente);
        }
        
        [Route("getListaPaciente")]
        [HttpGet]
        public async Task<IActionResult> GetListaPaciente([FromHeader] Guid id)
        {
            var listaPaciente = await _pacienteQuery.GetPacientesByPsicologoId(id);
            return Ok(listaPaciente);
        }
        
        [Route("createPaciente")]
        [HttpPost]
        public async Task<IActionResult> CreatePaciente([FromBody] CreatePacienteCommand command)
        {
            var paciente = await _pacienteHandler.Handle(command);
            return Ok(paciente);
        }
        
        [Route("removePaciente")]
        [HttpDelete]
        public async Task<IActionResult> RemovePaciente([FromBody] RemovePacienteCommand command)
        {
            var paciente = await _pacienteHandler.Handle(command);
            return Ok(paciente);
        }
    }
}