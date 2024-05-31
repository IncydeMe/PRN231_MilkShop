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
            var blogList = await _unitOfWork.GetRepository<Blog>().GetListAsync();
            return new MilkResult(blogList);
        }

        public async Task<IMilkResult> GetBlogInfo(int blogId)
        {
            var blog = await _unitOfWork.GetRepository<Blog>()
                .SingleOrDefaultAsync(predicate: b => b.BlogId == blogId);
            return new MilkResult(blog);
        }

        public async Task<IMilkResult> UpdateBlogInfo(int id, Blog blogInfo)
        {
            Blog currentBlog = await _unitOfWork.GetRepository<Blog>()
                .SingleOrDefaultAsync(predicate: a => a.AccountId == id);
            if (currentBlog == null) return new MilkResult(-1, "Blog cannot be found");
            else
            {
                _unitOfWork.GetRepository<Blog>().UpdateAsync(blogInfo);
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
