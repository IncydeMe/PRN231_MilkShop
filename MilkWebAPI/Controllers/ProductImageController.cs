using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MilkBusiness;
using MilkData.DTOs.Product;
using MilkWebAPI.Constants;
using Swashbuckle.AspNetCore.Annotations;

namespace MilkWebAPI.Controllers
{
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private ProductImageBusiness _productImageBusiness;
        public ProductImageController()
        {
            _productImageBusiness = new ProductImageBusiness();
        }

        [HttpGet(ApiEndPointConstant.ProductImage.ProductImagesEndPoint)]
        [SwaggerOperation(Summary = "Get all image of 1 Product")]
        public async Task<IActionResult> GetProductImages(int productId)
        {
            var response = await _productImageBusiness.GetProductImage(productId);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpGet(ApiEndPointConstant.ProductImage.ProductImageEndPoint)]
        [SwaggerOperation(Summary = "Get image by its id")]
        public async Task<IActionResult> GetProductImage(int id)
        {
            var response = await _productImageBusiness.GetProductImageById(id);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [HttpGet(ApiEndPointConstant.ProductImage.ProductImageByProductEndPoint)]
        [SwaggerOperation(Summary = "Get thumbnail by product id")]
        public async Task<IActionResult> GetProductThumbnail(int productId)
        {
            var response = await _productImageBusiness.GetProductThumbnail(productId);
            if (response.Status >= 0)
                return Ok(response.Data);
            else
                return BadRequest(response);
        }

        [Authorize(Roles = "staff")]
        [HttpDelete(ApiEndPointConstant.ProductImage.ProductImageEndPoint)]
        [SwaggerOperation(Summary = "Delete Image")]
        public async Task<IActionResult> DeleteProductImage(int id)
        {
            var response = await _productImageBusiness.DeleteProductImage(id);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [Authorize(Roles = "staff")]
        [HttpPost(ApiEndPointConstant.ProductImage.ProductImagesEndPoint)]
        [SwaggerOperation(Summary = "Add Image")]
        public async Task<IActionResult> AddProductImage(ProductImageDTO productImage)
        {
            var response = await _productImageBusiness.AddProductImage(productImage);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [Authorize(Roles = "staff")]
        [HttpPut(ApiEndPointConstant.ProductImage.ProductImageEndPoint)]
        [SwaggerOperation(Summary = "Update Image")]
        public async Task<IActionResult> UpdateProductImage(int id, ProductImageDTO productImage)
        {
            var response = await _productImageBusiness.UpdateProductImage(id, productImage);
            if (response.Status >= 0)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
