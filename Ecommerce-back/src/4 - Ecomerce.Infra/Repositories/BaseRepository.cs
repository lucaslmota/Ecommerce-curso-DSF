using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecomerce.Domain.Entities;
using Ecomerce.Infra.Context;
using Ecomerce.Infra.Interface;
using Microsoft.EntityFrameworkCore;

namespace Ecomerce.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly EcomerceContext _context;
        public BaseRepository(EcomerceContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Create(T obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }
         public virtual async Task<T> Updade(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return obj;
        }
        public virtual async Task Remove(int id)
        {
            var obj = await Get(id);
            
            if(obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<T> Get(int id)
        {
            var obj = await _context.Set<T>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .ToListAsync();
            
            return obj.FirstOrDefault();
        }

        public virtual async Task<List<T>> Get()
        {
            return await _context.Set<T>()
                                  .AsNoTracking()
                                  .ToListAsync();
        }

        

       
    }
}