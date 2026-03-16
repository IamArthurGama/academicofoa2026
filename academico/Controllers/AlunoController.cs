using Microsoft.AspNetCore.Mvc;
using academico.Models;

namespace academico.Controllers
{
    public class AlunoController : Controller
    {
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


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Aluno aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    aluno.AlunoId = alunos.Select(a => a.AlunoId).DefaultIfEmpty(0).Max() + 1;
                    alunos.Add(aluno);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ocorreu um erro ao criar o aluno: {ex.Message}");
            }
            return View(aluno);
        }


        public IActionResult Index()
        {
            return View(alunos);
        }

        public IActionResult Edit(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.AlunoId == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("AlunoId,Nome,Email,Telefone,Endereco,Complemento,Bairro,Municipio,Uf,Cep")] Aluno aluno)
        {
            try
            {
                if (id != aluno.AlunoId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    var alunoExistente = alunos.FirstOrDefault(a => a.AlunoId == id);
                    if (alunoExistente == null)
                    {
                        return NotFound();
                    }
                    alunoExistente.Nome = aluno.Nome;
                    alunoExistente.Email = aluno.Email;
                    alunoExistente.Telefone = aluno.Telefone;
                    alunoExistente.Endereco = aluno.Endereco;
                    alunoExistente.Complemento = aluno.Complemento;
                    alunoExistente.Bairro = aluno.Bairro;
                    alunoExistente.Municipio = aluno.Municipio;
                    alunoExistente.Uf = aluno.Uf;
                    alunoExistente.Cep = aluno.Cep;
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Ocorreu um erro ao editar o aluno: {ex.Message}");
            }
            return View(aluno);

        }


        public IActionResult Details(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.AlunoId == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        public IActionResult Delete(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.AlunoId == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var aluno = alunos.FirstOrDefault(a => a.AlunoId == id);
                if (aluno == null)
                {
                    return NotFound();
                }
                alunos.Remove(aluno);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Nâo foi possível excluir o aluno: {ex.Message}");
            }
            return View(alunos);
        }
    };
}
