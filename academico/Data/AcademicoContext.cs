using academico.Models;
using Microsoft.EntityFrameworkCore;

namespace academico.Data
{
    public class AcademicoContext : DbContext
    {
        public AcademicoContext(DbContextOptions options) : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
    }
}
