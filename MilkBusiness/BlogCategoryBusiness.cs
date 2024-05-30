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

        public async Task<IMilkResult> UpdateBlogCategoryInfo(int id, BlogCategory blogCategoryInfo)
        {
            BlogCategory currentBlog = await _unitOfWork.GetRepository<BlogCategory>()
                .SingleOrDefaultAsync(predicate: bc => bc.BlogCategoryId == id);
            if (currentBlog == null) return new MilkResult(-1, "Blog Category cannot be found");
            else
            {
                _unitOfWork.GetRepository<BlogCategory>().UpdateAsync(blogCategoryInfo);
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
    }
}
