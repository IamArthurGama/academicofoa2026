using System.ComponentModel.DataAnnotations;

namespace academico.Models
{
    public class Aluno
    {
        [Key]
        public int AlunoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [EmailAddress(ErrorMessage = "O campo e-mail está preenchido de forma incorreta.")]
        [Display(Name = "E-mail")]
        [StringLength(200)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([1-9]{2})\)? ?(?:9[0-9]|[2-8])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Telefone inválido. Use (99) 99999-9999 ou (99) 9999-9999.")]
        public string Telefone { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Endereco { get; set; } = string.Empty;

        // Complemento é opcional
        [StringLength(100)]
        public string? Complemento { get; set; }

        [Required]
        [StringLength(100)]
        public string Bairro { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [Display(Name = "Município")]
        public string Municipio { get; set; } = string.Empty;

        [Required]
        [StringLength(2, MinimumLength = 2)]
        [Display(Name = "UF")]
        [RegularExpression("^[A-Z]{2}$", ErrorMessage = "UF deve conter 2 letras maiúsculas.")]
        public string Uf { get; set; } = string.Empty;

        [Required]
        [Display(Name = "CEP")]
        [DataType(DataType.PostalCode)]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "CEP inválido. Use 99999-999.")]
        public string Cep { get; set; } = string.Empty;
    }
}