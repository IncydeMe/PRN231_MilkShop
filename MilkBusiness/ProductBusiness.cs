using Microsoft.EntityFrameworkCore;
using MilkData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness
{
    public class ProductBusiness
    {
        private readonly Net17112314MilkContext _context;

        public ProductBusiness()
        {
            if (_context == null)
                _context = new Net17112314MilkContext();
        }

        public async Task<IMilkResult> GetProductList()
        {
            List<Product> products = await _context.Products.ToListAsync();

            MilkResult result = new MilkResult(1, "Get product list successfully", products);
            return result;
        }

        public async Task<IMilkResult> GetProductById(int id)
        {
            Product product = await _context.Products.FindAsync(id);

            MilkResult result = new MilkResult(1, "Get product successfully", product);
            return result;
        }

        public async Task<IMilkResult> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            MilkResult result = new MilkResult(1, "Create product successfully", product);
            return result;
        }

        public async Task<IMilkResult> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            MilkResult result = new MilkResult(1, "Update product successfully", product);
            return result;
        }

        public async Task<IMilkResult> DeleteProduct(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            MilkResult result = new MilkResult(1, "Delete product successfully", product);
            return result;
        }

    }
}
