using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecomerce.Domain.Entities;
using Ecomerce.Infra.Context;
using Ecomerce.Infra.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecomerce.Infra.Repositories
{
    public class CompraRepository : BaseRepository<Compra>, ICompraRepository
    {
        private readonly EcomerceContext _context;
        public CompraRepository(EcomerceContext context) : base(context)
        {
            _context = context;
        }

        
    }
}