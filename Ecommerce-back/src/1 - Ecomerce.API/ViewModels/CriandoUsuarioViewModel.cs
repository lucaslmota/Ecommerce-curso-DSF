using System.ComponentModel.DataAnnotations;

namespace Ecomerce.API.ViewModels
{
    public class CriandoUsuarioViewModel
    {
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
        //[MaxLength(11,ErrorMessage ="O CPF deve ter extamente 11 números")]
        //[RegularExpression("^\d{3}\.\d{3}\.\d{3}\-\d{2}$/",ErrorMessage ="O CPF não é válido")]
        // @"^(\d{3}\.\d{3}\.\d{3}\-\d{2})$"
        public string Cpf { get; set; }
    }
}