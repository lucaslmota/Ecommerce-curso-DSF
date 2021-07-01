using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Ecomerce.Core.Exceptions;
using Ecomerce.Domain.Entities;
using Ecomerce.Infra.Interface;
using Ecomerce.Services.DTO;
using Ecomerce.Services.Interfaces;

namespace Ecomerce.Services.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IMapper mapper, IProdutoRepository produtoRepository)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        public async Task<ProdutoDTO> Create(ProdutoDTO produtoDTO)
        {
            var existeProduto = await _produtoRepository.Get(produtoDTO.Id);

            if(existeProduto != null)
            {
                throw new DomainException("Esse produto já existe em nossa base de dados.");
            }

            var produto = _mapper.Map<Produto>(produtoDTO);
            produto.Validate();

            var produtoCriado= await _produtoRepository.Create(produto);
            return _mapper.Map<ProdutoDTO>(produtoCriado);
        }
        public async Task<ProdutoDTO> Update(ProdutoDTO produtoDTO)
        {
            var existeProduto = await _produtoRepository.Get(produtoDTO.Id);

            if(existeProduto == null)
            {
                throw new DomainException("Não existe nenhum produto com o id informado");
            }

            var produto = _mapper.Map<Produto>(produtoDTO);
            produto.Validate();

            var atualizaProduto = await _produtoRepository.Updade(produto);
            return _mapper.Map<ProdutoDTO>(atualizaProduto);
        }
         public async Task Remove(int id)
        {
            await _produtoRepository.Remove(id);
        }

        public async Task<ProdutoDTO> Get(int id)
        {
            var produto = await _produtoRepository.Get(id);

            return _mapper.Map<ProdutoDTO>(produto);
        }

        public async Task<List<ProdutoDTO>> GetByNome(string nome)
        {
            var todosProdutos = await _produtoRepository.GetByNome(nome);

            return _mapper.Map<List<ProdutoDTO>>(nome);
        }
    }
}