using academico.Models;
using academico.Repositories;

namespace academico.Repositories
{
    public class InMemoryAlunoRepository : IAlunoRepository
    {
        private readonly List<Aluno> _alunos = new List<Aluno>();
        private int _nextId = 1;
        private readonly object _lock = new object();

        public InMemoryAlunoRepository() {
        _alunos.Add(new Aluno
        {
            AlunoId = _nextId++,
            Nome = "Aluno Teste",
            Email = "aluno@exemplo.com",
            Telefone = "(99) 99999-9999",
            Endereco = "Rua Teste, Numero 123",
            Complemento = "Casa",
            Bairro = "Centro",
            Municipio= "Cidade Teste",
            Uf = "ST",
            Cep = "99999-999"
        });
        }
        public Task Create(Aluno aluno, CancellationToken cancellationToken = default)
        {
           lock (_lock)
            {
                aluno.AlunoId = _nextId++;
                _alunos.Add(aluno);
            }
           return Task.CompletedTask;
        }

        public Task Delete(int id, CancellationToken cancellationToken = default)
        {
            lock (_lock)
            {
                var aluno = _alunos.FirstOrDefault(a => a.AlunoId == id);
                if (aluno != null)
                {
                    _alunos.Remove(aluno);
                }
            }
            return Task.CompletedTask;
        }

        public Task Edit(Aluno aluno, CancellationToken cancellationToken = default)
        {
            lock (_lock)
            {
                var existing = _alunos.FirstOrDefault( a => a.AlunoId == aluno.AlunoId);
                if (existing != null)
                {
                    existing.Nome = aluno.Nome;
                    existing.Email = aluno.Email;
                    existing.Telefone = aluno.Telefone;
                    existing.Endereco = aluno.Endereco;
                    existing.Complemento = aluno.Complemento;
                    existing.Bairro = aluno.Bairro;
                    existing.Municipio = aluno.Municipio;
                    existing.Uf = aluno.Uf;
                    existing.Cep = aluno.Cep;
                }
            }

            return Task.CompletedTask;
        }

        public Task<bool> Exists(int id, CancellationToken cancellationToken = default)
        {
            bool exists;
            lock (_lock)
            {
                exists = _alunos.Any(a => a.AlunoId == id);
            }

            return Task.FromResult(exists);

        }

        public Task<IEnumerable<Aluno>> GetAll(CancellationToken cancellationToken = default)
        {
            IEnumerable<Aluno> result;
            lock (_lock)
            {
                result = _alunos.Select(a => a).ToList();
            }

            return Task.FromResult(result);
        }

        public Task<Aluno?> GetById(int id, CancellationToken cancellationToken = default)
        {
            Aluno? aluno;
            lock (_lock)
            {
                aluno = _alunos.FirstOrDefault(a => a.AlunoId == id);
            }
            return Task.FromResult(aluno);
        }
    }
}
