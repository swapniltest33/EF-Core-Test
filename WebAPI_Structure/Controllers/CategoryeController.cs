using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Structure.App.DTO;
using WebAPI_Structure.Core.Models;
using WebAPI_Structure.Infra;
using WebAPI_Structure.Infra.Services.Generic;

namespace WebAPI_Structure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryeController : ControllerBase
    {
        private IGenericRepository<Category> _categoryRepository;

        public CategoryeController(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("GetCategory")]
        public async Task<ActionResult<IQueryable<Category>>> GetAllCategory() {

            return Ok(await _categoryRepository.GetAll());
        }

        [HttpGet]
        [Route("GetCategorybyID/{Id}")]
        public async Task<ActionResult<Category>> GetCategoryById(long Id)
        {

            return Ok(await _categoryRepository.GetById(Id));
        }

        [HttpPost]
        [Route("AddCategory")]
        [AllowAnonymous]
        public async Task<IActionResult>AddCategory(CategoryDTO ct) {
            try
            { 
                var category = new Category() 
                {
                CategoryId = ct.CategoryId,
                CategoryName = ct.CategoryName
                };
                if (category != null)
                {
                    await _categoryRepository.Create(category);
                 
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
               return BadRequest(ex);
            }
     
        }
    }
}
