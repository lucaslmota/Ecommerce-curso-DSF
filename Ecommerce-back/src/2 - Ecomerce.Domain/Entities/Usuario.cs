using System.Collections.Generic;
using Ecomerce.Core.Exceptions;
using Ecomerce.Domain.Validator;

namespace Ecomerce.Domain.Entities
{
    public class Usuario : Base
    {
        public Usuario(){}

        public Usuario(string nome, string email, string senha, string cpf)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Cpf = cpf;
            _erroros = new List<string>();

            Validate();
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Cpf { get; private set; }

        public virtual List<Compra> Compras {get; set;}


        public void AuterarNome(string nome)
        {
            Nome = nome;
            Validate();
        }
        public void AuterarEmail(string email)
        {
            Email = email;
            Validate();
        }
        public void AuterarSenha(string senha)
        {
            Senha = senha;
            Validate();
        }
        public void AuterarCpf(string cpf)
        {
            Cpf = cpf;
            Validate();
        }
        public override bool Validate()
        {
            var validador = new ValidacaoUsuario();
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