using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_Structure.App.DTO;
using WebAPI_Structure.Core.Models;

namespace WebAPI_Structure.Infra
{
    public interface ICategoryServices
    {
        Task<dynamic> GetAllCategory();
        Task<dynamic> GetCategoryById(int Id);
        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(int id, Category category);
        Task<int> DeleteCategory(int Id);

    }

}
