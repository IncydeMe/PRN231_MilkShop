using Microsoft.EntityFrameworkCore;
using MilkData.DTOs;
using MilkData.Models;
using MilkData.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness
{
    public class ProductBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        #region Product

        public async Task<IMilkResult> CreateProduct(ProductDTO createProduct)
        {
            Product product = new Product()
            {
                ProductId = createProduct.ProductId,
                Name = createProduct.Name,
                Description = createProduct.Description,
                ImageUrl = createProduct.ImageUrl,
                Quantity = createProduct.Quantity,
                Price = createProduct.Price,
                ProductCategoryId = createProduct.ProductCategoryId,
                TotalRating = createProduct.TotalRating,
            };

            await _unitOfWork.GetRepository<Product>().InsertAsync(product);
            var res = await _unitOfWork.CommitAsync();
            if (res > 0)
            {
                return new MilkResult(1, "Create product successfully", createProduct);
            }
            else
            {
                return new MilkResult();
            }


        }

        public async Task<IMilkResult> GetProductList()
        {
            var products = await _unitOfWork.GetRepository<Product>().GetListAsync();
            return new MilkResult(products);
        }

        public async Task<IMilkResult> GetProductById(int productId)
        {
            var product = await _unitOfWork.GetRepository<Product>().SingleOrDefaultAsync(predicate: p => p.ProductId == productId);
            return new MilkResult(product);
        }

        public async Task<IMilkResult> UpdateProduct(ProductDTO product)
        {
            Product currentProduct = await _unitOfWork.GetRepository<Product>()
                            .SingleOrDefaultAsync(predicate: p => p.ProductId == product.ProductId);
            if (currentProduct == null) return new MilkResult(-1, "Product cannot be found");
            else
            {
                currentProduct.Name = String.IsNullOrEmpty(product.Name) ? currentProduct.Name : product.Name;
                currentProduct.Price = product.Price;
                currentProduct.Quantity = product.Quantity;
                currentProduct.Description = String.IsNullOrEmpty(product.Description) ? currentProduct.Description : product.Description;
                currentProduct.ProductCategoryId = product.ProductCategoryId;
                currentProduct.ImageUrl = String.IsNullOrEmpty(product.ImageUrl) ? currentProduct.ImageUrl : product.ImageUrl;
                currentProduct.TotalRating = product.TotalRating;

                _unitOfWork.GetRepository<Product>().UpdateAsync(currentProduct);
                await _unitOfWork.CommitAsync();
            }

            return new MilkResult(currentProduct);
        }

        public async Task<IMilkResult> DeleteProduct(int id)
        {
            Product product = await _unitOfWork.GetRepository<Product>().SingleOrDefaultAsync(predicate: c => c.ProductId == id);
            if (product == null)
            {
                return new MilkResult(-1, "Product not found");
            }
            else
            {
                _unitOfWork.GetRepository<Product>().DeleteAsync(product);
                await _unitOfWork.CommitAsync();
                return new MilkResult(1, "Delete product successfully");
            }
        }

    }
    #endregion
}
