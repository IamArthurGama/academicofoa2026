using Microsoft.AspNetCore.Mvc;
using academico.Models;
using academico.Repositories;
using System.Threading.Tasks;
using academico.Data;
using Microsoft.EntityFrameworkCore;

namespace academico.Controllers
{
    public class AlunoController : Controller
    {
        private readonly AcademicoContext _context;
        public AlunoController(AcademicoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Alunos.OrderBy(a => a.Nome).ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Nome", "Email", "Telefone", "Endereco", "Complemento", "Bairro", "Municipio", "Uf", "Cep")] Aluno aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(aluno);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex) {
                ModelState.AddModelError("", "Não foi possivel inserir os dados.");
            }

            return View(aluno);
        }


        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlunoId", "Nome", "Email", "Telefone", "Endereco", "Complemento", "Bairro", "Municipio", "Uf", "Cep")] Aluno aluno)
        {
            if (id != aluno.AlunoId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.AlunoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        public bool AlunoExists(int id)
        {
            return _context.Alunos.Any(e => e.AlunoId == id);
        }


        public async Task<IActionResult> Details(int id)
        {
            var aluno = await _context.Alunos.SingleOrDefaultAsync(a => a.AlunoId == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var aluno = await _context.Alunos.SingleOrDefaultAsync(a => a.AlunoId == id);
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
            var aluno = await _context.Alunos.FindAsync(id);
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    };
}
