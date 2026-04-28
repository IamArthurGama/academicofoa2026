using academico.Models;
using Microsoft.EntityFrameworkCore;

namespace academico.Data
{
    public class AcademicoContext : DbContext
    {
        public AcademicoContext(DbContextOptions<AcademicoContext> options) : base(options) { }
        public DbSet<Aluno> Alunos { get; set; }
    }
}
