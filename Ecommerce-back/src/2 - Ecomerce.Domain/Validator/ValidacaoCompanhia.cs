using Ecomerce.Domain.Entities;
using FluentValidation;

namespace Ecomerce.Domain.Validator
{
    public class ValidacaoCompanhia : AbstractValidator<Companhia>
    {
        public ValidacaoCompanhia()
        {
             RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");
            
            RuleFor(x => x.NomeFantasia)
                .NotEmpty()
                .WithMessage("O nome fantasia não pode ser vazio.")
                
                .NotNull()
                .WithMessage("O nome fantasia não pode ser nulo");

            RuleFor(x => x.RazaoSocial)
                .NotEmpty()
                .WithMessage("A razão social não pode ser vazia.")
                
                .NotNull()
                .WithMessage("A razão social não pode ser nula");

             RuleFor(x => x.CNPJ)
                    .NotEmpty()
                    .WithMessage("O CNPJ não pode ser vazio.")

                    .NotNull()
                    .WithMessage("O CNPJnão pode ser nulo")

                    .Length(14)
                    .WithMessage("O CNPJ deve ter exatamente 14 caracteres.")

                    .Matches( @"^[0-9]{14}$")
                    .WithMessage("O CNPJ informado não é válido");
        }
    }
}