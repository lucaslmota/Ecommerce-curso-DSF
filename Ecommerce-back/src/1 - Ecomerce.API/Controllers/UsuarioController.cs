using System;
using System.Threading.Tasks;
using AutoMapper;
using Ecomerce.API.Utilities;
using Ecomerce.API.ViewModels;
using Ecomerce.Core.Exceptions;
using Ecomerce.Services.DTO;
using Ecomerce.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ecomerce.API.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        [Route("/api/v1/user/create")]
        public async Task<IActionResult> Create([FromBody] CriandoUsuarioViewModel usuarioViewModel)
        {
            try
            {
                var usuarioDTO = _mapper.Map<UsuarioDTO>(usuarioViewModel);

                var criarUsuario = await _usuarioService.Create(usuarioDTO);

                return Ok( new ResultadoViewModel{
                    Mensagem = "Usuário criado com sucesso!",
                    Sucesso = true,
                    Dados = criarUsuario
                });
            }
            catch (DomainException ex)
            {
                
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }

            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        [Authorize]
        [Route("api/v1/user/update")]
        public async Task<IActionResult> Update([FromBody] UpdateUsuarioViewModel usuarioViewModel)
        {
            try
            {
                var usuarioDTO = _mapper.Map<UsuarioDTO>(usuarioViewModel);

                var usuarioUpdate = await _usuarioService.Update(usuarioDTO);

                return Ok( new ResultadoViewModel
                {
                    Mensagem = "Usuário atualizado com sucesso.",
                    Sucesso = true,
                    Dados = usuarioUpdate
                });
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex);
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("api/v1/user/remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _usuarioService.Remove(id);

                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Usuário removido com sucesso",
                    Sucesso = true,
                    Dados = null
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var user = await _usuarioService.Get(id);

                if(user == null)
                    return Ok(new ResultadoViewModel
                    {
                        Mensagem = "Nenhum usuário foi encontrado com o ID informado.",
                        Sucesso = true,
                        Dados = user
                    });

                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Usuário encontrado com sucesso!",
                    Sucesso = true,
                    Dados = user
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/get-all")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var allUsers = await _usuarioService.Get();

                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Usuários encontrados com sucesso!",
                    Sucesso = true,
                    Dados = allUsers
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/get-by-email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            try
            {
                var user = await _usuarioService.GetByEmail(email);

                if (user == null)
                    return Ok(new ResultadoViewModel
                    {
                        Mensagem = "Nenhum usuário foi encontrado com o email informado.",
                        Sucesso = true,
                        Dados = user
                    });


                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Usuário encontrado com sucesso!",
                    Sucesso = true,
                    Dados = user
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/search-by-name")]
        public async Task<IActionResult> SearchByNome([FromQuery] string nome)
        {
            try
            {
                var allUsers = await _usuarioService.SearchByNome(nome);

                if (allUsers.Count == 0)
                    return Ok(new ResultadoViewModel
                    {
                        Mensagem = "Nenhum usuário foi encontrado com o nome informado",
                        Sucesso = true,
                        Dados = null
                    });

                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Usuário encontrado com sucesso!",
                    Sucesso = true,
                    Dados = allUsers
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/users/search-by-email")]
        public async Task<IActionResult> SearchByEmail([FromQuery] string email)
        {
            try
            {
                var allUsers = await _usuarioService.SearchByEmail(email);

                if (allUsers.Count == 0)
                    return Ok(new ResultadoViewModel
                    {
                        Mensagem = "Nenhum usuário foi encontrado com o email informado",
                        Sucesso = true,
                        Dados= null
                    });

                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Usuário encontrado com sucesso!",
                    Sucesso = true,
                    Dados= allUsers
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}