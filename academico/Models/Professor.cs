using System.ComponentModel.DataAnnotations;

namespace academico.Models
{
    public class Professor
    {
        [Key]
        public int ProfessorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "01/01/1900", "31/12/9999",
    ErrorMessage = "Data de nascimento inválida")]
        public DateTime DataNascimento { get; set; }

        [Required]

        public decimal Salario { get; set; }
    }
}
