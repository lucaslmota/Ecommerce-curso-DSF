using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Ecomerce.Domain.Entities;
using Ecomerce.Domain.Enums;

namespace Ecomerce.API.ViewModels
{
    public class CriandoCompraViewModel
    {
        [Required(ErrorMessage ="O valor não pode ser nulo")]
        [Range(1, float.MaxValue, ErrorMessage ="O valor não pode ser menor que 1.")]
        [DataType(DataType.Currency)]
        public float Valor { get; set; }

        [Required(ErrorMessage ="A data não pode ser nula.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}", ApplyFormatInEditMode =true)]
        public DateTime Data {get; set;}

        [Required(ErrorMessage ="A forma de pagamento tem que ser especificada")] 
        public FormaDePagamento FormaDePagamento { get; set; }

        [Required(ErrorMessage ="O estatos da compra tem que ser informado.")]
        public StatusCompra StatusCompra { get; set; }

        [MinLength(10,ErrorMessage="Mínimo 10 caracteres")]
        [MaxLength(255,ErrorMessage ="No máximo 255 caracteres")]
        public string Observacao { get; set; }

        [Required(ErrorMessage ="O CEP é obrigatório")]
        [MaxLength(8, ErrorMessage ="Tem que ter 8 números")]
        [MinLength(8,ErrorMessage ="não pode ter menis de 8 números")]
        [DataType(DataType.PostalCode)]
        public string Cep { get; set; }

        [Required(ErrorMessage ="O endereço é obrigatorio.")]
        [MaxLength(180,ErrorMessage ="O endereço não pode ter mais de 180 caracteres.")]
        [MinLength(10,ErrorMessage ="O endereço não pode ter menos de 10 caracteres.")]
        public string Endereco { get; set; }
        
        [Required(ErrorMessage ="O Id do usuário não pode ser nulo!")]
        public int IdUsuario {get;set;}
    }
}