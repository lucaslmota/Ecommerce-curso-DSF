using Ecomerce.Domain.Entities;
using FluentValidation;

namespace Ecomerce.Domain.Validator
{
    public class ValidacaoUsuario : AbstractValidator<Usuario>
    {
        public ValidacaoUsuario()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("A entidade não pode ser vazia")

                .NotNull()
                .WithMessage("A entidade não pode ser nula.");

                RuleFor(x => x.Nome)
                    .NotNull()
                    .WithMessage("O nome não pode ser nulo.")

                    .NotEmpty()
                    .WithMessage("O nome não pode ser vazio.")

                    .MinimumLength(3)
                    .WithMessage("O nome deve ter no mínimo 3 caracteres.")

                    .MaximumLength(80)
                    .WithMessage("O nome deve ter no máximo 80 caracteres.");

                RuleFor(x => x.Senha)
                    .NotEmpty()
                    .WithMessage("A senha nã pode ser vazia")

                    .NotNull()
                    .WithMessage("A senha não pode ser nula")

                    .MinimumLength(6)
                    .WithMessage("A senha deve ter no mínimo 6 caracteres.")

                    .MaximumLength(80)
                    .WithMessage("A senha deve ter no máximo 30 caracteres.");
                
                RuleFor(x => x.Email)
                    .NotEmpty()
                    .WithMessage("O e-mail não pode ser vazio.")

                    .NotNull()
                    .WithMessage("O e-mail não pode ser nulo")

                    .MinimumLength(10)
                    .WithMessage("O email deve ter no mínimo 10 caracteres.")

                    .MaximumLength(180)
                    .WithMessage("O email deve ter no máximo 180 caracteres.")

                    .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
                    .WithMessage("O e-mail informado não é válido");

                RuleFor(x => x.Cpf)
                    .NotEmpty()
                    .WithMessage("O CPF não pode ser vazio.")

                    .NotNull()
                    .WithMessage("O CPF não pode ser nulo");

                    // .Matches(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$)")
                    // .WithMessage("O cpf informado não é válido");
                    
                    // .Length(11)
                    // .WithMessage("O CPF deve ter extamente 11 números");

                    
        }
    }
}