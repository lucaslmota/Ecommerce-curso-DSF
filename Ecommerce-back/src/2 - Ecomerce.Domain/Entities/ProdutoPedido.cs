using System.Collections.Generic;
using Ecomerce.Domain.Validator;

namespace Ecomerce.Domain.Entities
{
    public class ProdutoPedido : Base
    {
        public ProdutoPedido(int quantidade)
        {
            Quantidade = quantidade;

            _erroros = new List<string>();

            Validate();
        }

        public int Quantidade { get; set; }

        public int IdCompra { get; set; }
        public virtual Compra Compra { get; set; }
        public long IdProduto { get; set; }
        public virtual Produto Produto { get; set; }

        
        public override bool Validate()
        {
            var validador = new ValidacaoProdutoPedido();
            var validacao = validador.Validate(this);

            if(!validacao.IsValid)
            {
                foreach (var error in validacao.Errors)
                {
                    _erroros.Add(error.ErrorMessage);
                }
            }
            return true;
        }
    }
}