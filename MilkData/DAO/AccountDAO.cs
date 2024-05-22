using Microsoft.EntityFrameworkCore;
using MilkData.Base;
using MilkData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkData.DAO
{
    public class AccountDAO : BaseDAO<Account>
    {
        private readonly Net17112314MilkContext _context;
        public AccountDAO()
        {
            if(_context == null)
                _context = new Net17112314MilkContext();
        }

        public async void UpdateStatusAsync(Account account)
        {
            _context.Entry(account).Property("IsActive").CurrentValue = false;
            await _context.SaveChangesAsync();
        }

        public async Task<Account> CheckAuthenInput(string email, string password)
        {
            return await _context.Accounts.FirstOrDefaultAsync(a =>
                                    a.Email.Equals(email) && a.Password.Equals(password));
        }
    }
}
