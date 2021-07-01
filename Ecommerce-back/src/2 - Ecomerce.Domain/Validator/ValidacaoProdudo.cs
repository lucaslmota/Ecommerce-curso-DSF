using Ecomerce.Domain.Entities;
using FluentValidation;

namespace Ecomerce.Domain.Validator
{
    public class ValidacaoProdudo : AbstractValidator<Produto>
    {
        public ValidacaoProdudo()
        {
             RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O nome não pode ser vazio")

                .NotNull()
                .WithMessage("O nome não pode ser nulo.")
                
                .MinimumLength(3)
                .WithMessage("O nome do produto deve ter no mínimo 3 caracteres.")
                
                .MaximumLength(180)
                .WithMessage("O nome do produto deve ter no máximo 180 caracteres.");

            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("A descrição não pode ser vazia")

                .NotNull()
                .WithMessage("A descrição não pode ser nula.")
                
                .MaximumLength(255)
                .WithMessage("A descrição deve ter no máximo 255 caracteres.");

            RuleFor(x => x.Valor)
                .NotEmpty()
                .WithMessage("O valor não pode ser vazio")

                .NotNull()
                .WithMessage("O valor não pode ser nulo.");
            
            RuleFor(x => x.Observacao)
                .NotEmpty()
                .WithMessage("A observção não pode ser vazia")

                .NotNull()
                .WithMessage("A observação não pode ser nula.")
                
                .MaximumLength(255)
                .WithMessage("A observação deve ter no máximo 255 caracteres.");
        }
    }
}