using Ecomerce.Domain.Entities;
using FluentValidation;

namespace Ecomerce.Domain.Validator
{
    public class ValidacaoProdutoPedido : AbstractValidator<ProdutoPedido>
    {
        public ValidacaoProdutoPedido()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia.")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            
            RuleFor(x => x.Quantidade)
                .NotEmpty()
                .WithMessage("A quantidade de pedidos não pode ser vazia.")

                .NotNull()
                .WithMessage("A quantidade de não pode ser nula.");
        }
    }
}