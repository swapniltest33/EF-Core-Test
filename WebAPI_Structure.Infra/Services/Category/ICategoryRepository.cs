using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI_Structure.Core.Models;
using WebAPI_Structure.Infra.Services.Generic;

namespace WebAPI_Structure.Infra
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetCoolestCategory();
    }
}
