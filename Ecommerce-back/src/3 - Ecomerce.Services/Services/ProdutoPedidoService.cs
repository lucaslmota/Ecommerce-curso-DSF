using System.Threading.Tasks;
using AutoMapper;
using Ecomerce.Infra.Interface;
using Ecomerce.Services.DTO;
using Ecomerce.Services.Interfaces;

namespace Ecomerce.Services.Services
{
    public class ProdutoPedidoService : IProdudoPedidoService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoPedidoRepository _produtoPedidoRepository;

        public ProdutoPedidoService(IMapper mapper, IProdutoPedidoRepository produtoPedidoRepository)
        {
            _mapper = mapper;
            _produtoPedidoRepository = produtoPedidoRepository;
        }

        public async Task<ProdutoPedidoDTO> Get(int id)
        {
            var produtoPedido = await _produtoPedidoRepository.Get(id);
            return _mapper.Map<ProdutoPedidoDTO>(produtoPedido);
        }
    }
}