using System.Collections.Generic;
using Ecomerce.Core.Exceptions;
using Ecomerce.Domain.Validator;

namespace Ecomerce.Domain.Entities
{
    public class Companhia : Base
    {
        public Companhia(string nomeFantasia, string razaoSocial, string cNPJ)
        {
            NomeFantasia = nomeFantasia;
            RazaoSocial = razaoSocial;
            CNPJ = cNPJ;

            _erroros = new List<string>();

            Validate();
        }

        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public virtual List<Produto> Produtos { get; set; }
        public override bool Validate()
        {
            var validador = new ValidacaoCompanhia();
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