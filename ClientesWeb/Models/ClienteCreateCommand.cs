using System.ComponentModel.DataAnnotations;
using ClientesWeb.Attributes;

namespace ClientesWeb.Models
{
    public class ClienteCreateCommand
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [StringLength(100, ErrorMessage = "O e-mail deve ter no máximo 100 caracteres.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [CpfValido(ErrorMessage = "O CPF informado não é válido.")]
        public string? Cpf { get; set; }
    }
}