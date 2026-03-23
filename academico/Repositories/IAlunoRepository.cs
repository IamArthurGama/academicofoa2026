using academico.Models;
namespace academico.Repositories
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> GetAll(CancellationToken cancellationToken = default);
        Task<Aluno?> GetById(int id, CancellationToken cancellationToken = default);
        Task Create(Aluno aluno, CancellationToken cancellationToken = default);
        Task Edit(Aluno aluno, CancellationToken cancellationToken = default);
        Task Delete(int id, CancellationToken cancellationToken = default);
        Task <bool> Exists(int id, CancellationToken cancellationToken = default);
    }
}
