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
    public class CompraController : ControllerBase
    {
        private readonly ICompraService _compraService;
        private readonly IMapper _mapper;

        public CompraController(ICompraService compraService, IMapper mapper)
        {
            _compraService = compraService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        [Route("api/v1/compra/create")]
        public async Task<IActionResult> Create([FromBody] CriandoCompraViewModel compraViewModel)
        {

            try
            {
                var compraDTO = _mapper.Map<CompraDTO>(compraViewModel);

                var criandoCompra = await _compraService.Create(compraDTO);

                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Compra Criada com sucesso!",
                    Sucesso = true,
                    Dados = criandoCompra
                });
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("api/v1/compra/remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _compraService.Remove(id);
                return Ok( new ResultadoViewModel
                {
                    Mensagem = "Compra removida com sucesso!",
                    Sucesso = true,
                    Dados = null
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

        [HttpGet]
        [Authorize]
        [Route("api/v1/compra/get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var compra = await _compraService.Get(id);
                if(compra == null)
                {
                    return Ok(new ResultadoViewModel
                    {
                        Mensagem ="teste",
                        Sucesso = true,
                        Dados = compra

                    });
                }
                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Usuário encontrado com sucesso!",
                    Sucesso = true,
                    Dados = compra
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
        [Route("api/v1/compra/get-all")]
        public async Task<IActionResult> Get ()
        {
            try
            {
                var todasCompras = await _compraService.Get();

                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Compras encontradas com sucesso!",
                    Sucesso = true,
                    Dados = todasCompras
                });
            }
            catch(DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message));
            }
            catch(Exception)
            {
                return StatusCode(500,Responses.ApplicationErrorMessage());
            }
        }
    }
}