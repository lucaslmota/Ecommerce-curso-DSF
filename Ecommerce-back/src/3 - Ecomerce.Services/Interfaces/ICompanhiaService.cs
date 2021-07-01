using System.Collections.Generic;
using System.Threading.Tasks;
using Ecomerce.Services.DTO;

namespace Ecomerce.Services.Interfaces
{
    public interface ICompanhiaService
    {
         Task<CompanhiaDTO> Create (CompanhiaDTO companhiaDTO);

         Task<CompanhiaDTO> Update(CompanhiaDTO companhiaDTO);

         Task Remove(int id);
         Task<CompanhiaDTO> Get (int id);
         Task<List<CompanhiaDTO>> Get();
    }
}