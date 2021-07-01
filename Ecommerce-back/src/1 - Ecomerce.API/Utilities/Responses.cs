using System.Collections.Generic;
using Ecomerce.API.ViewModels;

namespace Ecomerce.API.Utilities
{
    public static class Responses
    {
          public static ResultadoViewModel ApplicationErrorMessage()
        {
            return new ResultadoViewModel
            {
                Mensagem = "Ocorreu algum erro interno na aplicação, por favor tente novamente.",
                Sucesso = false,
                Dados = null
            };
        }

        public static ResultadoViewModel DomainErrorMessage(string mensagem)
        {
            return new ResultadoViewModel
            {
                Mensagem = mensagem,
                Sucesso = false,
                Dados = null
            };
        }

        public static ResultadoViewModel DomainErrorMessage(string mensagem, IReadOnlyCollection<string> errors)
        {
            return new ResultadoViewModel
            {
                Mensagem = mensagem,
                Sucesso = false,
                Dados = errors
            };
        }

        public static ResultadoViewModel UnauthorizedErrorMessage()
        {
            return new ResultadoViewModel
            {
                Mensagem = "A combinação de login e senha está incorreta!",
                Sucesso = false,
                Dados = null
            };
        }
    }
}