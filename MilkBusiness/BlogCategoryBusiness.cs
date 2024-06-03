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
    public class BlogCategoryBusiness
    {
        private UnitOfWork _unitOfWork;

        public BlogCategoryBusiness()
        {
            _unitOfWork = new UnitOfWork();
        }

        public async Task<IMilkResult> GetAllBlogCategory()
        {
            var blogCategoryList = await _unitOfWork.GetRepository<BlogCategory>().GetListAsync();
            return new MilkResult(blogCategoryList);
        }

        public async Task<IMilkResult> GetBlogInfo(int blogCategoryId)
        {
            var blogCategory = await _unitOfWork.GetRepository<BlogCategory>()
                .SingleOrDefaultAsync(predicate: bc => bc.BlogCategoryId == blogCategoryId);
            return new MilkResult(blogCategory);
        }

        public async Task<IMilkResult> UpdateBlogCategoryInfo(int id, BlogCategoryDTO blogCategoryInfo)
        {
            BlogCategory currentBlog = await _unitOfWork.GetRepository<BlogCategory>()
                .SingleOrDefaultAsync(predicate: bc => bc.BlogCategoryId == id);
            if (currentBlog == null) return new MilkResult(-1, "Blog Category cannot be found");
            else
            {
                currentBlog.BlogCategoryName = String.IsNullOrEmpty(blogCategoryInfo.BlogCategoryName) ? currentBlog.BlogCategoryName : blogCategoryInfo.BlogCategoryName;

                _unitOfWork.GetRepository<BlogCategory>().UpdateAsync(currentBlog);
                await _unitOfWork.CommitAsync();
            }

            return new MilkResult(blogCategoryInfo);
        }

        public async Task<IMilkResult> DeleteBlogCategory(int blogCategoryId)
        {
            BlogCategory blogCategory = await _unitOfWork.GetRepository<BlogCategory>()
                .SingleOrDefaultAsync(predicate: bc => bc.BlogCategoryId == blogCategoryId);
            if (blogCategory == null) return new MilkResult();
            else
            {
                _unitOfWork.GetRepository<BlogCategory>().DeleteAsync(blogCategory);
                await _unitOfWork.CommitAsync();
            }
            return new MilkResult(1, "Delete Successfull");
        }

        public async Task<IMilkResult> CreateBlogCategory(BlogCategoryDTO blogCategory)
        {
            MilkResult result = new MilkResult();

            BlogCategory newCategory = new BlogCategory()
            {
                BlogCategoryId = blogCategory.BlogCategoryId,
                BlogCategoryName = blogCategory.BlogCategoryName
            };

            await _unitOfWork.GetRepository<BlogCategory>().InsertAsync(newCategory);
            bool isSuccessful = await _unitOfWork.CommitAsync() > 0;

            if (!isSuccessful)
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
