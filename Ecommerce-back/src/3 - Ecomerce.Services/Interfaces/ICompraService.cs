using System.Collections.Generic;
using System.Threading.Tasks;
using Ecomerce.Domain.Entities;
using Ecomerce.Services.DTO;

namespace Ecomerce.Services.Interfaces
{
    public interface ICompraService
    {
        Task<CompraDTO> Create(CompraDTO compraDTO);
        Task Remove (int id);
        Task<CompraDTO> Get(int id);
        Task<List<CompraDTO>> Get();
    }
}