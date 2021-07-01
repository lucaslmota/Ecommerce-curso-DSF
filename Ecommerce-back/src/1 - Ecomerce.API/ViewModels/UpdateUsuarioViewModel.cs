using System.ComponentModel.DataAnnotations;

namespace Ecomerce.API.ViewModels
{
    public class UpdateUsuarioViewModel
    {
        [Required(ErrorMessage ="O Id não pode ser vazio.")]
        [Range(1, int.MaxValue, ErrorMessage ="O Id não pode ser menor que um.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome não pode ser nulo.")]
        [MinLength(3, ErrorMessage ="O deve ter no mínimo 3 caracteres")]
        [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="O e-mail não pode ser vazio.")]
        [MinLength(10,ErrorMessage ="O email deve ter no mínimo 10 caracteres.")]
        [MaxLength(180,ErrorMessage ="O email deve ter no máximo 180 caracteres.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage ="O email informado não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha não pode ser vazia.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 10 caracteres.")]
        [MaxLength(80, ErrorMessage = "A senha deve ter no máximo 80 caracteres.")]
        public string Senha { get; set; }

        [Required(ErrorMessage ="O CPF não pode ser vazio.")]
        [MaxLength(11,ErrorMessage ="O CPF não pode ter mais de 11 números")]
        [MinLength(11,ErrorMessage ="O CPF não pode ter menos de 11 números")]
        public string Cpf { get; set; }
    }
}