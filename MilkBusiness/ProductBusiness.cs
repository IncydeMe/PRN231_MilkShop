﻿using Microsoft.EntityFrameworkCore;
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
            Product product = new Product
            {
                ProductId = createProduct.ProductId,
                Name = createProduct.Name,
                Description = createProduct.Description,
                ImageUrl = createProduct.ImageUrl,
                Quantity = createProduct.Quantity,
                Price = createProduct.Price,
                CategoryId = createProduct.CategoryId
            };

            await _unitOfWork.GetRepository<Product>().InsertAsync(product);

            MilkResult result = new MilkResult();
            bool status = await _unitOfWork.CommitAsync() > 0;
            if (status)
            {
                result.Data = GetProductById(product.ProductId);
                result.Status = 1;
                result.Message = "Create product successfully";
            }
            else
            {
                result.Status = -1;
                result.Message = "Create product failed";
            }
            return result;
        }

        public async Task<IMilkResult> GetProductList()
        {
            var products = await _unitOfWork.GetRepository<Product>().GetListAsync();
            return new MilkResult(products);
        }

        public async Task<IMilkResult> GetProductById(int productId)
        {
            var product = _unitOfWork.GetRepository<Product>().GetListAsync().Result.Where(x => x.ProductId == productId);
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
                currentProduct.CategoryId = product.CategoryId;
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
