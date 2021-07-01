using System.Collections.Generic;
using Ecomerce.Core.Exceptions;
using Ecomerce.Domain.Validator;

namespace Ecomerce.Domain.Entities
{
    public class Produto : Base
    {
        public Produto() {}

        public Produto(string nome, string descricao, float valor, string observacao)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Observacao = observacao;

            _erroros = new List<string>();

            Validate();
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public float Valor { get; set; }
        public string Observacao { get; set; }
        public int IdCompanhia { get; set; }
        public virtual Companhia Companhia { get; set; }

        public override bool Validate()
        {
            
            var validador = new ValidacaoProdudo();
            var validacao = validador.Validate(this);

            if(!validacao.IsValid)
            {
                foreach (var error in validacao.Errors)
                {
                    _erroros.Add(error.ErrorMessage);
                    throw new DomainException("Alguns campos estão invalidos, por favor corrija-os!", _erroros);
                }
            }
            return true;
        }
    }
}