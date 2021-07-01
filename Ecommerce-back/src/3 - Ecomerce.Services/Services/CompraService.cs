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
    public class CompraService : ICompraService
    {
        private readonly IMapper _mapper;
        private readonly ICompraRepository _compraRepository;

        public CompraService(IMapper mapper, ICompraRepository compraRepository)
        {
            _mapper = mapper;
            _compraRepository = compraRepository;
        }

        public async Task<CompraDTO> Create(CompraDTO compraDTO)
        {
            var existeCompra = await _compraRepository.Get(compraDTO.Id);

            if(existeCompra != null)
            {
                throw new DomainException("O resgistro desta compra não existe na base de dados.");
            }

            var compra = _mapper.Map<Compra>(compraDTO);
            compra.Validate();

            var criarCompra = await _compraRepository.Create(compra);
            return _mapper.Map<CompraDTO>(criarCompra);
        }
        public async Task Remove(int id)
        {
            await _compraRepository.Remove(id);
        }

        public async Task<CompraDTO> Get(int id)
        {
            var compra = await _compraRepository.Get(id);

            return _mapper.Map<CompraDTO>(compra);
        }

        public async Task<List<CompraDTO>> Get()
        {
            var todasCompras = await _compraRepository.Get();

            return _mapper.Map<List<CompraDTO>>(todasCompras);
        }
    }
}