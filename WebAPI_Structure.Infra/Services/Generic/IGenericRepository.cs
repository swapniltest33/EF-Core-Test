using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI_Structure.Infra.Services.Generic
{
    public interface IGenericRepository <T> where T : class, new ()
    {
        Task<IQueryable<T>> GetAll();

        Task<T> GetById(long id);

        Task Create(T entity);

        Task Update(int id, T entity);

        Task Delete(int id);
    }
}
