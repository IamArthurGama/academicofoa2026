using Microsoft.AspNetCore.Mvc;
using academico.Models;
using academico.Repositories;
using System.Threading.Tasks;

namespace academico.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunoController(IAlunoRepository repository)
        {
            _alunoRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        private static List<Aluno> alunos = new List<Aluno>()
        {
            new Aluno
            {
                AlunoId = 1,
                Nome = "Aluno Teste",
                Email = "aluno@mail.com",
                Telefone = "(99) 99999-9999",
                Endereco = "Rua Teste, Numero 123",
                Complemento = "Casa",
                Bairro = "Centro",
                Municipio = "Cidade Teste",
                Uf = "ST",
                Cep = "99999-999"
            }
        };


        public async Task<IActionResult> Create()
        {
            return View(new Aluno());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return View(aluno);
            }
            await _alunoRepository.Create(aluno);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Index()
        {
            var alunos = await _alunoRepository.GetAll();
            return View(alunos);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var aluno = await _alunoRepository.GetById(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Aluno aluno)
        {
            if (id != aluno.AlunoId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(aluno);
            }

            await _alunoRepository.Edit(aluno);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int id)
        {
            var aluno = await _alunoRepository.GetById(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var aluno = await _alunoRepository.GetById(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           await _alunoRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    };
}
