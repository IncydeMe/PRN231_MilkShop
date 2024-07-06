using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.DTOs;
using MilkData.Models;
using MilkWebAPI.Constants;
using Swashbuckle.AspNetCore.Annotations;

namespace MilkWebAPI.Controllers;

[ApiController]
public class BlogCategoryController : ControllerBase
{
    private BlogCategoryBusiness _blogCategoryBusiness;

    public BlogCategoryController()
    {
        _blogCategoryBusiness = new BlogCategoryBusiness();
    }

    [HttpGet(ApiEndPointConstant.BlogCategory.BlogCategoriesEndpoint)]
    [SwaggerOperation(Summary = "Get all Blog Categories")]
    public async Task<IActionResult> GetAllBlogCategoriess()
    {
        var response = await _blogCategoryBusiness.GetAllBlogCategory();
        if (response.Status >= 0)
            return Ok(response.Data);
        else
            return BadRequest(response);
    }

    [HttpGet(ApiEndPointConstant.BlogCategory.BlogCategoryEndpoint)]
    [SwaggerOperation(Summary = "Get Blog Category by its id")]
    public async Task<IActionResult> GetBlogCategoryInfo(int id)
    {
        var response = await _blogCategoryBusiness.GetBlogInfo(id);
        if (response.Status >= 0)
            return Ok(response.Data);
        else
            return BadRequest(response);
    }

    [HttpPut(ApiEndPointConstant.BlogCategory.BlogCategoryEndpoint)]
    public async Task<IActionResult> UpdateBlogCategoryInfo(int id, BlogCategoryDTO blogCategory)
    {
        var response = await _blogCategoryBusiness.UpdateBlogCategoryInfo(id, blogCategory);
        if (response.Status >= 0)
            return Ok(response);
        else
            return BadRequest(response);
    }

    [HttpDelete(ApiEndPointConstant.BlogCategory.BlogCategoryEndpoint)]
    public async Task<IActionResult> DeleteBlogCategory(int id)
    {
        var response = await _blogCategoryBusiness.DeleteBlogCategory(id);
        if (response.Status >= 0)
            return Ok(response);
        else
            return BadRequest(response);
    }

    [HttpPost(ApiEndPointConstant.BlogCategory.BlogCategoriesEndpoint)]
    [SwaggerOperation(Summary = "Create a new Blog Category")]
    public async Task<IActionResult> CreateBlogCategory(BlogCategoryDTO blogCategory)
    {
        var response = await _blogCategoryBusiness.CreateBlogCategory(blogCategory);
        if (response.Status >= 0)
            return Ok(response);
        else
            return BadRequest(response);
    }
}
