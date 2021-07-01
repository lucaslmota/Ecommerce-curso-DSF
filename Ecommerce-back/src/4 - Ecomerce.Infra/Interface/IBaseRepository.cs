using System.Collections.Generic;
using System.Threading.Tasks;
using Ecomerce.Domain.Entities;

namespace Ecomerce.Infra.Interface
{
    public interface IBaseRepository<T> where T : Base
    {
         Task<T> Create(T obj);
         Task<T> Updade(T obj);
         Task Remove(int id);
         Task<T> Get(int id);
         Task<List<T>> Get();
    }
}