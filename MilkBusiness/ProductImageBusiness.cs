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
    public class ProductImageBusiness
    {
        private UnitOfWork _unitOfWork;
        public ProductImageBusiness()
        {
            _unitOfWork = new UnitOfWork();
        }
        public async Task<IMilkResult> GetProductImage(int productId)
        {
            var productImage = await _unitOfWork.GetRepository<ProductImage>()
                .GetListAsync(predicate: p => p.ProductId == productId,
                                   selector: x => new ProductImageDTO
                                   {
                                       ImageId = x.ImageId,
                                       ProductId = x.ProductId,
                                       Url = x.Url,
                                       IsThumbnail = x.IsThumbnail
                                   });
            return new MilkResult(productImage);
        }

        public async Task<IMilkResult> GetProductThumbnail(int productId)
        {
            var productThumbnail = await _unitOfWork.GetRepository<ProductImage>()
                .SingleOrDefaultAsync(predicate: p => p.ProductId == productId && p.IsThumbnail == true,
                                                  selector: x => new ProductImageDTO
                                                  {
                                       ImageId = x.ImageId,
                                       ProductId = x.ProductId,
                                       Url = x.Url,
                                       IsThumbnail = x.IsThumbnail
                                   });
            return new MilkResult(productThumbnail);
        }

        public async Task<IMilkResult> GetProductImageById(int imageId)
        {
            var productImage = await _unitOfWork.GetRepository<ProductImage>()
                .SingleOrDefaultAsync(predicate: p => p.ImageId == imageId,
                                                                 selector: x => new ProductImageDTO
                                                                 {
                                       ImageId = x.ImageId,
                                       ProductId = x.ProductId,
                                       Url = x.Url,
                                       IsThumbnail = x.IsThumbnail
                                   });
            return new MilkResult(productImage);
        }

        public async Task<IMilkResult> AddProductImage(ProductImageDTO productImageDTO)
        {
            MilkResult result = new MilkResult();
            var productImage = new ProductImage
            {
                ImageId = productImageDTO.ImageId,
                ProductId = productImageDTO.ProductId,
                Url = productImageDTO.Url,
                IsThumbnail = productImageDTO.IsThumbnail
            };
            await _unitOfWork.GetRepository<ProductImage>().InsertAsync(productImage);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;
            if (!isSuccessful)
            {
                result.Status = -1;
                result.Message = "Add product image failed";
            }
            else
            {
                result = new MilkResult(1, "Add successfully");
            }

            return result;
        }

        public async Task<IMilkResult> UpdateProductImage(int id, ProductImageDTO productImageDTO)
        {
            ProductImage currentImage = await _unitOfWork.GetRepository<ProductImage>()
                .SingleOrDefaultAsync(predicate: p => p.ImageId == id);
            if (currentImage == null)
            {
                return new MilkResult(-1, "Image not found");
            }
            else
            {
                currentImage.ProductId = productImageDTO.ProductId;
                currentImage.Url = productImageDTO.Url;
                currentImage.IsThumbnail = productImageDTO.IsThumbnail;

                _unitOfWork.GetRepository<ProductImage>().UpdateAsync(currentImage);
                await _unitOfWork.CommitAsync();
            }
            return new MilkResult(productImageDTO);
        }

        public async Task<IMilkResult> DeleteProductImage(int imageId)
        {
            MilkResult result = new MilkResult();
            var productImage = await _unitOfWork.GetRepository<ProductImage>()
                .SingleOrDefaultAsync(predicate: p => p.ImageId == imageId);
            if (productImage == null)
            {
                return new MilkResult(-1, "Image not found");
            }
            _unitOfWork.GetRepository<ProductImage>().DeleteAsync(productImage);
            await _unitOfWork.CommitAsync();
            return new MilkResult(1, "Delete successfully");
        }
    }
}
