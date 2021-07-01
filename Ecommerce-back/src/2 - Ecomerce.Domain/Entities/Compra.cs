using System;
using System.Collections.Generic;
using Ecomerce.Core.Exceptions;
using Ecomerce.Domain.Enums;
using Ecomerce.Domain.Interfaces;
using Ecomerce.Domain.Validator;

namespace Ecomerce.Domain.Entities
{
    public class Compra : Base
    {
        public Compra(){}

        public Compra(float valor, DateTime data, FormaDePagamento formaDePagamento, StatusCompra statusCompra, string observacao, string cep, string endereco)
        {
            Valor = valor;
            Data = data;
            FormaDePagamento = formaDePagamento;
            StatusCompra = statusCompra;
            Observacao = observacao;
            Cep = cep;
            Endereco = endereco;

            _erroros = new List<string>();

            Validate();
        }

        public float Valor { get; set; }
        public DateTime Data {get; set;}
        public FormaDePagamento FormaDePagamento { get; set; }
        public StatusCompra StatusCompra { get; set; }
        public string Observacao { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
       
        public int IdUsuario {get; set;}
        public virtual Usuario Usuario {get; set;}
        public virtual List<ProdutoPedido> ProdutosPedidos { get; set; }

        public override bool Validate()
        {
            var validador  = new ValidacaoCompra();
            var validacao = validador.Validate(this);

            if(!validacao.IsValid){
                foreach(var error in validacao.Errors)
                {
                    _erroros.Add(error.ErrorMessage);
                    throw new DomainException("Alguns campos estão invalidos, por favor corrija-os!", _erroros);
                }
            }
            return true;
        }
    }
}