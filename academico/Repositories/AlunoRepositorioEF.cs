using academico.Data;
using academico.Models;
using Microsoft.EntityFrameworkCore;

namespace academico.Repositories
{
    public class AlunoRepositorioEF : IAlunoRepository
    {
        private readonly AcademicoContext _context;

        public AlunoRepositorioEF(AcademicoContext context) => _context = context;
        public async Task Create(Aluno aluno, CancellationToken cancellationToken = default)
        {
            _context.Alunos.Add(aluno); 
            _context.SaveChanges();
        }

        public Task Delete(int id, CancellationToken cancellationToken = default)
        {
            var aluno = _context.Alunos.Find(id);

            if (aluno == null)
            {
                throw new Exception();
            }
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
            return Task.CompletedTask;

        }

        public Task Edit(Aluno aluno, CancellationToken cancellationToken = default)
        {
            _context.Alunos.Update(aluno); 
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<bool> Exists(int id, CancellationToken cancellationToken = default)
        {
            var aluno = _context.Alunos.Find(id);
            if (aluno == null)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public async Task<IEnumerable<Aluno>> GetAll(CancellationToken cancellationToken = default)
        {
           var alunos = _context.Alunos.ToListAsync();
            return await alunos;
        }

        public async Task<Aluno?> GetById(int id, CancellationToken cancellationToken = default)
        {
           var aluno =  _context.Alunos.Find(id);
            if(aluno == null)
            {
                throw new Exception();
            }
            return aluno;
        }
    }
}
