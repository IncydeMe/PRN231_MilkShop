using MilkData.DTOs;
using MilkData.Models;
using MilkData.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness
{
    public class BlogBusiness
    {
        private UnitOfWork _unitOfWork;

        public BlogBusiness()
        {
            _unitOfWork = new UnitOfWork();
        }

        public async Task<IMilkResult> GetAllBlog()
        {
            var blogList = await _unitOfWork.GetRepository<Blog>().GetListAsync();
            return new MilkResult(blogList);
        }

        public async Task<IMilkResult> GetBlogInfo(int blogId)
        {
            var blog = await _unitOfWork.GetRepository<Blog>()
                .SingleOrDefaultAsync(predicate: b => b.BlogId == blogId);
            return new MilkResult(blog);
        }

        public async Task<IMilkResult> CreateBlog(BlogDTO blog)
        {
			MilkResult result = new MilkResult();

			Blog createdBlog = new Blog()
            {
                BlogId = blog.BlogId,
                BlogCategoryId = blog.BlogCategoryId,
                Title = blog.Title,
                Content = blog.Content,
                ImageUrl = blog.ImageUrl,
                ProductSuggestUrl = blog.ProductSuggestUrl,
                CreatedDate = blog.CreatedDate,
                AccountId = blog.AccountId
			};

			await _unitOfWork.GetRepository<Blog>().InsertAsync(createdBlog);
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

        public async Task<IMilkResult> UpdateBlogInfo(int id, BlogDTO blogInfo)
        {
            Blog currentBlog = await _unitOfWork.GetRepository<Blog>()
                .SingleOrDefaultAsync(predicate: b => b.BlogId == id);
            if (currentBlog == null) return new MilkResult(-1, "Blog cannot be found");
            else
            {
                currentBlog.BlogCategoryId = blogInfo.BlogCategoryId;
                currentBlog.Title = String.IsNullOrEmpty(blogInfo.Title) ? currentBlog.Title : blogInfo.Title;
                currentBlog.Content = String.IsNullOrEmpty(blogInfo.Content) ? currentBlog.Content : blogInfo.Content;
                currentBlog.ImageUrl = String.IsNullOrEmpty(blogInfo.ImageUrl) ? currentBlog.ImageUrl : blogInfo.ImageUrl;
                currentBlog.ProductSuggestUrl = String.IsNullOrEmpty(blogInfo.ProductSuggestUrl) ? currentBlog.ProductSuggestUrl : blogInfo.ProductSuggestUrl;
                currentBlog.CreatedDate = blogInfo.CreatedDate;
                currentBlog.AccountId = blogInfo.AccountId;

                _unitOfWork.GetRepository<Blog>().UpdateAsync(currentBlog);
                await _unitOfWork.CommitAsync();
            }

            return new MilkResult(blogInfo);
        }

        public async Task<IMilkResult> DeleteBlog(int blogId)
        {
            Blog blog = await _unitOfWork.GetRepository<Blog>()
                .SingleOrDefaultAsync(predicate: b=> b.BlogId == blogId);
            if (blog == null) return new MilkResult();
            else
            {
                _unitOfWork.GetRepository<Blog>().DeleteAsync(blog);
                await _unitOfWork.CommitAsync();
            }
            return new MilkResult(1, "Delete Successfull");
        }
    }
}
