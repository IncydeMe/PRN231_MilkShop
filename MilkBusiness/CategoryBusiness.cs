﻿using Microsoft.EntityFrameworkCore;
using MilkData.DTOs;
using MilkData.Models;
using MilkData.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness;

public class CategoryBusiness
{
    //private readonly UnitOfWork _unitOfWork;

    //public CategoryBusiness()
    //{
    //    _unitOfWork ??= new UnitOfWork();
    //}

    //#region Category

    //public async Task<IMilkResult> CreateCategory(CategoryDTO createCategory)
    //{
    //    Category category = new Category()
    //    {
    //        ProductCategoryId = createCategory.ProductCategoryId,
    //        CategoryName = createCategory.CategoryName
    //    };

    //    await _unitOfWork.GetRepository<Category>().InsertAsync(category);
    //    var res = await _unitOfWork.CommitAsync();
    //    if (res > 0)
    //    {
    //        return new MilkResult(1, "Create category successfully", createCategory);
    //    }
    //    else
    //    {
    //        return new MilkResult();
    //    }
    //}

    //public async Task<IMilkResult> GetCategoryList()
    //{
    //    var categories = await _unitOfWork.GetRepository<Category>().GetListAsync();
    //    return new MilkResult(categories);
    //}

    //public async Task<IMilkResult> GetCategoryById(int categoryId)
    //{
    //    var category = await _unitOfWork.GetRepository<Category>().SingleOrDefaultAsync(predicate: x => x.ProductCategoryId == categoryId);
    //    return new MilkResult(category);
    //}

    //public async Task<IMilkResult> UpdateCategory(int id, CategoryDTO category)
    //{
    //    Category currentCategory = await _unitOfWork.GetRepository<Category>()
    //        .SingleOrDefaultAsync(predicate: c => c.ProductCategoryId == category.ProductCategoryId);
    //    if (currentCategory == null) return new MilkResult(-1, "Category cannot be found");
    //    else
    //    {
    //        currentCategory.CategoryName = String.IsNullOrEmpty(category.CategoryName) ? currentCategory.CategoryName : category.CategoryName;

    //        _unitOfWork.GetRepository<Category>().UpdateAsync(currentCategory);
    //        await _unitOfWork.CommitAsync();
    //    }

    //    return new MilkResult(currentCategory);
    //}

    //public async Task<IMilkResult> DeleteCategory(int id)
    //{
    //    Category category = await _unitOfWork.GetRepository<Category>().SingleOrDefaultAsync(predicate: c => c.ProductCategoryId == id);
    //    if (category == null)
    //    {
    //        return new MilkResult(0, "Category not found");
    //    }
    //    else
    //    {
    //        _unitOfWork.GetRepository<Category>().DeleteAsync(category);
    //        await _unitOfWork.CommitAsync();
    //        return new MilkResult(1, "Delete category successfully", category);
    //    }
    //}
    //#endregion
}
