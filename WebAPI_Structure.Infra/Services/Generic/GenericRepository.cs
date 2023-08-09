using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_Structure.Core.Models;

namespace WebAPI_Structure.Infra.Services.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
       // private readonly DemoDBContext _context;
        private readonly TestDBContext _context;
        private readonly DbSet<T> _entities;
        public GenericRepository(TestDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
        }
        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            //throw new NotImplementedException();
        }

        public async Task <IQueryable<T>> GetAll()
        {
            return _context.Set<T>().AsNoTracking();
            //throw new NotImplementedException();
        }

        public async Task<T> GetById(long id)
        {
            //return await _context.Set<T>()
            //    .AsNoTracking()
            //    .SingleOrDefaultAsync(s => s.Id == id);
            //throw new NotImplementedException();
            return  await _context.Set<T>().FindAsync(id);
        }

        public async Task Update(int id, T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            throw new NotImplementedException();
        }
    }
}
