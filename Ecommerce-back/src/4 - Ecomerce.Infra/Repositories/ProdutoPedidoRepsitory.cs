using Ecomerce.Domain.Entities;
using Ecomerce.Infra.Context;
using Ecomerce.Infra.Interface;

namespace Ecomerce.Infra.Repositories
{
    public class ProdutoPedidoRepsitory : BaseRepository<ProdutoPedido>, IProdutoPedidoRepository
    {
        private readonly EcomerceContext _context;

        public ProdutoPedidoRepsitory(EcomerceContext context) : base(context)
        {
            _context = context;
        }
    }
}