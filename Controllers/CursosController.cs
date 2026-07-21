using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnico.Controllers
{
    [ApiController]
    [Route("api/cursos")]
    public class CursosController : ControllerBase
    {
        [HttpPost("Cursos")]
        public IActionResult ConsultarCursos() => StatusCode(StatusCodes.Status501NotImplemented, "Endpoint em desenvolvimento.");
    }
}
