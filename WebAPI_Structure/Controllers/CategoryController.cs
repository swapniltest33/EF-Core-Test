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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }
        [Authorize]
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
        public async Task<IActionResult> AddCategory(Category ct)
        {
            try { 
                var tcs =await _categoryServices.AddCategory(ct);
                return Ok(tcs);
            }
            catch(Exception ex)
            {
                EmptyResult result = new EmptyResult();
                return Ok(ex);
            }
        }
    }
}
