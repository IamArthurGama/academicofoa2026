using Microsoft.AspNetCore.Mvc;

namespace academico.Controllers
{
    public class ExemploController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
