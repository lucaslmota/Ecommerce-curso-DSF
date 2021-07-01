using System.ComponentModel.DataAnnotations;

namespace Ecomerce.API.ViewModels
{
    public class UpdateProdutoViewModel
    {
        [Required(ErrorMessage = "O Id não pode ser vazio.")]
        [Range(1, int.MaxValue, ErrorMessage = "O id não pode ser menor que 1.")]
        public int Id{ get; set; }

        [Required(ErrorMessage ="O nome do produdo não pode ser vazio.")]
        [MinLength(3,ErrorMessage ="O nome deve ter no mínimo 3 caracteres.")]
        [MaxLength(180, ErrorMessage = "O nome deve ter no máximo 180 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="A descrição do produdo não pode ser vazia.")]
        [MinLength(3,ErrorMessage ="A descrição deve ter no mínimo 3 caracteres.")]
        [MaxLength(255, ErrorMessage = "O nome deve ter no máximo 255 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage ="O valor não pode ser nulo")]
        [Range(1, float.MaxValue, ErrorMessage ="O valor não pode ser menor que 1.")]
        [DataType(DataType.Currency)]
        public float Valor { get; set; }

        [Required(ErrorMessage ="A obsercação do produdo não pode ser vazia.")]
        [MinLength(3,ErrorMessage ="A obsercação deve ter no mínimo 3 caracteres.")]
        [MaxLength(180, ErrorMessage = "O nome deve ter no máximo 180 caracteres.")]
        public string Observacao { get; set; }

        [Required(ErrorMessage ="O Id da companhia tem que ser informado")]
        public int IdCompanhia { get; set; }
    }
}