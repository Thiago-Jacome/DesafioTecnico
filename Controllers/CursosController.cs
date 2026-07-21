using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnico.Controllers
{
    public class CursosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
