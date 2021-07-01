using Ecomerce.Domain.Entities;
using Ecomerce.Infra.Context;
using Ecomerce.Infra.Interface;

namespace Ecomerce.Infra.Repositories
{
    public class CompanhiaRepository : BaseRepository<Companhia>, ICompanhiaRepository
    {
        private readonly EcomerceContext _context;
        public CompanhiaRepository(EcomerceContext context) : base(context)
        {
            _context = context;
        }
    }
}