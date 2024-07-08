using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MilkData.DTOs.Product;
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
        private UnitOfWork _unitOfWork;
        public ProductBusiness()
        {
            _unitOfWork = new UnitOfWork();
        }
        public async Task<IMilkResult> GetAllProduct()
        {
            var productList = await _unitOfWork.GetRepository<Product>().GetListAsync(
                               include: x => x.Include(p => p.Category),
                                              selector: x => new GetProductDTO
                                              {
                                                  ProductId = x.ProductId,
                                                  AccountId = x.AccountId,
                                                  CategoryName = x.Category.Name,
                                                  Name = x.Name,
                                                  Price = x.Price,
                                                  QuantityInStock = x.QuantityInStock,
                                                  Description = x.Description,
                                                  Status = x.Status,
                                                  CreatedAt = x.CreatedAt,
                                                  UpdatedAt = x.UpdatedAt,
                                                  TotalRating = x.TotalRating
                                              });
            return new MilkResult(productList);
        }

        public async Task<IMilkResult> GetProductInfo(int productId)
        {
            var product = await _unitOfWork.GetRepository<Product>()
                .SingleOrDefaultAsync(predicate: p => p.ProductId == productId,
                                                     include: x => x.Include(p => p.Category),
                                                                                          selector: x => new GetProductDTO
                                                                                          {
                                                                                              ProductId = x.ProductId,
                                                                                              AccountId = x.AccountId,
                                                                                              CategoryName = x.Category.Name,
                                                                                              Name = x.Name,
                                                                                              Price = x.Price,
                                                                                              QuantityInStock = x.QuantityInStock,
                                                                                              Description = x.Description,
                                                                                              Status = x.Status,
                                                                                              CreatedAt = x.CreatedAt,
                                                                                              UpdatedAt = x.UpdatedAt,
                                                                                              TotalRating = x.TotalRating
                                                                                          });
            return new MilkResult(product);
        }

        public async Task<IMilkResult> CreateProduct(ProductDTO product)
        {
            MilkResult result = new MilkResult();

            // Validate price (ensure non-negative)
            if (product.Price < 0)
            {
                return new MilkResult(-2, "Price cannot be negative");
            }

            Product newProduct = new Product()
            {
                ProductId = product.ProductId,
                AccountId = product.AccountId,
                CategoryId = product.CategoryId,
                Name = product.Name,
                Price = product.Price,
                QuantityInStock = product.QuantityInStock,
                Description = product.Description,
                Status = product.QuantityInStock > 0 ? "InStock" : "OutOfStock", // Assuming valid string values
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                TotalRating = 0
            };

            await _unitOfWork.GetRepository<Product>().InsertAsync(newProduct);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;

            if (!isSuccessful)
            {
                result.Status = -1;
                result.Message = "Create product failed";
            }
            else
            {
                result = new MilkResult(1, "Create successfully");
            }

            return result;
        }


        public async Task<IMilkResult> UpdateProductInfo(int id, ProductDTO productInfo)
        {
            Product currentProduct = await _unitOfWork.GetRepository<Product>()
                .SingleOrDefaultAsync(predicate: p => p.ProductId == id);

            if (currentProduct == null)
            {
                return new MilkResult(-1, "Product not found");
            }
            else
            {
                // Validate price (ensure non-negative)
                if (productInfo.Price < 0)
                {
                    return new MilkResult(-2, "Price cannot be negative");
                }

                currentProduct.CategoryId = productInfo.CategoryId;
                currentProduct.Name = String.IsNullOrEmpty(productInfo.Name) ? currentProduct.Name : productInfo.Name;
                currentProduct.Price = productInfo.Price;

                // Update quantity and status (handle out-of-stock)
                currentProduct.QuantityInStock = productInfo.QuantityInStock;
                currentProduct.Status = productInfo.QuantityInStock > 0 ? "InStock" : "OutOfStock"; 

                currentProduct.Description = String.IsNullOrEmpty(productInfo.Description) ? currentProduct.Description : productInfo.Description;
                currentProduct.UpdatedAt = DateTime.Now;
                currentProduct.AccountId = productInfo.AccountId;

                _unitOfWork.GetRepository<Product>().UpdateAsync(currentProduct);
                await _unitOfWork.CommitAsync();
            }

            return new MilkResult(productInfo);
        }

        public async Task<IMilkResult> DeleteProduct(int productId)
        {
            Product product = await _unitOfWork.GetRepository<Product>()
                .SingleOrDefaultAsync(predicate: p => p.ProductId == productId);
            if (product == null) return new MilkResult();
            else
            {
                _unitOfWork.GetRepository<Product>().DeleteAsync(product);
                await _unitOfWork.CommitAsync();
            }
            return new MilkResult(1, "Delete successfully");
        }
    }
}
