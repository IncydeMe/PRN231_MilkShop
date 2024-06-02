using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.DTOs;
using MilkData.Models;
using MilkWebAPI.Constants;

namespace MilkWebAPI.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductBusiness _productBusiness;

        public ProductController()
        {
            _productBusiness = new ProductBusiness();
        }

        [HttpGet(ApiEndPointConstant.Product.ProductsEndPoint)]
        public async Task<IActionResult> GetProductList()
        {
            var response = await _productBusiness.GetProductList();
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpGet(ApiEndPointConstant.Product.ProductEndPoint)]
        public async Task<IActionResult> GetProductById(int id)
        {
            var response = await _productBusiness.GetProductById(id);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost(ApiEndPointConstant.Product.ProductsEndPoint)]
        public async Task<IActionResult> CreateProduct(ProductDTO createProduct)
        {
            var response = await _productBusiness.CreateProduct(createProduct);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPut(ApiEndPointConstant.Product.ProductEndPoint)]
        public async Task<IActionResult> UpdateProduct(ProductDTO product)
        {
            var response = await _productBusiness.UpdateProduct(product);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpDelete(ApiEndPointConstant.Product.ProductEndPoint)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _productBusiness.DeleteProduct(id);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
