using academico.Models;
using Microsoft.EntityFrameworkCore;

namespace academico.Data
{
    public class AcademicoDbInitializer
    {
        public static async Task InitializeAsync(AcademicoContext context)
        {
            await context.Database.MigrateAsync();

            if (await context.Alunos.AnyAsync())
            {
                return;
            }

            var alunos = new Aluno[]
            {
                new Aluno
                {
                    Nome = "Aluno Teste",
                    Email = "alunoTeste@mail.com",
                    Telefone = "(99) 99999-9999",
                    Endereco = "Rua Teste",
                    Complemento = "Casa",
                    Bairro = "Bairro Teste",
                    Municipio = "Municipio Teste",
                    Uf = "RJ",
                    Cep = "99999-999"
                }
            };

            await context.Alunos.AddRangeAsync(alunos);
            await context.SaveChangesAsync();
        }
    }
}
