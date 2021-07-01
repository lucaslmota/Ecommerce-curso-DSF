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
    public class CompanhiaController : ControllerBase
    {
        private readonly ICompanhiaService _companhiaService;
        private readonly IMapper _mapper;

        public CompanhiaController(ICompanhiaService companhiaService, IMapper mapper)
        {
            _companhiaService = companhiaService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("api/v1/companhia/create")]
        public async Task<IActionResult> Create ([FromBody] CriandoCompanhiaViewModel companhiaViewModel)
        {
            try
            {
                var companhiaDTO = _mapper.Map<CompanhiaDTO>(companhiaViewModel);

                var criandoCompanhia = await _companhiaService.Create(companhiaDTO);
                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Companhia Criada com sucesso!",
                    Sucesso = true,
                    Dados = criandoCompanhia
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception)
            {
                return StatusCode(500,Responses.ApplicationErrorMessage());
            }
        }

        [HttpPut]
        [Authorize]
        [Route("api/v1/companhia/update")]
        public async Task<IActionResult> Update([FromBody] UpdateCompanhiaViewModel updateCompanhiaView)
        {
            try
            {
                var companhiaDTO = _mapper.Map<CompanhiaDTO>(updateCompanhiaView);

                var atualizandoCompanhia = await _companhiaService.Update(companhiaDTO);
                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Companhia atualizada com sucesso!",
                    Sucesso = true,
                    Dados = atualizandoCompanhia
                });
            }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception)
            {
                return StatusCode(500,Responses.ApplicationErrorMessage());
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("api/v1/companhia/remove/{id}")]
         public async Task<IActionResult> Remove(int id)
         {
             try
             {
                 await _companhiaService.Remove(id);
                 return Ok(new ResultadoViewModel
                {
                    Mensagem = "Companhia removida com sucesso!",
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
                return StatusCode(500,Responses.ApplicationErrorMessage());
            }
         }

         [HttpGet]
         [Authorize]
         [Route("api/v1/companhia/get/{id}")]
         public async Task<IActionResult> Get (int id)
         {
             try
             {
                 var companhia = await _companhiaService.Get(id);

                 if(companhia == null)
                 
                    return Ok(new ResultadoViewModel
                    {
                        Mensagem = "Nenhuma companhia foi encontrado com o ID informado.",
                        Sucesso = true,
                        Dados = companhia
                    });

                    return Ok(new ResultadoViewModel
                    {
                        Mensagem = "A companhia foi encontrado com o ID informado.",
                        Sucesso = true,
                        Dados = companhia
                    });
                 
             }
             catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception)
            {
                return StatusCode(500,Responses.ApplicationErrorMessage());
            }
         }

        [HttpGet]
        [Authorize]
        [Route("/api/v1/companhia/get-all")]
         public async Task<IActionResult> Get()
         {
             try
             {
                 var companhia = await _companhiaService.Get();
                 return Ok(new ResultadoViewModel
                 {
                    Mensagem = "Todas as companhia foram encontradas.",
                    Sucesso = true,
                    Dados = companhia
                 });
             }
            catch (DomainException ex)
            {
                return BadRequest(Responses.DomainErrorMessage(ex.Message, ex.Errors));
            }
            catch(Exception)
            {
                return StatusCode(500,Responses.ApplicationErrorMessage());
            }
         }
    }
}