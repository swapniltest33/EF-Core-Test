using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebAPI_Structure.App.DTO;
using WebAPI_Structure.Core.Models;

namespace WebAPI_Structure.Infra
{ 
    internal class CategoryServices : ICategoryServices
    {
        //private readonly DemoDBContext _context;
       private readonly TestDBContext _context;
        public CategoryServices(TestDBContext context)
        {
            _context = context;
        }

        public async Task<Category> AddCategory(Category xer)
        {
            var abc = _context.Category.Add(xer);
            await _context.SaveChangesAsync();
            return abc.Entity;
        }

        //public Task<Core.Models.Category> AddCategory(Core.Models.Category category)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<int> DeleteCategory(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<dynamic> GetAllCategory()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<dynamic> GetCategoryById(int Id)
        {
            var abc = await _context.Category.Where(x => x.CategoryId == Id).SingleOrDefaultAsync();
            //return await _context.Category.Where(x => x.CategoryId == x.CategoryId).FirstOrDefault();
            return abc;
        }

        public async Task<Category> UpdateCategory(int Id ,Category category)
        {
           var Category =  await _context.Category.Where(x => x.CategoryId == Id).SingleOrDefaultAsync();

            if (category != null) {
                Category.CategoryName = category.CategoryName;
                await _context.SaveChangesAsync();
                
            }
            return Category;
        }

    }
}
