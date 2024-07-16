using MilkData.DTOs.ProductCategory;
using MilkData.Models;
using MilkData.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness
{
    public class CategoryBusiness
    {
        private UnitOfWork _unitOfWork;
        public CategoryBusiness()
        {
            _unitOfWork = new UnitOfWork();
        }

        //Get all categories
        public async Task<IMilkResult> GetAllCategory()
        {
            var categoryList = await _unitOfWork.GetRepository<Category>().GetListAsync();
            return new MilkResult(categoryList);
        }

        //Get category by id
        public async Task<IMilkResult> GetCategoryInfo(int categoryId)
        {
            var category = await _unitOfWork.GetRepository<Category>()
                .SingleOrDefaultAsync(predicate: c => c.CategoryId == categoryId);
            return new MilkResult(category);
        }

        //Update category info
        public async Task<IMilkResult> UpdateCategoryInfo(int id, CategoryDTO categoryInfo)
        {
            Category currentCategory = await _unitOfWork.GetRepository<Category>()
                .SingleOrDefaultAsync(predicate: c => c.CategoryId == id);
            if (currentCategory == null) return new MilkResult(-1, "Category cannot be found");
            else
            {
                currentCategory.CategoryName = String.IsNullOrEmpty(categoryInfo.Name) ? currentCategory.CategoryName : categoryInfo.Name;
                _unitOfWork.GetRepository<Category>().UpdateAsync(currentCategory);
                await _unitOfWork.CommitAsync();
            }
            return new MilkResult(categoryInfo);
        }

        //Delete category
        public async Task<IMilkResult> DeleteCategory(int categoryId)
        {
            Category category = await _unitOfWork.GetRepository<Category>()
                .SingleOrDefaultAsync(predicate: c => c.CategoryId == categoryId);
            if (category == null) return new MilkResult();
            else
            {
                _unitOfWork.GetRepository<Category>().DeleteAsync(category);
                await _unitOfWork.CommitAsync();
            }
            return new MilkResult(1, "Delete Successfull");
        }

        //Create category
        public async Task<IMilkResult> CreateCategory(CategoryDTO category)
        {
            MilkResult result = new MilkResult();
            Category newCategory = new Category
            {
                CategoryId = category.CategoryId,
                CategoryName = category.Name
            };
            await _unitOfWork.GetRepository<Category>().InsertAsync(newCategory);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;

            if(!isSuccessful)
            {
                result.Status = -1;
                result.Message = "Create unsuccessfully";
            }
            else
            {
                result = new MilkResult(1, "Create Susscessfull");
            }
            return result;
        }

    }
}
