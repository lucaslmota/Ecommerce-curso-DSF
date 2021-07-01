using System;
using System.Collections.Generic;
using Ecomerce.Domain.Entities;
using Ecomerce.Domain.Enums;

namespace Ecomerce.Services.DTO
{
    public class CompraDTO
    {
        public CompraDTO()
        {
        }

        public CompraDTO(int IdUsuario,int id, float valor, DateTime data, FormaDePagamento formaDePagamento, StatusCompra statusCompra, string observacao, string cep, string endereco)
        {
            this.IdUsuario =IdUsuario ;
            Id = id;
            Valor = valor;
            Data = data;
            FormaDePagamento = formaDePagamento;
            StatusCompra = statusCompra;
            Observacao = observacao;
            Cep = cep;
            Endereco = endereco;
        }

        public int Id { get; set; }
        public float Valor { get; set; }
        public DateTime Data {get; set;}
        public FormaDePagamento FormaDePagamento { get; set; }
        public StatusCompra StatusCompra { get; set; }
        public string Observacao { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }

        public int IdUsuario {get; set;}
        //public virtual List<ProdutoPedido> ProdutosPedidos { get; set; }
    }
}