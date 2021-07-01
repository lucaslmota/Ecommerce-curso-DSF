using Ecomerce.Domain.Entities;

namespace Ecomerce.Infra.Interface
{
    public interface ICompanhiaRepository : IBaseRepository<Companhia>
    {
         //Vou ter que implementar o Get por ID provavelmente na Service
    }
}