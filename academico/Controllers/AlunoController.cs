using Microsoft.AspNetCore.Mvc;
using academico.Models;
using academico.Repositories;
using Microsoft.EntityFrameworkCore;

namespace academico.Controllers
{
    public class AlunoController : Controller
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var alunos = await _alunoRepository.GetAllAsync(cancellationToken);
            return View(alunos);
        }

        public IActionResult Create()
        {
            return View(new Aluno());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Email,Telefone,Endereco,Complemento,Bairro,Municipio,Uf,Cep")] Aluno aluno, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return View(aluno);
            }

            try
            {
                await _alunoRepository.CreateAsync(aluno, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError(string.Empty, "Não foi possível inserir os dados.");
            }

            return View(aluno);
        }

        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var aluno = await _alunoRepository.GetByIdAsync(id, cancellationToken);

            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlunoId,Nome,Email,Telefone,Endereco,Complemento,Bairro,Municipio,Uf,Cep")] Aluno aluno, CancellationToken cancellationToken)
        {
            if (id != aluno.AlunoId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(aluno);
            }

            try
            {
                await _alunoRepository.EditAsync(aluno, cancellationToken);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _alunoRepository.ExistsAsync(aluno.AlunoId, cancellationToken))
                {
                    return NotFound();
                }

                throw;
            }
        }

        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var aluno = await _alunoRepository.GetByIdAsync(id, cancellationToken);

            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var aluno = await _alunoRepository.GetByIdAsync(id, cancellationToken);

            if (aluno == null)
            {
                return NotFound();
            }

            return View(aluno);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, CancellationToken cancellationToken)
        {
            if (!await _alunoRepository.ExistsAsync(id, cancellationToken))
            {
                return NotFound();
            }

            await _alunoRepository.DeleteAsync(id, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }
}
