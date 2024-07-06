using MilkData.DTOs;
using MilkData.Models;
using MilkData.Repository.Implements;

namespace MilkBusiness;

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

        Blog createBlog = new Blog()
        {
            BlogId = blog.BlogId,
            BlogCategoryId = blog.BlogCategoryId,
            AccountId = blog.AccountId,
            Title = blog.Title,
            DocUrl = blog.DocUrl,
            ImageUrl = string.IsNullOrEmpty(blog.ImageUrl) ? "" : blog.ImageUrl,
            CreatedAt = DateTime.Now
        };

        await _unitOfWork.GetRepository<Blog>().InsertAsync(createBlog);
        bool isSuccessful = await _unitOfWork.CommitAsync() > 0;

        if (!isSuccessful)
        {
            result.Status = -1;
            result.Message = "Create unsuccessfully";
        }
        else
        {
            result = new MilkResult(200, "Create Susscessfull", createBlog);
        }

        return result;
    }

    public async Task<IMilkResult> UpdateBlogInfo(int id, BlogDTO blogInfo)
    {
        Blog currentBlog = await _unitOfWork.GetRepository<Blog>()
            .SingleOrDefaultAsync(predicate: b => b.BlogId == id);
        if (currentBlog == null)
            return new MilkResult(-1, "Blog cannot be found");
        else
        {
            currentBlog.BlogCategoryId = blogInfo.BlogCategoryId;
            currentBlog.Title = string.IsNullOrEmpty(blogInfo.Title) ? currentBlog.Title : blogInfo.Title;
            currentBlog.DocUrl = string.IsNullOrEmpty(blogInfo.DocUrl) ? currentBlog.DocUrl : blogInfo.DocUrl;
            currentBlog.ImageUrl = string.IsNullOrEmpty(blogInfo.ImageUrl) ? currentBlog.ImageUrl : blogInfo.ImageUrl;
            currentBlog.UpdatedAt = DateTime.Now;

            _unitOfWork.GetRepository<Blog>().UpdateAsync(currentBlog);
            await _unitOfWork.CommitAsync();
        }

        return new MilkResult(201, "Update Successfull", blogInfo);
    }

    public async Task<IMilkResult> DeleteBlog(int blogId)
    {
        Blog blog = await _unitOfWork.GetRepository<Blog>()
            .SingleOrDefaultAsync(predicate: b => b.BlogId == blogId);
        if (blog == null)
            return new MilkResult();
        else
        {
            _unitOfWork.GetRepository<Blog>().DeleteAsync(blog);
            await _unitOfWork.CommitAsync();
        }
        return new MilkResult(202, "Delete Successfull");
    }
}
