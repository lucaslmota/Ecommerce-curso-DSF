using System.ComponentModel.DataAnnotations;

namespace Ecomerce.API.ViewModels
{
    public class UpdateCompanhiaViewModel
    {
        [Required(ErrorMessage = "O Id não pode ser vazio.")]
        [Range(1, int.MaxValue, ErrorMessage = "O id não pode ser menor que 1.")]
        public int Id { get; set; }

        [Required(ErrorMessage ="A companhia deve possuir um nome fantazia.")]
        [MaxLength(255,ErrorMessage ="O nome da companhia deve ter no máximo 255 caracteres")]
        [MinLength(3,ErrorMessage ="O nome da companhia deve ter no mínimo 3 caracteres")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage ="A companhia deve possuir uma RazaoSocial.")]
        [MaxLength(255,ErrorMessage ="A RazaoSocial deve ter no máximo 255 caracteres")]
        [MinLength(3,ErrorMessage ="A RazaoSocial deve ter no mínimo 3 caracteres")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage ="CNPJ é obrigatório")]
        [RegularExpression(@"^[0-9]{14}$",ErrorMessage = "O CNPJ não é válido.")]
        public string CNPJ { get; set; }
    }
}