using Microsoft.AspNetCore.Mvc;

namespace DesafioTecnico.Controllers
{
    public class ProfessorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
