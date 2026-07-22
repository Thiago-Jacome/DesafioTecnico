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
    }
}
