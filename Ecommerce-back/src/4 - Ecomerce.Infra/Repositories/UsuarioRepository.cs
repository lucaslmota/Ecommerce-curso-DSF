using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecomerce.Domain.Entities;
using Ecomerce.Infra.Context;
using Ecomerce.Infra.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecomerce.Infra.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly EcomerceContext _context;

        public UsuarioRepository(EcomerceContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Usuario> GetByEmail(string email)
        {
            var usuario = await _context.Usuarios.Where(
                x => x.Email.ToLower() == email.ToLower()
            )
            .AsNoTracking()
            .ToListAsync();
            return usuario.FirstOrDefault();
        }

        public async Task<List<Usuario>> SearchByEmail(string email)
        {
            var todosOsUsuarios = await _context.Usuarios.Where(
                x => x.Email.ToLower().Contains(email.ToLower())
            )
            .AsNoTracking()
            .ToListAsync();

            return todosOsUsuarios;
            
        }

        public async Task<List<Usuario>> SearchByNome(string nome)
        {
            var todosOsUsuarios = await _context.Usuarios.Where(
                x => x.Nome.ToLower().Contains(nome.ToLower())
            )
            .AsNoTracking()
            .ToListAsync();
            return todosOsUsuarios;
        }
    }
}