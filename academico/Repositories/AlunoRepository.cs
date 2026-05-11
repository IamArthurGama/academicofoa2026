using academico.Data;
using academico.Models;
using Microsoft.EntityFrameworkCore;

namespace academico.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AcademicoContext _context;

        public AlunoRepository(AcademicoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Aluno>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Alunos
                .AsNoTracking()
                .OrderBy(aluno => aluno.Nome)
                .ToListAsync(cancellationToken);
        }

        public async Task<Aluno?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Alunos.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task CreateAsync(Aluno aluno, CancellationToken cancellationToken = default)
        {
            await _context.Alunos.AddAsync(aluno, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task EditAsync(Aluno aluno, CancellationToken cancellationToken = default)
        {
            _context.Alunos.Update(aluno);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var aluno = await GetByIdAsync(id, cancellationToken);

            if (aluno == null)
            {
                return;
            }

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Alunos.AnyAsync(aluno => aluno.AlunoId == id, cancellationToken);
        }
    }
}
