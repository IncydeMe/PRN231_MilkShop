using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.DTOs;
using MilkData.Models;
using MilkWebAPI.Constants;
using Swashbuckle.AspNetCore.Annotations;

namespace MilkWebAPI.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryBusiness _categoryBusiness;

        public CategoryController()
        {
            _categoryBusiness = new CategoryBusiness();
        }

        [HttpGet(ApiEndPointConstant.Category.CategoriesEndPoint)]
        [SwaggerOperation(Summary = "Get all Categories")]
        public async Task<IActionResult> GetCategoryList()
        {
            var response = await _categoryBusiness.GetCategoryList();
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpGet(ApiEndPointConstant.Category.CategoryEndPoint)]
        [SwaggerOperation(Summary = "Get Category by its id")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var response = await _categoryBusiness.GetCategoryById(id);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpPost(ApiEndPointConstant.Category.CategoriesEndPoint)]
        [SwaggerOperation(Summary = "Create a new Category")]
        public async Task<IActionResult> CreateCategory(CategoryDTO createCategory)
        {
            var response = await _categoryBusiness.CreateCategory(createCategory);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut(ApiEndPointConstant.Category.CategoryEndPoint)]
        [SwaggerOperation(Summary = "Update Category Info")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryDTO category)
        {
            var response = await _categoryBusiness.UpdateCategory(id, category);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpDelete(ApiEndPointConstant.Category.CategoryEndPoint)]
        [SwaggerOperation(Summary = "Delete Category")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var response = await _categoryBusiness.DeleteCategory(id);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }


    }
}
