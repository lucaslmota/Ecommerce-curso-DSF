using System.Threading.Tasks;
using Ecomerce.Services.DTO;

namespace Ecomerce.Services.Interfaces
{
    public interface IProdudoPedidoService
    {
         Task<ProdutoPedidoDTO> Get(int id);
    }
}