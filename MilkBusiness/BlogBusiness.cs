using Microsoft.EntityFrameworkCore;
using MilkData.DTOs.Blog;
using MilkData.Models;
using MilkData.Repository.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var blogList = await _unitOfWork.GetRepository<Blog>().GetListAsync(
                include: x => x.Include(b => b.BlogCategory),
                selector: x => new GetBlogDTO
                {
                    BlogId = x.BlogId,
                    BlogCategoryName = x.BlogCategory.Name,
                    AccountId = x.AccountId,
                    CreatedAt = x.CreatedAt,
                    DocUrl = x.DocUrl,
                    ImageUrl = x.ImageUrl,
                    Title = x.Title,
                    UpdatedAt = x.UpdatedAt 
                });
            return new MilkResult(blogList);
        }

        public async Task<IMilkResult> GetBlogInfo(int blogId)
        {
            var blog = await _unitOfWork.GetRepository<Blog>()
                .SingleOrDefaultAsync(predicate: b => b.BlogId == blogId,
                                      include: x => x.Include(b => b.BlogCategory),
                                      selector: x => new GetBlogDTO
                                      {
                                          BlogId = x.BlogId,
                                          BlogCategoryName = x.BlogCategory.Name,
                                          AccountId = x.AccountId,
                                          CreatedAt = x.CreatedAt,
                                          DocUrl = x.DocUrl,
                                          ImageUrl = x.ImageUrl,
                                          Title = x.Title,
                                          UpdatedAt = x.UpdatedAt
                                      });
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
                DocUrl = blog.DocUrl,
                ImageUrl = blog.ImageUrl,
                CreatedAt = blog.CreatedAt,
                UpdatedAt = blog.UpdatedAt,
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
                currentBlog.DocUrl = String.IsNullOrEmpty(blogInfo.DocUrl) ? currentBlog.DocUrl : blogInfo.DocUrl;
                currentBlog.ImageUrl = String.IsNullOrEmpty(blogInfo.ImageUrl) ? currentBlog.ImageUrl : blogInfo.ImageUrl;
                currentBlog.CreatedAt = blogInfo.CreatedAt;
                currentBlog.UpdatedAt = blogInfo.UpdatedAt;
                currentBlog.AccountId = blogInfo.AccountId;

                _unitOfWork.GetRepository<Blog>().UpdateAsync(currentBlog);
                await _unitOfWork.CommitAsync();
            }

            return new MilkResult(blogInfo);
        }

        public async Task<IMilkResult> DeleteBlog(int blogId)
        {
            Blog blog = await _unitOfWork.GetRepository<Blog>()
                .SingleOrDefaultAsync(predicate: b => b.BlogId == blogId);
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
