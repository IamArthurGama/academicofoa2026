using System.ComponentModel.DataAnnotations;

namespace academico.Models
{
    // O Enum pode ficar aqui fora (acessível como StatusProjeto)
    public enum StatusProjeto
    {
        [Display(Name = "Em desenvolvimento")]
        EmDesenvolvimento = 1,

        [Display(Name = "Em condições de defesa")]
        EmCondicoesDeDefesa = 2,

        [Display(Name = "Completo sem implantar")]
        CompletoSemImplantar = 3,

        [Display(Name = "Implantado")]
        Implantado = 4
    }

    public class Projeto
    {
        [Key]
        public int ProjetoId { get; set; }

        [Required(ErrorMessage = "O nome do projeto é obrigatório.")]
        [StringLength(150)]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "A sigla é obrigatória.")]
        [StringLength(10)]
        public string Sigla { get; set; } = string.Empty;

        [Required(ErrorMessage = "O ano é obrigatório.")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "O status deve ser selecionado.")]
        public StatusProjeto Status { get; set; }
    }
}