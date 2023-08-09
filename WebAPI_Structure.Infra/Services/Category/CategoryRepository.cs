using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_Structure.Core.Models;
using WebAPI_Structure.Infra.Services.Generic;

namespace WebAPI_Structure.Infra
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        //private readonly ICategoryRepository _categoryRepository;
        public CategoryRepository(TestDBContext context) : base(context)
        {
            
        }
        //public async Task<Category> GetCoolestCategory()
        //{
        //    return await GetAll();
        //}
    }
}
