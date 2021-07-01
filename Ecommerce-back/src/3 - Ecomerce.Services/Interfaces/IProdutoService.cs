using System.Collections.Generic;
using System.Threading.Tasks;
using Ecomerce.Services.DTO;

namespace Ecomerce.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<ProdutoDTO> Create(ProdutoDTO produtoDTO);
        Task<ProdutoDTO> Update(ProdutoDTO produtoDTO);
        Task Remove (int id);
        Task<ProdutoDTO> Get(int id);
        Task<List<ProdutoDTO>> GetByNome (string nome);
    }
}