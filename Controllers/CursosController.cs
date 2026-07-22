using DesafioTecnico.DTOs.Request;
using DesafioTecnico.DTOs.Responses;
using DesafioTecnico.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnico.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursosController(ICursoService cursoService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<RetornoCursosDto>>> ConsultarCursos()
        {
            var cursos = await cursoService.BuscarCursosAsync();
            return Ok(cursos);
        }
    
        [HttpPost]
        public async Task<ActionResult<RetornoCursosDto>> CriarCurso([FromBody] CriarCursoDto dto)
        {
            try
            {
                var novoCurso = await cursoService.CriarCursoAsync(dto);
                // Retorna HTTP Status 201 (Created)
                return CreatedAtAction(nameof(ConsultarCursos), new { id = novoCurso.Id }, novoCurso);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // 3. (Excluir Curso)
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletarCurso(int id)
        {
            bool deletado = await cursoService.DeletarCursoAsync(id);

            if (!deletado)
            {
                // Retorna HTTP Status 404 se o ID não existir no banco
                return NotFound($"Curso com ID {id} não foi encontrado.");
            }
            // Retorna HTTP Status 204 (No Content - Sucesso sem corpo na resposta)
            return NoContent();
        }
    }
}
