﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.Models;
using MilkWebAPI.Constants;

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
        public async Task<IActionResult> GetCategoryList()
        {
            var response = await _categoryBusiness.GetCategoryList();
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpGet(ApiEndPointConstant.Category.CategoryEndPoint)]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var response = await _categoryBusiness.GetCategoryById(id);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost(ApiEndPointConstant.Category.CategoriesEndPoint)]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            var response = await _categoryBusiness.CreateCategory(category);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut(ApiEndPointConstant.Category.CategoryEndPoint)]
        public async Task<IActionResult> UpdateCategory(int id, Category category)
        {
            var response = await _categoryBusiness.UpdateCategory(id, category);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpDelete(ApiEndPointConstant.Category.CategoryEndPoint)]
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