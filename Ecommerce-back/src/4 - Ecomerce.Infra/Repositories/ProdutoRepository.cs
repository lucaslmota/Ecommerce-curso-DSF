using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecomerce.Domain.Entities;
using Ecomerce.Infra.Context;
using Ecomerce.Infra.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecomerce.Infra.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
      private readonly EcomerceContext _context;  

      public ProdutoRepository(EcomerceContext context) :  base(context)
      {
          _context = context;
      }

        public async Task<List<Produto>> GetByNome(string nome)
        {
            var todosOsProdutos = await _context.Produtos.Where(
                x => x.Nome.ToLower().Contains(nome.ToLower())
            )
            .AsNoTracking()
            .ToListAsync();

            return todosOsProdutos;
        }
    }
}