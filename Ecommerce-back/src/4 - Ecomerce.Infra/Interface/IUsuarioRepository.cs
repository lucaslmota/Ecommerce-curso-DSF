using System.Collections.Generic;
using System.Threading.Tasks;
using Ecomerce.Domain.Entities;

namespace Ecomerce.Infra.Interface
{
    public interface IUsuarioRepository : IBaseRepository<Usuario> 
    {
         Task<Usuario> GetByEmail(string email);
         Task<List<Usuario>> SearchByEmail(string email);
         Task<List<Usuario>> SearchByNome(string nome);
    }
}