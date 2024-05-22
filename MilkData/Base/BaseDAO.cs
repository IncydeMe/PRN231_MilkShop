using Microsoft.EntityFrameworkCore;
using MilkData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.Base
{
    public class BaseDAO<T> where T : class
    {
        protected readonly Net17112314MilkContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseDAO()
        {
            _context = new Net17112314MilkContext();
            _dbSet = _context.Set<T>();
        }

        #region Get Method
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public T GetById(string code)
        {
            return _dbSet.Find(code);
        }

        public async Task<T> GetByIdAsync(string code)
        {
            return await _dbSet.FindAsync(code);
        }
        #endregion

        #region Create Method
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
        #endregion

        #region Update Method
        public void Update(T entity)
        {
            var tracker = _context.Attach(entity);
            tracker.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async 
        Task
UpdateAsync(T entity)
        {
            var tracker = _context.Attach(entity);
            tracker.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Remove Method
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
        #endregion
    }
}
