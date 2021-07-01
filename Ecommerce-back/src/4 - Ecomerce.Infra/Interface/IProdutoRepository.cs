using System.Collections.Generic;
using System.Threading.Tasks;
using Ecomerce.Domain.Entities;

namespace Ecomerce.Infra.Interface
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
         Task<List<Produto>> GetByNome (string nome);
    }
}