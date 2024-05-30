using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.Models;
using MilkWebAPI.Constants;

namespace MilkWebAPI.Controllers
{
    [ApiController]
    public class BlogCategoryController : ControllerBase
    {
        private BlogCategoryBusiness _blogCategoryBusiness;

        public BlogCategoryController()
        {
            _blogCategoryBusiness = new BlogCategoryBusiness();
        }

        [HttpGet(ApiEndPointConstant.BlogCategory.BlogCategorysEndpoint)]
        public async Task<IActionResult> GetAllBlogCategoriess()
        {
            var response = await _blogCategoryBusiness.GetAllBlogCategory();
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpGet(ApiEndPointConstant.BlogCategory.BlogCategoryEndpoint)]
        public async Task<IActionResult> GetBlogCategoryInfo(int id)
        {
            var response = await _blogCategoryBusiness.GetBlogInfo(id);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut(ApiEndPointConstant.BlogCategory.BlogCategorysEndpoint)]
        public async Task<IActionResult> UpdateAccountInfo(int id, [FromBody] BlogCategory blogCategory)
        {
            var response = await _blogCategoryBusiness.UpdateBlogCategoryInfo(id, blogCategory);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpDelete(ApiEndPointConstant.Blog.BlogEndpoint)]
        public async Task<IActionResult> BanAccount(int id)
        {
            var response = await _blogCategoryBusiness.DeleteBlogCategory(id);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
