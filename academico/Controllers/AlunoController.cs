using Microsoft.AspNetCore.Mvc;
using academico.Models;

namespace academico.Controllers
{
    public class AlunoController : Controller
    {
        private static List<Aluno> alunos = new List<Aluno>();
        private static List<Aluno> alunos2 = new List<Aluno>();
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
