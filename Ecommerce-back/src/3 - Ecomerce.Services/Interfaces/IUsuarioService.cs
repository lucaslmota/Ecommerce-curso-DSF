using System.Collections.Generic;
using System.Threading.Tasks;
using Ecomerce.Services.DTO;

namespace Ecomerce.Services.Interfaces
{
    public interface IUsuarioService
    {
     Task<UsuarioDTO> Create(UsuarioDTO usuarioDTO);
     Task<UsuarioDTO> Update(UsuarioDTO usuarioDTO);
     Task Remove (int id);
     Task<UsuarioDTO> Get(int id);
     Task<List<UsuarioDTO>> Get();
     Task<List<UsuarioDTO>> SearchByNome(string nome);
     Task<List<UsuarioDTO>> SearchByEmail(string email);
     Task<List<UsuarioDTO>> GetByEmail(string email);

    }
}