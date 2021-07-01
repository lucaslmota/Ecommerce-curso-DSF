using System;
using Ecomerce.API.Token;
using Ecomerce.API.Utilities;
using Ecomerce.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Ecomerce.API.Controllers
{
    [ApiController]
    public class AuthController :ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthController(IConfiguration configuration, ITokenGenerator tokenGenerator)
        {
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        [AllowAnonymous]
        [EnableCors("MyPolicy")]
        [Route("/api/v1/auth/login")]
        public IActionResult Login([FromBody]LoginViewModel loginViewModel){
            try
            {
                var tokenLogin = _configuration["Jwt:Login"];
                var tokenPassword = _configuration["Jwt:Password"];

                if (loginViewModel.Login == tokenLogin && loginViewModel.Password == tokenPassword)
                {
                    return Ok(new ResultadoViewModel
                    {
                        Mensagem = "Entidade criada com sucesso!",
                        Sucesso = true,
                        Dados = new
                        {
                            Token = _tokenGenerator.GenerateToken(),
                            TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
                        }
                    });
                }
                else
                {
                    return StatusCode(401, Responses.UnauthorizedErrorMessage());
                }
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}