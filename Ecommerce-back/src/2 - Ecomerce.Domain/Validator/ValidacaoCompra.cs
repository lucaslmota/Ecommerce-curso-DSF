using System;
using Ecomerce.Domain.Entities;
using FluentValidation;

namespace Ecomerce.Domain.Validator
{
    public class ValidacaoCompra : AbstractValidator<Compra>
    {
        public ValidacaoCompra()
        {
             RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");
            
            RuleFor(x => x.Valor)
                .NotEmpty()
                .WithMessage("O valor não pode ser vazio.")
                
                .NotNull()
                .WithMessage("O valor nã pode ser nulo");

            RuleFor(x => x.Data)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Must(data => data != default(DateTime))
                .WithMessage("A data da compra é obrigatória");

            RuleFor(x => x.FormaDePagamento)
                .IsInEnum()
                .WithMessage("Talvez não seja um Enum");

            RuleFor(x => x.StatusCompra)
                .IsInEnum()
                .WithMessage("Talvez não seja um Enum");

            RuleFor(x => x.Cep)
            .NotEmpty()
            .WithMessage("O cep Não pode ser vazio.")

            .NotNull()
            .WithMessage("O Cep não pode ser nulo.")

            .Length(8)
            .WithMessage("O CEP deve ter 8 números ")


            .Matches( @"^\d{5}\-?\d{3}$")//@"^\d{5}-\d{3}$"
            .WithMessage("O CEP deve seguir o padrão 99999-999.");
                
        }

       
    }
}