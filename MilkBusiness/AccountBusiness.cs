using Microsoft.EntityFrameworkCore;
using MilkBusiness.Utils;
using MilkData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness
{
    public class AccountBusiness
    {
        private readonly Net17112314MilkContext _context;

        public AccountBusiness()
        {
            if (_context == null)
                _context = new Net17112314MilkContext();
        }

        #region Authentization
        public async Task<IMilkResult> Login(string email, string password)
        {
            Account account = await _context.Accounts.FirstOrDefaultAsync(a =>
                                    a.Email.Equals(email) && a.Password.Equals(password));

            MilkResult result = new MilkResult();

            if (account == null)
            {
                result.Status = -1;
                result.Message = "Incorrect Email or Password";
                return result;
            }

            if (!account.IsActive)
            {
                result.Status = -1;
                result.Message = "Your account is currently inactive (banned)";
                return result;
            }

            result.Data = JwtUtil.GenerateJwtToken(account);
            result.Status = 1;
            result.Message = "Login successfully";
            return result;
        }

        public async Task<IMilkResult> Register(string email, string password)
        {
            Account account = await _context.Accounts.FirstOrDefaultAsync(a =>
                                    a.Email.Equals(email) && a.Password.Equals(password));

            MilkResult result = new MilkResult();

            if (account != null)
            {
                result.Status = -1;
                result.Message = "Email has already used";
                return result;
            }

            Account newAccount = new Account
            {
                AccountId = 0,
                FullName = email,
                Password = password,
                Email = email,
                Phone = string.Empty,
                Address = string.Empty,
                Role = "Member",
                IsActive = true
            };
            _context.Accounts.Add(newAccount);
            await _context.SaveChangesAsync();

            result.Data = JwtUtil.GenerateJwtToken(newAccount);
            result.Status = 1;
            result.Message = "Register successfully";
            return result;
        }
        #endregion

        #region Account
        public async Task<IMilkResult> GetAllAccount()
        {
            var accList = await _context.Accounts.ToListAsync();
            return new MilkResult(accList);
        }

        public async Task<IMilkResult> GetAccountInfo(int accountId)
        {
            var acc = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == accountId);
            return new MilkResult(acc);
        }

        public async Task<IMilkResult> UpdateAccountInfo(Account accInfo)
        {
            Account currentAcc = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == accInfo.AccountId);
            if (currentAcc == null) return new MilkResult(-1, "Account cannot be found");
            else
            {
                _context.Entry(currentAcc).CurrentValues.SetValues(accInfo);
                await _context.SaveChangesAsync();
            }

            return new MilkResult(accInfo);
        }

        public async Task<IMilkResult> BanAccount(int accountId)
        {
            Account account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == accountId);
            if(account == null) return new MilkResult();
            else
            {
                _context.Entry(account).Property("IsActive").CurrentValue = false;
                await _context.SaveChangesAsync();
            }
            return new MilkResult(account);
        }
        #endregion
    }
}
