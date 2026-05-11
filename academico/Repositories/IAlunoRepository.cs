using academico.Models;
namespace academico.Repositories
{
    public interface IAlunoRepository
    {
        Task<IEnumerable<Aluno>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Aluno?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task CreateAsync(Aluno aluno, CancellationToken cancellationToken = default);
        Task EditAsync(Aluno aluno, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default);
    }
}
