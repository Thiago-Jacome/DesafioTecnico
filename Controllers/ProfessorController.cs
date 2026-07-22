using DesafioTecnico.DTOs.Request;
using DesafioTecnico.DTOs.Responses;
using DesafioTecnico.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController(IProfessorService professorService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<RetornoProfessorDto>>> ConsultarProfessores()
        {
            var professores = await professorService.BuscarProfessoresAsync();
            return Ok(professores);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RetornoProfessorDto>> ConsultarProfessorPorId(int id)
        {
            var professor = await professorService.BuscarProfessorPorIdAsync(id);
            if (professor == null)
            {
                return NotFound($"Professor com ID {id} não foi encontrado.");
            }
            return Ok(professor);
        }

        [HttpPost]
        public async Task<ActionResult<RetornoProfessorDto>> CriarProfessor([FromBody] CriarProfessorDto dto)
        {
            try
            {
                var professorCriado = await professorService.CriarProfessorAsync(dto);
                return CreatedAtAction(nameof(ConsultarProfessorPorId), new { id = professorCriado.Id }, professorCriado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletarProfessor(int id)
        {
            bool deletado = await professorService.DeletarProfessorAsync(id);
            if (!deletado)
            {
                return NotFound($"Professor com ID {id} não foi encontrado.");
            }
            return NoContent();
        }
    }
}
