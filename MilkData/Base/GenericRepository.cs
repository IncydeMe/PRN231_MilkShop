using Microsoft.EntityFrameworkCore;
using MilkData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.Base
{
    public class GenericRepository<T> where T : class
    {
        protected readonly Net17112314MilkContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository()
        {
            _context = new Net17112314MilkContext();
            _dbSet = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return [.. _dbSet];
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public void Create(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public async Task<int> CreateAsync(T entity)
        {
            _dbSet.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            var tracker = _context.Attach(entity);
            tracker.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            var tracker = _context.Attach(entity);
            tracker.State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public bool Remove(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> RemoveAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public T GetById(Guid code) => _dbSet.Find(code)!;

        public async Task<T> GetByIdAsync(Guid code) => await _dbSet.FindAsync(code);

        public T GetById(int id) => _dbSet.Find(id)!;

        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public T GetById(string code) => _dbSet.Find(code)!;

        public async Task<T> GetByIdAsync(string code) => await _dbSet.FindAsync(code);
    }
}
