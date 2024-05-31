using Microsoft.EntityFrameworkCore;
using MilkData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness
{
    public class CategoryBusiness
    {
        private readonly Net17112314MilkContext _context;

        public CategoryBusiness()
        {
            if (_context == null)
                _context = new Net17112314MilkContext();
        }

        public async Task<IMilkResult> GetCategoryList()
        {
            List<Category> categories = await _context.Categories.ToListAsync();

            MilkResult result = new MilkResult(1, "Get category list successfully", categories);
            return result;
        }

        public async Task<IMilkResult> GetCategoryById(int id)
        {
            Category category = await _context.Categories.FindAsync(id);

            MilkResult result = new MilkResult(1, "Get category successfully", category);
            return result;
        }

        public async Task<IMilkResult> CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            MilkResult result = new MilkResult(1, "Create category successfully", category);
            return result;
        }

        public async Task<IMilkResult> UpdateCategory(int id, Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            MilkResult result = new MilkResult(1, "Update category successfully", category);
            return result;
        }

        public async Task<IMilkResult> DeleteCategory(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            MilkResult result = new MilkResult(1, "Delete category successfully", category);
            return result;
        }
    }
}
