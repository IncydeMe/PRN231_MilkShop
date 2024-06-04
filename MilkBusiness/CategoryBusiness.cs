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
    public class CategoryBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public CategoryBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        #region Category

        public async Task<IMilkResult> CreateCategory(CategoryDTO createCategory)
        {
            Category category = new Category
            {
                CategoryName = createCategory.CategoryName,
            };

            await _unitOfWork.GetRepository<Category>().InsertAsync(category);

            MilkResult result = new MilkResult();
            bool status = await _unitOfWork.CommitAsync() > 0;
            if (status)
            {
                result.Data = GetCategoryById(category.CategoryId);
                result.Status = 1;
                result.Message = "Create category successfully";
            }
            else
            {
                result.Status = -1;
                result.Message = "Create category failed";
            }
            return result;
        }

        public async Task<IMilkResult> GetCategoryList()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetListAsync();
            return new MilkResult(categories);
        }

        public async Task<IMilkResult> GetCategoryById(int categoryId)
        {
            var category = _unitOfWork.GetRepository<Category>().GetListAsync().Result.Where(x => x.CategoryId == categoryId);
            return new MilkResult(category);
        }

        //public async Task<IMilkResult> UpdateCategory(int id, Category category)
        //{
        //    _unitOfWork.GetRepository<Category>().UpdateAsync(category);
        //    await _unitOfWork.CommitAsync();
        //    return new MilkResult(1, "Update category successfully", category);
        //}

        public async Task<IMilkResult> DeleteCategory(int id)
        {
            Category category = await _unitOfWork.GetRepository<Category>().SingleOrDefaultAsync(predicate: c => c.CategoryId == id);
            if (category == null)
            {
                return new MilkResult(0, "Category not found");
            }
            else
            {
                _unitOfWork.GetRepository<Category>().DeleteAsync(category);
                await _unitOfWork.CommitAsync();
                return new MilkResult(1, "Delete category successfully", category);
            }
        }
    }
    #endregion

}
