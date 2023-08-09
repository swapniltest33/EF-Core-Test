using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Structure.App.DTO;
using WebAPI_Structure.Core.Models;
using WebAPI_Structure.Infra;

namespace WebAPI_Structure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
       
        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory() {

            try{ 
            var data = await _categoryServices.GetAllCategory();
                if (data.Count != 0)
                {
                    return Ok(data);
                }
                else {
                    return Ok("Null");
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDTO ct)
        {
            try { 
                var category = new Category() { 
                CategoryId = ct.CategoryId,
                CategoryName = ct.CategoryName,
                };
                //Category category = new Category();
                //category.CategoryId = ct.CategoryId;
                //category.CategoryName = ct.CategoryName;
                var tcs =await _categoryServices.AddCategory(category);
                return Ok(tcs);
            }
            catch(Exception ex)
            {
                EmptyResult result = new EmptyResult();
                return Ok(ex);
            }
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetCategoryById(int Id) {
            try
            {
                var categoryId =  await _categoryServices.GetCategoryById(Id);
                if (categoryId == null) {
                    return NotFound();
                }
                return Ok(categoryId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }

      
        [HttpPost]
        [Route("{Id}")]
        public async Task<IActionResult> UpdateCategory(int Id, CategoryDTO ct)
        {
            try
            {
                var category = new Category()
                {
                    CategoryId = ct.CategoryId,
                    CategoryName = ct.CategoryName,
                };
                var categoryinfo = await _categoryServices.UpdateCategory(Id, category);
                return Ok(categoryinfo);
            }
            catch (Exception ex)
            {
                return Ok(ex);
                throw;
            }

        }
    }
}
