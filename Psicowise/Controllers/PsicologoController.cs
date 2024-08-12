using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public PsicologoController(
            PsicologoHandler psicologoHandler,
            IPsicologoQuery psicologoQuery
        )
        {
            _psicologoHandler = psicologoHandler;
            _psicologoQuery = psicologoQuery;
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
            var paciente = await GetPacienteById(id);
            return Ok(paciente);
        }
        
        [Route("getListaPacienteById")]
        [HttpGet]
        public async Task<IActionResult> GetListaPacienteById([FromHeader] Guid id)
        {
            var listaPaciente = await GetListaPacienteById(id);
            return Ok(listaPaciente);
        }
    }
}