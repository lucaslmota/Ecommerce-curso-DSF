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
    public class ProdutoController :ControllerBase
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        [Route("api/v1/produdo/create")]
        public async Task<IActionResult> Create([FromBody] CriandoProdutoViewModel produtoViewModel)
        {
            try
            {
                var produtoDTO = _mapper.Map<ProdutoDTO>(produtoViewModel);

                var criarProduto = await _produtoService.Create(produtoDTO);

                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Produto criado com sucesso.",
                    Sucesso = true,
                    Dados = criarProduto
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
        [Route("api/v1/produto/update")]
        public async Task<IActionResult> Update([FromBody] UpdateProdutoViewModel produtoViewModel)
        {
            try
            {
                var produtoDTO = _mapper.Map<ProdutoDTO>(produtoViewModel);

                var produtoUpdate = await _produtoService.Update(produtoDTO);

                return Ok(new ResultadoViewModel
                {
                    Mensagem = "Produto atualizado com sucesso.",
                    Sucesso = true,
                    Dados = produtoDTO
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
        [Route("/api/v1/produto/remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _produtoService.Remove(id);

                return Ok(new ResultadoViewModel
                { 
                    Mensagem = "Produto removido com sucesso.",
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
        [Route("/api/v1/produto/get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var produto = await _produtoService.Get(id);

                if(produto == null)
                    return Ok(new ResultadoViewModel
                    {
                        Mensagem = "Nenhum produto foi encontrado com o ID informado.",
                        Sucesso = true,
                        Dados = produto
                    });

                return Ok(new ResultadoViewModel
                {
                    Mensagem = "O produto foi encontrado com o sucesso.",
                    Sucesso = true,
                    Dados = produto
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
        [Route("/api/v1/produto/search-by-name")]
        public async Task<IActionResult> GetByNome([FromQuery] string nome)
        {
            try
            {
                var todosProdutos = await _produtoService.GetByNome(nome);

                if (todosProdutos.Count == 0)
                    return Ok(new ResultadoViewModel
                    {
                        Mensagem = "Nenhum produto foi encontrado com o nome informado.",
                        Sucesso = true,
                        Dados = todosProdutos
                    });

                return Ok(new ResultadoViewModel
                    {
                        Mensagem = "O produto foi encontrado com o sucesso.",
                        Sucesso = true,
                        Dados = todosProdutos
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